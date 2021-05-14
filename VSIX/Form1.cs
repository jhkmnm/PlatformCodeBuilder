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
            dataSource.Add(new EntityModel { ColName = "Code", DateType = "string", Describe = "仓库编码", Length = "16", IsFilter = true, IsShowInList = true, IsCreateOrEdit = true, IsRequired = true });
            dataSource.Add(new EntityModel { ColName = "Name", DateType = "string", Describe = "仓库名称", Length = "128", IsFilter = true, IsShowInList = true, IsCreateOrEdit = true, IsRequired = true });
            dataSource.Add(new EntityModel { ColName = "Address", DateType = "string", Describe = "地址", Length = "1024", IsFilter = true, IsShowInList = true, IsCreateOrEdit = true, IsRequired = true });
            dataSource.Add(new EntityModel { ColName = "Size", DateType = "string", Describe = "仓库大小", Length = "16", IsFilter = true, IsShowInList = true, IsCreateOrEdit = true, IsRequired = true });
            dataSource.Add(new EntityModel { ColName = "Remark", DateType = "string", Describe = "备注", Length = "2048", IsShowInList = true, IsCreateOrEdit = true });
            txtOutPath.Text = "E:\\NuGet";

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
            fileModel.AngularEntityName = fileModel.Name.ToLower();
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
                    Lenght = item.DateType == "string" ? Convert.ToInt32(item.Length) : 0,
                    PropertyType = item.DateType,
                    FirstLowerName = FirstCharToLower(item.ColName),
                    IsCreateOrEdit = item.IsCreateOrEdit,
                    IsFilter = item.IsFilter,
                    IsRequired = item.IsRequired,
                    IsShowInList = item.IsShowInList,
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
                            NameValue = "[Required]"
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
            fileModel.CreateParameters = string.Join(", ", fileModel.ClassPropertys.OrderBy(o => o.PropertyType).Select(s => $"dto.{s.Name}"));
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
            SetPermissionName(fileModel.Name, fileModel.Description);

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
            // content = content.Replace("< /summary>", "</summary>");
            string fileName = $"{fileModel.Name}EditDto.cs";
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

            CreateServiceDto(appServiceFolder);            
        }

        /// <summary>
        /// 生成Service下的Dto
        /// </summary>
        /// <param name="serviceFolder"></param>
        private void CreateServiceDto(ProjectItem serviceFolder)
        {
            var dtoFolder = serviceFolder.ProjectItems.AddFolder("Dtos");
            fileModel.Namespace += $".{fileModel.DirName}";
            fileModel.DirName = dtoFolder.Name;

            // 分页查询输入
            string content = Engine.Razor.RunCompile("GetPagedInputTemplate", typeof(EntityFileModel), fileModel);
            string fileName = $"GetPaged{fileModel.Name}Input.cs";
            SolutionUnit.AddFileToProjectItem(dtoFolder, content, fileName);

            // 分页结果
            content = Engine.Razor.RunCompile("GetPagedOutputTemplate", typeof(EntityFileModel), fileModel);
            fileName = $"GetPaged{fileModel.Name}Output.cs";
            SolutionUnit.AddFileToProjectItem(dtoFolder, content, fileName);

            // 单条编辑返回结果
            content = Engine.Razor.RunCompile("GetForEditOutputTemplate", typeof(EntityFileModel), fileModel);
            fileName = $"Get{fileModel.Name}ForEditOutput.cs";
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

        /// <summary>
        /// 增加权限名称
        /// </summary>
        private void SetPermissionName(string entityName, string description)
        {
            Project coreProject = solutionProjectItems.Find(t => t.Name.EndsWith(".Core")).SubProject;
            ProjectItem permissionNamesProjectItem = _dte.Solution.FindProjectItem(coreProject.FileName.Substring(0, coreProject.FileName.LastIndexOf("\\")) + "\\Authorization\\WmsPermissionNames.cs");
            if (permissionNamesProjectItem != null)
            {
                CodeClass codeClass = SolutionUnit.GetClass(permissionNamesProjectItem.FileCodeModel.CodeElements);
                var codeChilds = codeClass.Collection;
                foreach (CodeElement codeChild in codeChilds)
                {
                    var insertCode = codeChild.GetEndPoint(vsCMPart.vsCMPartBody).CreateEditPoint();
                    var code = $"        #region {description}\r\n"+
                               $"        public const string Pages_{entityName}s = \"Pages.{entityName}s\";\r\n"+
                               $"        public const string Pages_{entityName}s_Edit = \"Pages.{entityName}s.Edit\";\r\n"+
                               $"        public const string Pages_{entityName}s_Delete = \"Pages.{entityName}s.Delete\";\r\n"+
                               "        #endregion\r\n";
                    insertCode.Insert(code);
                }

                permissionNamesProjectItem.Save();
            }
        }
        
        /// <summary>
        /// 生成Angular列表页
        /// </summary>
        private void CreateAngularListComponent()
        {
            var outPath = txtOutPath.Text;
            string tsContent = Engine.Razor.RunCompile("NgListComponent", typeof(EntityFileModel), fileModel);            
            string htmlContent = Engine.Razor.RunCompile("NgListComponentHtml", typeof(EntityFileModel), fileModel);            

            if (!string.IsNullOrEmpty(outPath))
            {
                string folder = Path.Combine(outPath, $"{fileModel.AngularEntityName}s");
                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string tsFilePath = Path.Combine(folder, $"{fileModel.AngularEntityName}.component.ts");
                string htmlFilePath = Path.Combine(folder, $"{fileModel.AngularEntityName}.component.html");

                File.WriteAllText(tsFilePath, tsContent);
                File.WriteAllText(htmlFilePath, htmlContent);
            }
        }

        /// <summary>
        /// 生成Angular编辑页面
        /// </summary>
        private void CreateAngularEditComponent()
        {
            var outPath = txtOutPath.Text;
            string tsContent = Engine.Razor.RunCompile("NgEditComponent", typeof(EntityFileModel), fileModel);
            string htmlContent = Engine.Razor.RunCompile("NgEditComponentHtml", typeof(EntityFileModel), fileModel);
            string eidtDirName = "create-or-update";

            if (!string.IsNullOrEmpty(outPath))
            {
                string folder = Path.Combine(outPath, $"{fileModel.AngularEntityName}s", eidtDirName);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string tsFilePath = Path.Combine(folder, $"{fileModel.AngularEntityName}.createorupdate.component.ts");
                string htmlFilePath = Path.Combine(folder, $"{fileModel.AngularEntityName}.createorupdate.component.html");

                File.WriteAllText(tsFilePath, tsContent);
                File.WriteAllText(htmlFilePath, htmlContent);
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
                if(chkBuildService.Checked)
                {
                    CreateEntity();

                    if (chkApplication.Checked)
                        CreateEntityAppService();
                }

                if(chkBuildAngular.Checked)
                {
                    if (string.IsNullOrEmpty(txtOutPath.Text))
                        MessageBox.Show("请指定输入目录");
                    else
                    {
                        CreateAngularListComponent();
                        CreateAngularEditComponent();
                    }
                }

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

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择项目根路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutPath.Text = dialog.SelectedPath;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var current = (EntityModel)entityModelBindingSource.Current;
            //txtColName.Text = 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var list = new List<EntityModel>();
            dataGridView1.DataSource = list;

            var source = (List<EntityModel>)entityModelBindingSource.DataSource;
            source.Add(new EntityModel(){ DateType = "string" });
            dataGridView1.DataSource = entityModelBindingSource;
            entityModelBindingSource.Position = entityModelBindingSource.Count - 1;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            entityModelBindingSource.RemoveCurrent();
        }
    }
}
