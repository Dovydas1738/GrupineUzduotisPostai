using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Repositories
{
    public class UserEfDbRepository : IUserEfDbRepository
    {
        public async Task<List<User>> GetAllUsers()
        {
            using (var context = new PostDbContext())
            {
                List<User> allUsers = await context.Users.ToListAsync();
                return allUsers;
            }
        }

        public async Task AddUser(User user)
        {
            using (var context = new PostDbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUser(User user)
        {
            using (var context = new PostDbContext())
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            using (var context = new PostDbContext())
            {
                User foundUser = await context.Users.FindAsync(userName);
                return foundUser;
            }

        }

        public async Task DeleteUserById(int id)
        {
            using (var context = new PostDbContext())
            {
                context.Users.Remove(await context.Users.FindAsync(id));
                await context.SaveChangesAsync();
            }

        }

    }
}
