using Microsoft.Identity.Client;
using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Converter
{
    public class ProjectConverter
    {
        public static IEnumerable<ProjectsArch> ProjectsConvert(IEnumerable<Project> collection)
        {
            var result = new List<ProjectsArch>();
            foreach(var item in collection)
            {
                var projectArch = new ProjectsArch();
                projectArch.ShortName = item.ShortName;
                projectArch.Name = item.Name;
                projectArch.CreatedAt = item.CreatedAt;
                projectArch.ModDate = item.ModDate;
                projectArch.Description = item.Description;
                projectArch.ModUser = item.ModUser;
                projectArch.ModDate = item.ModDate;
                result.Add(projectArch);
            }
            return result;
        }
        public static ProjectsArch ProjectConvert(Project project)
        {
            var result = new ProjectsArch();
            result.CreatedAt = project.CreatedAt;
            result.Description = project.Description;
            result.Name = project.Name;
            result.Description = project.Description;
            result.ModDate = project.ModDate;
            result.ShortName = project.ShortName;
            return result;
        }
    }
}
