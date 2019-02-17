using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Interfaces
{
    public interface IGram
    {
        /// <summary>
        /// Delete a post in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Get Single post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Posts> GetSinglePost(int id);

        /// <summary>
        /// Get a post in the database
        /// </summary>
        /// <returns></returns>
        Task<List<Posts>> GetPosts();

        /// <summary>
        /// Save a post in the database
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task SaveAsync(Posts post);
    }
}
