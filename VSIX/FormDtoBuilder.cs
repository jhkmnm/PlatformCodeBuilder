using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using PlatformCodeBuilder.Models.TemplateModels;
using PlatformCodeBuilder.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RazorEngine.Templating;
using Engine = RazorEngine.Engine;

namespace PlatformCodeBuilder
{
    public partial class FormDtoBuilder : Form
    {
        private static DTE2 _dte;
        private static List<ProjectItem> solutionProjectItems;

        public FormDtoBuilder(DTE2 dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            _dte = dte;

            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (_dte.SelectedItems.Count > 0)
            {
                SelectedItem selectedItem = _dte.SelectedItems.Item(1);
                ProjectItem selectProjectItem = selectedItem.ProjectItem;

                if (selectProjectItem != null)
                {
                    #region 获取出基础信息
                    //获取当前点击的类所在的项目
                    Project topProject = selectProjectItem.ContainingProject;
                    //当前类在当前项目中的目录结构
                    //string dirPath = GetSelectFileDirPath(topProject, selectProjectItem);

                    //当前类命名空间
                    string namespaceStr = selectProjectItem.FileCodeModel.CodeElements.OfType<CodeNamespace>().First().FullName;
                    //当前项目根命名空间
                    string applicationStr = "";
                    if (!string.IsNullOrEmpty(namespaceStr))
                    {
                        applicationStr = namespaceStr.Substring(0, namespaceStr.IndexOf("."));
                    }
                    //当前类
                    CodeClass codeClass = SolutionUnit.GetClass(selectProjectItem.FileCodeModel.CodeElements);
                    //当前项目类名
                    string className = codeClass.Name;
                    //当前类中文名 [Display(Name = "供应商")]
                    string classCnName = "";
                    //当前类说明 [Description("品牌信息")]
                    string classDescription = "";
                    //获取类的中文名称和说明
                    foreach (CodeAttribute classAttribute in codeClass.Attributes)
                    {
                        switch (classAttribute.Name)
                        {
                            case "Display":
                                if (!string.IsNullOrEmpty(classAttribute.Value))
                                {
                                    string displayStr = classAttribute.Value.Trim();
                                    foreach (var displayValueStr in displayStr.Split(','))
                                    {
                                        if (!string.IsNullOrEmpty(displayValueStr))
                                        {
                                            if (displayValueStr.Split('=')[0].Trim() == "Name")
                                            {
                                                classCnName = displayValueStr.Split('=')[1].Trim().Replace("\"", "");
                                            }
                                        }
                                    }
                                }
                                break;
                            case "Description":
                                classDescription = classAttribute.Value;
                                break;
                        }
                    }

                    //获取当前解决方案里面的项目列表
                    List<ProjectItem> solutionProjectItems = SolutionUnit.GetSolutionProjects(_dte.Solution);
                    #endregion

                    DtoFileModel dtoModel = GetDtoModel("", "", classCnName, namespaceStr, classDescription, "", codeClass);

                    lblSelectEntity.Text = className;
                    lblSelectEntity.Tag = namespaceStr;
                    var chkListDataSource = dtoModel.ClassProperties.Select(s => new TextValue { Text = $"{s.Name}-{s.CnName}", Value = s }).ToList();
                    listSelectEntity.DataSource = chkListDataSource;
                    listSelectEntity.DisplayMember = "Text";
                    listSelectEntity.ValueMember = "Value";

                    var applicationProject = solutionProjectItems.Find(w => w.Name.EndsWith(".Application"));
                    var coreProject = solutionProjectItems.Find(w => w.Name.EndsWith(".Core"));

                    var comBoxDataSource = new List<TextProjectItem>();
                    comBoxDataSource.Add(new TextProjectItem
                    { 
                        Text = applicationProject.Name, 
                        Value = new ProjectItemFullPath { 
                            ProjectItem = applicationProject,
                            Namespace = applicationProject.Name
                        } 
                    });

                    foreach (EnvDTE.ProjectItem item in applicationProject.SubProject.ProjectItems)
                    {
                        if (item.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                            comBoxDataSource.Add(new TextProjectItem
                            { 
                                Text = $"  {item.Name}", 
                                Value = new ProjectItemFullPath 
                                { ProjectItem = item, Namespace = $"{applicationProject.Name}.{item.Name}" } 
                            });

                        if (item.ProjectItems.Count > 0)
                        {
                            foreach (EnvDTE.ProjectItem childItem in item.ProjectItems)
                            {
                                if (childItem.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                                    comBoxDataSource.Add(new TextProjectItem
                                    { 
                                        Text = $"    {childItem.Name}", 
                                        Value = new ProjectItemFullPath { 
                                            ProjectItem = childItem,
                                            Namespace = $"{applicationProject.Name}.{item.Name}.{childItem.Name}"
                                        } });
                            }
                        }                                                   
                    }

                    comBoxDataSource.Add(new TextProjectItem { Text = coreProject.Name, Value = new ProjectItemFullPath
                    {
                        ProjectItem = coreProject,
                        Namespace = coreProject.Name
                    }
                    });

                    foreach (EnvDTE.ProjectItem item in coreProject.SubProject.ProjectItems)
                    {
                        if (item.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                            comBoxDataSource.Add(new TextProjectItem
                            { Text = $"  {item.Name}", Value = new ProjectItemFullPath
                            { ProjectItem = item, Namespace = $"{coreProject.Name}.{item.Name}" }
                            });

                        if (item.ProjectItems.Count > 0)
                        {
                            foreach (EnvDTE.ProjectItem childItem in item.ProjectItems)
                            {
                                if (childItem.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                                    comBoxDataSource.Add(new TextProjectItem
                                    { Text = $"    {childItem.Name}",
                                        Value = new ProjectItemFullPath
                                        {
                                            ProjectItem = childItem,
                                            Namespace = $"{coreProject.Name}.{item.Name}.{childItem.Name}"
                                        }
                                    });
                            }
                        }
                    }

                    comboBox1.DataSource = comBoxDataSource;
                    comboBox1.DisplayMember = "Text";
                    comboBox1.ValueMember = "Value";
                }
            }
        }

        /// <summary>
        /// 获取DtoModel
        /// </summary>
        /// <param name="applicationStr"></param>
        /// <param name="name"></param>
        /// <param name="dirName"></param>
        /// <param name="codeClass"></param>
        /// <returns></returns>
        private DtoFileModel GetDtoModel(string applicationStr, string name, string entityName, string usingName, string description, string dirName, CodeClass codeClass)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var model = new DtoFileModel() {
                Namespace = applicationStr,
                Name = name, 
                UsingName = usingName,
                Description = description, 
                EntityName = entityName,
                DirName = dirName.Replace("\\", ".") 
            };
            List<ClassProperty> classProperties = new List<ClassProperty>();

            var codeMembers = codeClass.Members;
            foreach (CodeElement codeMember in codeMembers)
            {
                if (codeMember.Kind == vsCMElement.vsCMElementProperty)
                {
                    ClassProperty classProperty = new ClassProperty();
                    CodeProperty property = codeMember as CodeProperty;
                    classProperty.Name = property.Name;
                    //获取属性类型
                    var propertyType = property.Type;
                    switch (propertyType.TypeKind)
                    {
                        case vsCMTypeRef.vsCMTypeRefString:
                            classProperty.PropertyType = "string";
                            break;
                        case vsCMTypeRef.vsCMTypeRefInt:
                            classProperty.PropertyType = "int";
                            break;
                        case vsCMTypeRef.vsCMTypeRefBool:
                            classProperty.PropertyType = "bool";
                            break;
                        case vsCMTypeRef.vsCMTypeRefDecimal:
                            classProperty.PropertyType = "decimal";
                            break;
                        case vsCMTypeRef.vsCMTypeRefDouble:
                            classProperty.PropertyType = "double";
                            break;
                        case vsCMTypeRef.vsCMTypeRefFloat:
                            classProperty.PropertyType = "float";
                            break;
                        case vsCMTypeRef.vsCMTypeRefLong:
                            classProperty.PropertyType = "long";
                            break;
                        default:
                            classProperty.PropertyType = propertyType.AsString;
                            break;
                    }

                    string propertyCnName = "";//属性中文名称

                    foreach (CodeAttribute classAttribute in property.Attributes)
                    {
                        switch (classAttribute.Name)
                        {
                            case "Description":
                                propertyCnName = classAttribute.Value.Replace("\"", "");
                                break;                            
                        }
                    }                    

                    classProperty.CnName = string.IsNullOrEmpty(propertyCnName) ? property.Name : propertyCnName;

                    classProperties.Add(classProperty);
                }
            }

            model.ClassProperties = classProperties;

            return model;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            var selectItem = (ProjectItemFullPath)comboBox1.SelectedValue;
            var projectItem = selectItem.ProjectItem;
            string namespaceStr = selectItem.Namespace;

            var dtoFileModel = new DtoFileModel
            {
                Description = txtRemark.Text,
                Name = txtName.Text,
                EntityName = lblSelectEntity.Text,
                UsingName = lblSelectEntity.Tag.ToString(),
                DirName = "",
                Namespace = namespaceStr,
                ClassProperties = new List<ClassProperty>()
            };

            foreach(TextValue item in listSelectEntity.SelectedItems)
            {
                dtoFileModel.ClassProperties.Add(new ClassProperty
                {
                    CnName = item.Text,
                    Name = item.Value.Name,
                    PropertyType = item.Value.PropertyType
                });
            }

            string content = Engine.Razor.RunCompile("DtoTemplate", typeof(DtoFileModel), dtoFileModel);
            content = content.Replace("< /summary>", "</summary>");
            string fileName = dtoFileModel.Name + ".cs";
            SolutionUnit.AddFileToProjectItem(projectItem, content, fileName);

            MessageBox.Show("生成成功");
            this.Close();
        }
    }

    public class TextValue
    {
        public string Text { get; set; }
        public ClassProperty Value { get; set; }
    }

    public class TextProjectItem
    {
        public string Text { get; set;}
        public ProjectItemFullPath Value { get; set; }
    }

    public class ProjectItemFullPath
    {
        public ProjectItem ProjectItem { get; set; }
        public string Namespace { get; set; }
    }
}
