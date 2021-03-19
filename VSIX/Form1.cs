using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using PlatformCodeBuilder.Models;
using PlatformCodeBuilder.Models.TemplateModels;
using PlatformCodeBuilder.Unit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using Engine = RazorEngine.Engine;

namespace PlatformCodeBuilder
{
    public partial class Form1 : Form
    {
        private static DTE2 _dte;
        private static List<ProjectItem> solutionProjectItems;

        private static EntityFileModel fileModel;
        private Project coreProject;
        private Project applicationProject;

        public Form1(DTE2 dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            _dte = dte;
            fileModel = new EntityFileModel();

            InitializeComponent();

            List<EntityModel> dataSource = new List<EntityModel>();
            dataSource.Add(new EntityModel { ColName = "UserId", DateType = "long", Describe = "用户Id" });
            dataSource.Add(new EntityModel { ColName = "UserHeadIoc", DateType = "string", Describe = "用户头像", Length = "128" });
            dataSource.Add(new EntityModel { ColName = "Money", DateType = "decimal", Describe = "金额", Length = "18,2" });
            dataSource.Add(new EntityModel { ColName = "LotteryTime", DateType = "DateTime", Describe = "开奖时间", IsNull = true });
            entityModelBindingSource.DataSource = dataSource;
            InitData();
        }

        private void InitData()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            solutionProjectItems = SolutionUnit.GetSolutionProjects(_dte.Solution);
            coreProject = solutionProjectItems.FirstOrDefault(w => w.Name.EndsWith(".Core")).SubProject;
            applicationProject = solutionProjectItems.FirstOrDefault(w => w.Name.EndsWith(".Application")).SubProject;

            if(coreProject == null || applicationProject == null)
            {
                throw new Exception("项目的目录结构不符合本插件的预设，不能生成代码");
            }
        }

        /// <summary>
        /// 构造Entity数据
        /// </summary>
        private void InitModelData()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var dataSource = entityModelBindingSource.List;

            fileModel.Name = textBox3.Text;
            fileModel.TableName = textBox1.Text;
            fileModel.Description = textBox4.Text;
            fileModel.ClassPropertys = new List<ClassProperty>();
            fileModel.FirstLowerName = FirstCharToLower(fileModel.Name);

            foreach (EntityModel model in dataSource)
            {
                var item = DeepCopy(model);
                var property = new ClassProperty
                {
                    CnName = item.Describe,
                    IsNull = item.IsNull,
                    Name = item.ColName,
                    PropertyType = item.DateType,
                    FirstLowerName = FirstCharToLower(item.ColName),
                    ClassAttributes = new List<ClassProperty.ClassAttribute>()
                };
                fileModel.ClassPropertys.Add(property);

                if(item.DateType == "string")
                {
                    if (!string.IsNullOrEmpty(item.Length))
                    {
                        property.ClassAttributes.Add(new ClassProperty.ClassAttribute
                        {
                            NameValue = $"[MaxLength({item.Length})]"
                        });
                    }
                    else
                    {
                        throw new Exception("字符串类型必须指定长度");
                    }

                    if (!item.IsNull)
                        property.ClassAttributes.Add(new ClassProperty.ClassAttribute
                        {
                            NameValue = "[NotNull]"
                        });
                }
                else
                {
                    if (item.DateType == "decimal")
                    {
                        if (!string.IsNullOrEmpty(item.Length))
                        {
                            property.ClassAttributes.Add(new ClassProperty.ClassAttribute
                            {
                                NameValue = $"[Column(TypeName = \"decimal({item.Length})\")]"
                            });
                        }
                    }

                    if (item.IsNull)
                        property.PropertyType += "?";
                }
            }

            fileModel.Parameters = string.Join(", ", fileModel.ClassPropertys.OrderBy(o => o.PropertyType).Select(s => $"{s.PropertyType} {s.FirstLowerName}"));
            fileModel.MethodParameters = string.Join(", ", fileModel.ClassPropertys.OrderBy(o => o.PropertyType).Select(s => s.FirstLowerName));
            fileModel.CreateParameters = string.Join(", ", fileModel.ClassPropertys.OrderBy(o => o.PropertyType).Select(s => $"createDto.{s.Name}"));
        }

        /// <summary>
        /// 生成Entity类
        /// </summary>
        private void CreateEntity()
        {
            /*
                1. 在Core下新建一个文件夹
                2. 生成Entity文件
                3. 生成创建Entity的Dto
                4. 生成EntityManager
            */
            var entityFolder = coreProject.ProjectItems.AddFolder(fileModel.Name + "s");
            fileModel.Namespace = $"{coreProject.Name}";
            fileModel.DirName = entityFolder.Name;
            fileModel.EntityNamespace = $"{coreProject.Name}.{entityFolder.Name}";
            string content = Engine.Razor.RunCompile("EntityTemplate", typeof(EntityFileModel), fileModel);
            content = content.Replace("&quot;", "\"");
            string fileName = fileModel.Name + ".cs";
            SolutionUnit.AddFileToProjectItem(entityFolder, content, fileName);

            SetDbSetToDbContext($"{fileModel.Namespace}.{fileModel.DirName}", fileModel.Name);

            if (chkManager.Checked)
                CreateEntityManager(entityFolder);

            CreateCreateEntityDto(entityFolder);
        }

        /// <summary>
        /// 生成创建Entity的Dto
        /// </summary>
        /// <param name="entityFolder"></param>
        private void CreateCreateEntityDto(ProjectItem entityFolder)
        {
            var dtoFolder = entityFolder.ProjectItems.AddFolder("Dtos");
            fileModel.Namespace += $".{entityFolder.Name}";
            fileModel.DirName = dtoFolder.Name;
            string content = Engine.Razor.RunCompile("CreateEntityDtoTemplate", typeof(EntityFileModel), fileModel);
            content = content.Replace("< /summary>", "</summary>");
            string fileName = $"Create{fileModel.Name}Dto.cs";
            SolutionUnit.AddFileToProjectItem(dtoFolder, content, fileName);
        }

        /// <summary>
        /// 生成EntityManager
        /// </summary>
        /// <param name="entityFolder"></param>
        private void CreateEntityManager(ProjectItem entityFolder)
        {
            string content = Engine.Razor.RunCompile("ManagerTemplate", typeof(EntityFileModel), fileModel);
            string fileName = $"{fileModel.Name}Manager.cs";
            SolutionUnit.AddFileToProjectItem(entityFolder, content, fileName);
        }

        /// <summary>
        /// 生成EntityAppService
        /// </summary>
        private void CreateEntityAppService()
        {
            var appServiceFolder = applicationProject.ProjectItems.AddFolder(fileModel.Name + "s");
            fileModel.Namespace = applicationProject.Name;
            fileModel.DirName = appServiceFolder.Name;
            string content = Engine.Razor.RunCompile("AppServiceTemplate", typeof(EntityFileModel), fileModel);
            string fileName = $"{fileModel.Name}AppService.cs";
            SolutionUnit.AddFileToProjectItem(appServiceFolder, content, fileName);

            CreateEntityPageDto(appServiceFolder);
        }

        /// <summary>
        /// 生成Entity分页查询Dto
        /// </summary>
        /// <param name="serviceFolder"></param>
        private void CreateEntityPageDto(ProjectItem serviceFolder)
        {
            var dtoFolder = serviceFolder.ProjectItems.AddFolder("Dtos");
            fileModel.Namespace += $".{fileModel.DirName}";
            fileModel.DirName = dtoFolder.Name;
            string content = Engine.Razor.RunCompile("GetPagedOutputTemplate", typeof(EntityFileModel), fileModel);
            content = content.Replace("< /summary>", "</summary>");
            string fileName = $"GetPaged{fileModel.Name}Output.cs";
            SolutionUnit.AddFileToProjectItem(dtoFolder, content, fileName);

            content = Engine.Razor.RunCompile("GetPagedInputTemplate", typeof(EntityFileModel), fileModel);
            content = content.Replace("< /summary>", "</summary>");
            fileName = $"GetPaged{fileModel.Name}Input.cs";
            SolutionUnit.AddFileToProjectItem(dtoFolder, content, fileName);
        }

        /// <summary>
        /// 添加DbSet到DbContext
        /// </summary>
        /// <param name="topProject"></param>
        /// <param name="className"></param>
        private void SetDbSetToDbContext(string namespaceStr, string className)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            Project entityFrameworkProject = solutionProjectItems.Find(t => t.Name.EndsWith(".EntityFrameworkCore")).SubProject;
            ProjectItem customDbContextProviderProjectItem = _dte.Solution.FindProjectItem(entityFrameworkProject.FileName.Substring(0, entityFrameworkProject.FileName.LastIndexOf("\\")) + "\\EntityFrameworkCore\\DbContext.cs");
            if (customDbContextProviderProjectItem != null)
            {
                CodeClass codeClass = SolutionUnit.GetClass(customDbContextProviderProjectItem.FileCodeModel.CodeElements);
                var codeChilds = codeClass.Collection;
                foreach (CodeElement codeChild in codeChilds)
                {
                    var insertCode = codeChild.GetEndPoint(vsCMPart.vsCMPartBody).CreateEditPoint();
                    insertCode.Insert("        public virtual DbSet<" + namespaceStr + "." + className + "> " + className + "s { get; set; }\r\n");
                }

                customDbContextProviderProjectItem.Save();
            }
        }        

        private string FirstCharToLower(string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            string str = input[0].ToString().ToLower() + input.Substring(1);
            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            InitModelData();

            try
            {
                CreateEntity();

                if (chkApplication.Checked)
                    CreateEntityAppService();

                MessageBox.Show("生成成功");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private EntityModel DeepCopy(EntityModel model)
        {
            object clone;
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(EntityModel));
                xml.Serialize(stream, model);
                stream.Seek(0, SeekOrigin.Begin);
                clone = xml.Deserialize(stream);
                stream.Close();
            }
            return (EntityModel)clone;
        }
    }
}
