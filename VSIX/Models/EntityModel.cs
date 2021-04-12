using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using EnvDTE;

namespace PlatformCodeBuilder.Models
{
    public class EntitySetting
    {
        public string TableName { get; set; }
        public string EntityNamespace { get; set; }
        public string EntityName { get; set; }
        public string TableDescription { get; set; }
        /// <summary>
        /// 构造函数参数
        /// </summary>
        public string ConstructorFields { get; set; }
        public string DtoNamespace { get; set; }
        public string ManageNamespace { get; set; }
        public ProjectItem CreateDirProject { get; set; }
        public List<EntityModel> EntityModels { get; set; }
    }

    [Serializable]
    public class EntityModel
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColName { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DateType { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 是否可为空
        /// </summary>
        public bool IsNull { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

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
    }
}