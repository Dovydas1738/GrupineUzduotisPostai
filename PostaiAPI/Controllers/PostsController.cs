using Microsoft.AspNetCore.Mvc;
using GrupineUzduotisPostai.Core.Models;
using GrupineUzduotisPostai.Core.Contracts;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PostaiAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class PostsController : Controller
    {
        private readonly IPostEfDbRepository _postEfDbRepository;
        private readonly IPostService _postService;
        private readonly IUserService _userService;


        public PostsController(IPostEfDbRepository postEfDbRepository, IPostService postService, IUserService userService)
        {
            _postEfDbRepository = postEfDbRepository;
            _postService = postService;
            _userService = userService;
        }


        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> Index()
        {
            var allPosts = await _postService.GetAllPosts();
            return Ok(allPosts);
        }


        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost(PostCreateRequest post)
        {
            try
            {
                //List<Post> postCheck = await _postEfDbRepository.GetPostsByUserName(post.UserName);
                //if (postCheck.Count > 0)
                //{
                //    User foundUser = await _userService.GetUserByUserName(post.UserName);
                //    foundUser = foundUser;
                //    Post post1 = new Post { Id = post.Id, User = foundUser, Name = post.Name, Content = post.Content, Date = post.Date };
                //    post1.SetDate();
                //    await _postService.AddPost(post1);
                //    return Ok();
                //}
                //else
                //{
                //    Post post1 = new Post { Id = post.Id, User = new User(post.UserName), Name = post.Name, Content = post.Content, Date = post.Date };
                //    post1.SetDate();
                //    await _postService.AddPost(post1);
                //    return Ok();
                //}
                
                Post post1 = new Post { Id = post.Id, User = new User(post.UserName), Name = post.Name, Content = post.Content, Date = post.Date };
                post1.SetDate();
                await _postService.AddPost(post1);
                return Ok();



            }
            catch
            {
                return Problem();
            }

        }


        [HttpPatch("UpdatePost")]
        public async Task<IActionResult> UpdatePost(Post post)
        {
            try
            {
                await _postService.UpdatePost(post);
                return Ok(post);

            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("GetPostByName")]
        public async Task<IActionResult> GetPostByName(string postName)
        {
            try
            {
                var foundPost = await _postService.GetPostByName(postName);
                if (foundPost == null)
                {
                    return NotFound(new { Message = "Post not found" });
                }

                return Ok(new
                {
                    id = foundPost.Id,
                    name = foundPost.Name,
                    content = foundPost.Content,
                    userName = foundPost.User.UserName,
                    date = foundPost.Date
                });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpDelete("DeletePost/{id}")]
        public async Task<IActionResult> DeletePostById(int id)
        {
            await _postService.DeletePostById(id);
            return Ok();
        }


        [HttpGet("GetPostsByUserName")]
        public async Task<IActionResult> GetPostsByUserName(string userName)
        {
            try
            {
                var foundPosts = await _postService.GetPostsByUserName(userName);
                return Ok(foundPosts);

            }
            catch
            {
                return Problem();
            }

        }






    }
}
