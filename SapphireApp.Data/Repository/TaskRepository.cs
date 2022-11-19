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
    public class TaskRepository : IKanbanRepository
    {
        public TaskRepository(SapphirApplicationContext _context)
        {
            context = _context;
        }
        private SapphirApplicationContext context;

        public void AddTask()
        {
            throw new NotImplementedException();
        }

        public void ArchiveTasks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TasksProject> GetAllTasks(int ProjectNumberID)
        {
            var AllTasks = context.TasksProjects.Where(x => x.IdProjects == ProjectNumberID).ToList();
            return AllTasks;
        }

        public void ShowTask()
        {
            throw new NotImplementedException();
        }
    }
}
