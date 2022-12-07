using SapphirApp.Data.Context;
using SapphirApp.Data.Interface;
using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Repository
{
    public class TaskRepository: IKanbanRepository
    {
        public TaskRepository(SapphirApplicationContext _context)
        {
            context = _context;
        }
        private SapphirApplicationContext context;
        public void AddTask(TasksProject task)
        {
            TasksProject project = new TasksProject()
            {
                Name = task.Name,
                Description = task.Description,
                ShortNumber = task.ShortNumber,
                IdProjects = task.IdProjects,
                CreatedAt = task.CreatedAt,
                AssignedUser = task.AssignedUser,
                Tag = task.Tag,
                Category = task.Category,
                ModDate = task.ModDate,
                ModUser = task.ModUser,
            };
            context.Add(project);
            context.SaveChanges();
        }
        public void ArchiveTasks()
        {
            throw new NotImplementedException();
        }
        public void UpdateColumn(string ShortName, string Column, string User)
        {
            using( var context = new SapphirApplicationContext())
            {
                var result = context.TasksProjects.SingleOrDefault(x => x.ShortNumber == ShortName);
                if(result != null)
                {
                    result.Category = Column;
                    result.AssignedUser = User; 
                    context.Update(result);
                    context.SaveChanges();
                }
            }
        }
        public IEnumerable<TasksProject> GetAllTasks(int ProjectNumberID)
        {
            var AllTasks = context.TasksProjects.Where(x => x.IdProjects == ProjectNumberID).ToList();
            return AllTasks;
        }
        public int GetLastNumberTask(int ID)
        {
            var LastTask = context.TasksProjects.Where(x => x.IdProjects == ID).OrderByDescending(x => x.Id).FirstOrDefault();
            return Convert.ToInt32(LastTask.ShortNumber.Substring(4));
        }
        public string GetShortNameTask(int ID)
        {
            var LastTask = context.Projects.Where(x => x.Id == ID).OrderByDescending(x => x.Id).FirstOrDefault();
            return LastTask.ShortName;
        }
        public TasksProject ShowTask(string ShortName)
        {
            var InfoTask = context.TasksProjects.Where(x => x.ShortNumber == ShortName).FirstOrDefault();
            return InfoTask;
        }
        public List<TasksProject> GetUserTasks(string Login)
        {
            var Tasks = context.TasksProjects.Where(x=>x.AssignedUser== Login).ToList();
            return Tasks;
        }

        public void UpdateAssign(string ShortName, string User)
        {
            using (var context = new SapphirApplicationContext())
            {
                var result = context.TasksProjects.SingleOrDefault(x=>x.ShortNumber== ShortName);
                if (result != null)
                {
                    result.AssignedUser= User;
                    context.Update(result);
                    context.SaveChanges();
                }
            }
        }
    }
}
