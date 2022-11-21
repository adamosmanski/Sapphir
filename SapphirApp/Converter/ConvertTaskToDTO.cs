using SapphirApp.Data.Models;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Converter
{
    public static class ConvertTaskToDTO
    {
        public static TasksProject Transform(NewTask newTask)
        {
            TasksProject result = new TasksProject();
            result.AssignedUser = newTask.AssignedUser;
            result.IdProjects = newTask.ProjectID;
            result.Name = newTask.Name;
            result.ShortNumber = newTask.ShortNumber;
            result.Tag = newTask.Tag;
            result.Category = newTask.Category;
            result.Description = newTask.Description;
            result.ModDate = newTask.ModDate;
            result.CreatedAt = newTask.CreatedTime;
            result.ModUser = newTask.CreatedByID;
            return result;
        }
    }
}
