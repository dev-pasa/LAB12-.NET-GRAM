using Microsoft.EntityFrameworkCore;
using NET_GRAM.Data;
using NET_GRAM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Services
{
    public class CommentManager : IComment
    {
        private PostsDbContext _context;

        public CommentManager(PostsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of Comment in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Comment>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        /// <summary>
        /// Save the changes
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task SaveAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
    }
}
