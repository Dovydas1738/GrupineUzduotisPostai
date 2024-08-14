using GrupineUzduotisPostai.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Contracts
{
    public interface IPostEfDbRepository
    {
        Task<List<Post>> GetAllPosts();
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task<Post> GetPostByName(string postName);
        Task DeletePostById(int id);
    }
}
