using System.Collections.Generic;

namespace PlatformCodeBuilder.Models.TemplateModels
{
    /// <summary>
    /// 实体模板类
    /// </summary>
    public class EntityFileModel
    {
        public string EntityNamespace { get; set; }
        public string Namespace { get; set; }

        public string Name { get; set; }
        
        public string AngularEntityName { get; set; }

        public string FirstLowerName { get; set; }

        public string CnName { get; set; }

        public string Description { get; set; }

        public string DirName { get; set; }

        public string TableName { get; set; }

        /// <summary>
        /// 方法参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 方法传送参数
        /// </summary>
        public string MethodParameters { get; set; }

        public string CreateParameters { get; set; }

        public List<ClassProperty> ClassPropertys { get; set; }
    }

    /// <summary>
    /// 属性
    /// </summary>
    public class ClassProperty
    {
        /// <summary>
        /// 属性类型
        /// </summary>
        public string PropertyType { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 属性中文名称
        /// </summary>
        public string CnName { get; set; }

        /// <summary>
        /// 首字母小写
        /// </summary>
        public string FirstLowerName { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool IsNull { get; set; }

        /// <summary>
        /// 查询过滤字段
        /// </summary>
        public bool IsFilter { get; set; }

        /// <summary>
        /// 查询列表字段
        /// </summary>
        public bool IsShowInList { get; set; }

        /// <summary>
        /// 是否编辑页面字段
        /// </summary>
        public bool IsCreateOrEdit { get; set; }

        /// <summary>
        /// 是否必填字段
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 属性特性
        /// </summary>
        public List<ClassAttribute> ClassAttributes { get; set; }

        /// <summary>
        /// 属性特性
        /// </summary>
        public class ClassAttribute
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string NameValue { get; set; }
        }
    }
}
