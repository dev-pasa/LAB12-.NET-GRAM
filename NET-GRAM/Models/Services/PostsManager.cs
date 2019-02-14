using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET_GRAM.Models.Interfaces;
using NET_GRAM.Data;

namespace NET_GRAM.Models.Services
{
    public class PostsManager : IGram      
    {
        private PostsDbContext _context;

        public PostsManager(PostsDbContext context)
        {
            _context = context;
        }


        public async Task DeleteAsync(int id)
        {
            Posts post = await _context.Post.FindAsync(id);
            if(post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Posts> FindPost(int id)
        {
            Posts post = await _context.Post.FirstOrDefaultAsync(pos => pos.ID == id);
            return post;
        }

        public async Task<List<Posts>> GetPosts()
        {
            return await _context.Post.ToListAsync();
        }


        public async Task SaveAsync(Posts post)
        {
            if(await _context.Post.FirstOrDefaultAsync(m => m.ID == post.ID) == null)
            {
                _context.Post.Add(post);
            }

            await _context.SaveChangesAsync();
               
        }
    }
}
