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
    public class UserService : IUserService
    {
        private readonly IUserEfDbRepository _userRepository;

        public UserService(IUserEfDbRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(user);
        }

        public async Task DeleteUserById(int id)
        {
            await _userRepository.DeleteUserById(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _userRepository.GetUserByUserName(userName);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }
    }
}
