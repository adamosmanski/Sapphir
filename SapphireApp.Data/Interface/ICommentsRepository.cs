using SapphirApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Data.Interface
{
    public interface ICommentsRepository
    {
        void AddComment(Comment _comments);
        IEnumerable<Comment> ShowAllComment(string ShortNameTask);
    }
}
