using GrupineUzduotisPostai.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupineUzduotisPostai.Core.Models;
using GrupineUzduotisPostai.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrupineUzduotisPostai.Core.Repositories
{
    public class PostEfDbRepository : IPostEfDbRepository
    {
        public async Task<List<Post>> GetAllPosts()
        {
            using (var context = new PostDbContext())
            {
                List<Post> AllPosts = await context.Posts.ToListAsync();
                return AllPosts;
            }
        }

        public async Task AddPost(Post post)
        {
            using (var context = new PostDbContext())
            {
                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdatePost(Post post)
        {
            using (var context = new PostDbContext())
            {
                context.Posts.Update(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Post> GetPostByName(string postName)
        {
            using (var context = new PostDbContext())
            {
                Post foundPost = await context.Posts.FindAsync(postName);
                return foundPost;
            }

        }

        public async Task DeletePostById(int id)
        {
            using (var context = new PostDbContext())
            {
                context.Posts.Remove(await context.Posts.FindAsync(id));
                await context.SaveChangesAsync();
            }

        }
    }
}
