using SapphirApp.Data.Context;
using SapphirApp.Data.Interface;
using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public ProjectRepository(SapphirApplicationContext _context)
        {
            context = _context;
        }
        private SapphirApplicationContext context;

        public void AddProject(string NameProject, string DescriptionProject, int ID)
        {
            var dataProject = new Project { Name = NameProject, Description = DescriptionProject, CreatedAt = DateTime.Now, ModDate = DateTime.Now, ModUser = ID };
            context.Projects.Add(dataProject);
            context.SaveChanges();
        }
        public IEnumerable<Project> GetAllProject()
        {
            var projects = context.Projects.ToList(); ;
            return projects;
        }
    }
}