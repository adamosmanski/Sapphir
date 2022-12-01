using SapphirApp.Data.Context;
using SapphirApp.Data.Interface;
using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SapphirApp.Data.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private SapphirApplicationContext context;
        public CommentsRepository(SapphirApplicationContext _context) 
        {
            context= _context;
        }
        public void AddComment(Comment _comments)
        {
            Comment comments = new Comment()
            {
                Comments = _comments.Comments,
                ShortTaskName = _comments.ShortTaskName,
                User = _comments.User,
                CreatedAt = _comments.CreatedAt,
            };
            context.Add(comments);
            context.SaveChanges();
        }

        public IEnumerable<Comment> ShowAllComment(string ShortNameTask)
        {
            var AllComents = context.Comments.ToList();
            return AllComents;
        }
    }
}
