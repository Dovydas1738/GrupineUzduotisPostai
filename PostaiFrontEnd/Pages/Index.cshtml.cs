using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Repositories;
using GrupineUzduotisPostai.Core.Services;
using GrupineUzduotisPostai.Core.Models;

namespace PostaiFrontEnd.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public List<Post> Posts;
        public List<User> Users;

        public IndexModel(IUserService userService, IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }


        public async Task OnGet()
        {

            Posts = await _postService.GetAllPosts();

        }
    }
}
