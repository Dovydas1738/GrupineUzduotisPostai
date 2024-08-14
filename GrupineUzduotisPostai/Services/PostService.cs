using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Services
{
    public class PostService : IPostService
    {
        public Task AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task DeletePostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByName(string postName)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
