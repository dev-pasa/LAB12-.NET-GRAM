using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Interfaces
{
    public interface IGram
    {
        //Delete
        Task Delete(int id);

        //Find
        Task<Posts> GetSinglePost(int id);

        //GetAll
        Task<List<Posts>> GetPosts();

        //Save
        Task SaveAsync(Posts post);
    }
}
