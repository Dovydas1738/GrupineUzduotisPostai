using GrupineUzduotisPostai.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Contracts
{
    public interface IUserEfDbRepository
    {
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserByUserName(string userName);
        Task DeleteUserById(int id);
    }
}
