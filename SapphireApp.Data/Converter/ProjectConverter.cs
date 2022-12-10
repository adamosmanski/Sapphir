﻿using Microsoft.Identity.Client;
using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Converter
{
    public class ProjectConverter
    {
        public static IEnumerable<ProjectsArch> ProjectsConvert(IEnumerable<Project> collection)
        {
            var result = new List<ProjectsArch>();
            foreach(var item in collection)
            {
                var projectArch = new ProjectsArch();
                projectArch.ShortName = item.ShortName;
                projectArch.Name = item.Name;
                projectArch.CreatedAt = item.CreatedAt;
                projectArch.ModDate = item.ModDate;
                projectArch.Description = item.Description;
                projectArch.ModUser = item.ModUser;
                projectArch.ModDate = item.ModDate;
                result.Add(projectArch);
            }
            return result;
        }
        public static ProjectsArch ProjectConvert(Project project)
        {
            var result = new ProjectsArch();
            result.CreatedAt = project.CreatedAt;
            result.Description = project.Description;
            result.Name = project.Name;
            result.Description = project.Description;
            result.ModDate = project.ModDate;
            result.ShortName = project.ShortName;
            return result;
        }

        //Task
        public static IEnumerable<TasksProjectArch> TasksConvert(IEnumerable<TasksProject> collection)
        {
            var result = new List<TasksProjectArch>();
            foreach (var item in collection)
            {
                var taskArch = new TasksProjectArch();
                taskArch.Name = item.Name;
                taskArch.CreatedAt = item.CreatedAt;
                taskArch.ModDate = item.ModDate;
                taskArch.Description = item.Description;
                taskArch.ModUser = item.ModUser;
                taskArch.ModDate = item.ModDate;
                taskArch.IdProjects = item.IdProjects;
                taskArch.AssignedUser = item.AssignedUser;
                taskArch.Category = item.Category;
                taskArch.Tag = item.Tag;
                result.Add(taskArch);
            }
            return result;
        }
        //Comments
        public static IEnumerable<CommentsArch> CommentsConvert(IEnumerable<Comment> collection)
        {
            var result = new List<CommentsArch>();
            foreach(var item in collection)
            {
                var comment = new CommentsArch();
                comment.User = item.User;
                comment.Comment = item.User;
                comment.CreatedAt = item.CreatedAt;
                comment.ShortTaskName = item.ShortTaskName;
                result.Add(comment);
            }
            return result;
        }
    }
}
