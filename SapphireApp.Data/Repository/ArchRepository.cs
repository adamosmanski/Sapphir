using SapphirApp.Data.Context;
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
        public void InsertProject(Project project)
        {
            var archivesProject = new ProjectsArch
            {
                CreatedAt = DateTime.Now,
                ShortName = project.ShortName,
                Name = project.Name,
                Description = project.Description,
                ModDate = DateTime.Now,
                ModUser = project.ModUser
            };

            using (var context = new ArchivesContext())
            {
                context.ProjectsArches.Add(archivesProject);
                context.SaveChanges();
            }
        }
        public void InsertComment(Comment comment)
        {
            var archivesComment = new CommentsArch
            {
                CreatedAt = DateTime.Now,
                Comment = comment.Comments,
                ShortTaskName = comment.ShortTaskName,
                User = comment.User,
            };
            using (var context = new ArchivesContext())
            {
                context.CommentsArches.Add(archivesComment);
                context.SaveChanges();
            }
        }
        public void InsertTasks(TasksProject tasksProject)
        {
            var archivesTask = new TasksProjectArch
            {
                CreatedAt = DateTime.Now,
                ShortNumber = tasksProject.ShortNumber,
                Name = tasksProject.Name,
                Description = tasksProject.Description,
                AssignedUser = tasksProject.AssignedUser,
                Category = tasksProject.Category,
                IdProjects = tasksProject.IdProjects,
                ModDate = DateTime.Now,
                ModUser = tasksProject.ModUser,
                Tag = tasksProject.Tag
            };
            using (var context = new ArchivesContext())
            {
                context.TasksProjectArches.Add(archivesTask);
                context.SaveChanges();
            }
        }
        private void DeleteFromMainDatabase()
        {

        }
        #endregion
    }
}