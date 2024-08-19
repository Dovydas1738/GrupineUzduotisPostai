using GrupineUzduotisPostai.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupineUzduotisPostai.Core.Models;
using GrupineUzduotisPostai.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GrupineUzduotisPostai.Core.Repositories
{
    public class PostEfDbRepository : IPostEfDbRepository
    {

        public async Task<List<Post>> GetAllPosts()
        {
            using (var context = new PostDbContext())
            {
                List<Post> AllPosts = await context.Posts.ToListAsync();

                foreach (Post p in AllPosts)
                {
                    context.Entry(p).Reference(x => x.User).Load();
                    Console.WriteLine($"{p.User.UserId} {p.User.UserName} {p.Name} {p.Content} {p.Date}");
                }
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
                List<Post> AllPosts = await context.Posts.ToListAsync();

                foreach (Post p in AllPosts)
                {
                    if(p.Name == postName)
                    {
                        context.Entry(p).Reference(x => x.User).Load();
                        Console.WriteLine($"{p.User.UserId} {p.User.UserName} {p.Name} {p.Content} {p.Category} {p.Date}");
                        return p;
                    }
                }
                return null;
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

        public async Task<List<Post>> GetPostsByUserName(string userName)
        {
            using (var context = new PostDbContext())
            {
                List<Post> AllPosts = await context.Posts.ToListAsync();
                List<Post> foundPosts = new List<Post>();


                foreach(Post post in AllPosts)
                {
                    context.Entry(post).Reference(x => x.User).Load();
                    if (post.User.UserName == userName)
                    {
                        Console.WriteLine($"{post.User.UserId} {post.User.UserName} {post.Name} {post.Content} {post.Category} {post.Date}");

                        foundPosts.Add(post);
                    }
                }
                return foundPosts;
            }
        }
    }
}
