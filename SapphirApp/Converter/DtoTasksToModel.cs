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
        public static List<MessagesInTask> TransformComment(IEnumerable<Comment> collection)
        {
            List<MessagesInTask> result = new List<MessagesInTask>();
            foreach (var item in collection)
            {
                MessagesInTask model = new MessagesInTask();
                model.UserName = item.User;
                model.Time = item.CreatedAt;
                model.Message = item.Comments;
                model.ShortTaskName = item.ShortTaskName;
                result.Add(model);
            }
            return result;
        }
        public static Comment ConverterComments(MessagesInTask model)
        {
            Comment result = new Comment();
            result.User = model.UserName;
            result.CreatedAt = model.Time;
            result.Comments = model.Message;
            result.ShortTaskName = model.ShortTaskName;
            return result;
        }
        public static NewTask Converter(TasksProject model)
        {
            NewTask task = new NewTask();

            task.AssignedUser = model.AssignedUser;
            task.Category = model.Category;
            task.ShortNumber = model.ShortNumber;
            task.CreatedTime = model.CreatedAt;
            task.CreatedByID = model.IdProjects;
            task.Name = model.Name;
            task.Description = model.Description;
            task.Tag = model.Tag;

            return task;
        }
        public static List<TaskProject> TransformToMyTask(List<TasksProject> collection)
        {
            var result = new List<TaskProject>();
            foreach (var task in collection)
            {
                var project = new TaskProject();
                project.Name = task.Name;
                project.Description = task.Description;
                project.Tag = task.Tag;
                project.Id = task.Id;
                project.IdProjects = task.IdProjects;
                project.ShortNumber = task.ShortNumber;
                project.AssignedUser = task.AssignedUser;
                project.Category = task.Category;
                project.CreatedAt = task.CreatedAt;
                project.ModDate = task.ModDate;
                project.ModUser= task.ModUser;
                result.Add(project);
            }
            return result;
        }
    }
    
}
