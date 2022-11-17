using SapphirApp.Data.Models;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Converter
{
    public static class ConverterProjectModelToProjectDTO
    {
        public static List<ProjectModel> Transform(IEnumerable<Project> collection)
        {
            List<ProjectModel> list = new List<ProjectModel>();


            foreach (var item in collection)
            {
                ProjectModel model = new ProjectModel();
                model.Name = item.Name;
                model.Description = item.Description;
                model.CreatedAt = item.CreatedAt;
                model.ModDate = item.ModDate;
                model.ModUser = item.ModUser;
                model.Id = item.Id;
                list.Add(model);
            }
            return list;
        }
    }
}
