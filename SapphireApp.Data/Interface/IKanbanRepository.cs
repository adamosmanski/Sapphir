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
        void AddTask(TasksProject task);
        void ArchiveTasks();
        TasksProject ShowTask(string ShortName);
        int GetLastNumberTask(int ID);
        string GetShortNameTask(int ID);
    }
}
