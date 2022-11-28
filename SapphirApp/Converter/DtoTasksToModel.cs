using SapphirApp.Data.Models;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Converter
{
    public class DtoTasksToModel
    {
        public static List<TaskProject> Transform(IEnumerable<TasksProject> collection)
        {
            List<TaskProject> result = new List<TaskProject>();

            foreach(var item in collection)
            {
                TaskProject model = new TaskProject();
                model.IdProjects = item.IdProjects;
                model.Name = item.Name;
                model.AssignedUser = item.AssignedUser;
                model.ModUser = item.ModUser;
                model.CreatedAt = item.CreatedAt;
                model.ModDate = item.ModDate;
                model.Category = item.Category;
                model.Description = item.Description;
                model.Id = item.Id;
                model.Tag = item.Tag;
                model.ShortNumber = item.ShortNumber;
                result.Add(model);
            }
            return result;
        }
        public static NewTask Converter(TasksProject model)
        {
            NewTask task = new NewTask();

            task.AssignedUser = model.AssignedUser;
            task.ModDate = (DateTime)model.ModDate;
            task.Category = model.Category;
            task.ShortNumber = model.ShortNumber;
            task.CreatedTime = model.CreatedAt;
            task.CreatedByID = model.IdProjects;
            task.Name = model.Name;
            task.Description = model.Description;
            task.Tag = model.Tag;

            return task;
        }
    }
    
}
