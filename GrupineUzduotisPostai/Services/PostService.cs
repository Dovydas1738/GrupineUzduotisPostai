using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Models;
using GrupineUzduotisPostai.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostEfDbRepository _postRepository;

        public PostService(IPostEfDbRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddPost(Post post)
        {
            await _postRepository.AddPost(post);
        }

        public async Task DeletePostById(int id)
        {
            await _postRepository.DeletePostById(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<Post> GetPostByName(string postName)
        {
            return await _postRepository.GetPostByName(postName);
        }

        public async Task<List<Post>> GetPostsByUserName(string userName)
        {
            return await _postRepository.GetPostsByUserName(userName);
        }

        public async Task UpdatePost(Post post)
        {
            await _postRepository.UpdatePost(post);
        }
    }
}
