using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Interface
{
    public interface IProjectRepository
    {
        void AddProject(string NameProject, string DescriptionProject, int ID);
        IEnumerable<Project> GetAllProject();
        
    }
}
