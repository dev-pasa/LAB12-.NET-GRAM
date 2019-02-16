using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Interfaces
{
    public interface IComment
    {
        Task<List<Comment>> GetComments();

        Task SaveAsync(Comment comment);
    }
}
