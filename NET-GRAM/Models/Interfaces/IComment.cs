using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Interfaces
{
    public interface IComment
    {
        /// <summary>
        /// get a list of comments
        /// </summary>
        /// <returns></returns>
        Task<List<Comment>> GetComments();

        /// <summary>
        /// save the comments
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task SaveAsync(Comment comment);
    }
}
