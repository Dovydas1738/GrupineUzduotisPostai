using GrupineUzduotisPostai.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Contracts
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(int id);
        Task DeleteUserById(int id);

    }
}
