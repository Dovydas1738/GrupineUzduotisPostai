using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Models;
using GrupineUzduotisPostai.Core.Repositories;
using GrupineUzduotisPostai.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace PostaiAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> Index()
        {
            var allUsers = await _userService.GetAllUsers();
            return Ok(allUsers);
        }


        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                await _userService.AddUser(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                await _userService.GetUserById(userId);
                return Ok();

            }
            catch
            {

                return Problem();

            }

        }


        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                await _userService.UpdateUser(user);
                return Ok(user);

            }
            catch
            {
                return Problem();
            }

        }


        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            await _userService.DeleteUserById(id);
            return Ok();
        }
    }
}
