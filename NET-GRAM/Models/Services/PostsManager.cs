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


        public async Task<Posts> GetSinglePost(int id)
        {
            Posts post = await _context.Post.FirstOrDefaultAsync(pos => pos.ID == id);
            if (post != null)
            {
                post.Comments = await _context.Comments.Where(c => c.PostID == post.ID).ToListAsync();
            }

            return post;
        }


        public async Task<List<Posts>> GetPosts()
        {
            return await _context.Post.ToListAsync();
        }


        public async Task SaveAsync(Posts Post)
        {
            if (await _context.Post.FirstOrDefaultAsync(n => n.ID == Post.ID) == null)
            {
                _context.Post.Add(Post);
            }
            else
            {
                _context.Post.Update(Post);
            }

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            //check to see if it exists
            Posts post = await _context.Post.FirstOrDefaultAsync(pos => pos.ID == id);
            if(post != null)
            {
                _context.Remove(post);

                List<Comment> comments = await _context.Comments.Where(c => c.PostID == post.ID).ToListAsync();
                foreach (Comment item in comments)
                {
                    _context.Comments.Remove(item);
                }

                await _context.SaveChangesAsync();
            }
        }

         
    }
}
