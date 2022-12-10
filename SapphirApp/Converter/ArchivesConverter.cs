using SapphirApp.Data.Models;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace SapphirApp.Converter
{
    public class ArchivesConverter
    {
        public static List<ProjectModel> ConverterProject(IEnumerable<ProjectsArch> collection)
        {
            var result = new List<ProjectModel>();
            foreach (var project in collection)
            {
                var projectModel = new ProjectModel();
                projectModel.Name = project.Name;
                projectModel.Description = project.Description;
                projectModel.ModDate = project.ModDate;
                projectModel.ShortNumber = project.ShortName;
                projectModel.ModUser = project.ModUser;
                projectModel.ModDate = project.ModDate;
                projectModel.CreatedAt = project.CreatedAt;
                result.Add(projectModel);
            }
            return result;
        }
    }
}
