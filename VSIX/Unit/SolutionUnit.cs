using EnvDTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlatformCodeBuilder.Unit
{
    public static class SolutionUnit
    {
        /// <summary>
        /// 获取解决方案里面所有项目
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public static List<ProjectItem> GetSolutionProjects(Solution solution)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

            List<ProjectItem> projectItemList = new List<ProjectItem>();
            var projects = solution.Projects.OfType<Project>();
            foreach (var project in projects)
            {
                var projectitems = GetProjects(project.ProjectItems);

                foreach (var projectItem in projectitems)
                {
                    projectItemList.Add(projectItem);
                }
            }

            return projectItemList;
        }

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <param name="projectItems"></param>
        /// <returns></returns>
        public static IEnumerable<ProjectItem> GetProjects(ProjectItems projectItems)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

            foreach (EnvDTE.ProjectItem item in projectItems)
            {
                yield return item;

                if (item.SubProject != null)
                {
                    foreach (EnvDTE.ProjectItem childItem in GetProjects(item.SubProject.ProjectItems))
                        if (childItem.Kind == EnvDTE.Constants.vsProjectItemKindSolutionItems)
                            yield return childItem;
                }
                else if(item.ProjectItems != null)
                {
                    foreach (EnvDTE.ProjectItem childItem in GetProjects(item.ProjectItems))
                        if (childItem.Kind == EnvDTE.Constants.vsProjectItemKindSolutionItems)
                            yield return childItem;
                }
            }
        }

        /// <summary>
        /// 获取类
        /// </summary>
        /// <param name="codeElements"></param>
        /// <returns></returns>
        public static CodeClass GetClass(CodeElements codeElements)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var elements = codeElements.Cast<CodeElement>().ToList();
            var result = elements.FirstOrDefault(codeElement => codeElement.Kind == vsCMElement.vsCMElementClass) as CodeClass;
            if (result != null)
            {
                return result;
            }
            foreach (var codeElement in elements)
            {
                result = GetClass(codeElement.Children);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加文件到项目中
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        public static void AddFileToProjectItem(ProjectItem folder, string content, string fileName)
        {
            try
            {
                string path = Path.GetTempPath();
                Directory.CreateDirectory(path);
                string file = Path.Combine(path, fileName);
                File.WriteAllText(file, content, System.Text.Encoding.UTF8);
                try
                {
                    folder.ProjectItems.AddFromFileCopy(file);
                }
                finally
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
