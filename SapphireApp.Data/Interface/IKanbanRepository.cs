using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Interface
{
    public interface IKanbanRepository
    {
        IEnumerable<TasksProject> GetAllTasks(int ProjectNumberID);
        void AddTask();
        void ArchiveTasks();
        void ShowTask();
    }
}
