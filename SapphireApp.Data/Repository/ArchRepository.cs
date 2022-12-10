using SapphirApp.Data.Context;
using SapphirApp.Data.Converter;
using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace SapphirApp.Data.Repository
{
    public class ArchRepository
    {
        public ArchRepository(ArchivesContext _context) 
        {
            context = _context;
        }
       
        private ArchivesContext context;
        #region Methods
        public void InsertAndDeleteProject(string NameProject)
        {

            using (var SapphirContext = new SapphirApplicationContext())
            using (var archiveContext = new ArchivesContext())
            {
                var Project = SapphirContext.Projects.AsEnumerable();
                var SelectedProject = Project.Where(x => x.Name == NameProject);

                foreach (var item in SelectedProject)
                {
                    archiveContext.ProjectsArches.Add(ProjectConverter.ProjectConvert(item));
                }

                var ProjectID = Project.Where(x => x.Name == NameProject).Select(x => x.Id).SingleOrDefault();
                SapphirContext.Projects.RemoveRange(SelectedProject);
                var Task = SapphirContext.TasksProjects.AsEnumerable();
                var SelectedTask = Task.Where(x => x.IdProjects == ProjectID);
                var ShortTaskNumber = Task.Where(x=>x.IdProjects==ProjectID).Select(x=>x.ShortNumber).SingleOrDefault();
                
                var Comments = SapphirContext.Comments.Where(x => x.ShortTaskName.Contains(ShortTaskNumber));
                
                SapphirContext.TasksProjects.RemoveRange(SelectedTask);
                
                SapphirContext.Comments.RemoveRange(Comments);
                SapphirContext.SaveChanges();
                archiveContext.SaveChanges();
            }
            
        }

        public IEnumerable<ProjectsArch> ArchivesProject()
        {
            var result = context.ProjectsArches.ToList();
            return result;
        }
        #endregion
    }
}