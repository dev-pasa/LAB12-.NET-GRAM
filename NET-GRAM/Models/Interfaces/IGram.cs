using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Interfaces
{
    public interface IGram
    {
        //Delete
        Task DeleteAsync(int id);

        //Find
        Task<Posts> FindPost(int id);

        //GetAll
        Task<List<Posts>> GetPosts();

        //Save
        Task SaveAsync(Posts post);
    }
}
