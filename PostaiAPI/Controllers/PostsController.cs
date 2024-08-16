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


        public PostsController(IPostEfDbRepository postEfDbRepository, IPostService postService)
        {
            _postEfDbRepository = postEfDbRepository;
            _postService = postService;
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
            Post post1 = new Post {Id = post.Id, User = new User(post.UserName) ,Name = post.Name, Content = post.Content, Date = post.Date};
            try
            {
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


        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePostById(int id)
        {
            await _postService.DeletePostById(id);
            return Ok();
        }









    }
}
