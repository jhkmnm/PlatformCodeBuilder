using System.Collections.Generic;

namespace PlatformCodeBuilder.Models.TemplateModels
{
    public class DtoFileModel
    {
        public string UsingName { get; set; }
        /// <summary>
        /// 项目命名空间
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// 当前目录名称
        /// </summary>
        public string DirName { get; set; }
        public string Description { get; set; }
        public string EntityName { get; set; }
        public string Name { get; set; }

        public List<ClassProperty> ClassProperties { get; set; }
    }
}
