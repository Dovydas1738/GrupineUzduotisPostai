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
            var allPosts = await _postEfDbRepository.GetAllPosts();
            return Ok(allPosts);
        }


        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost(Post post)
        {
            try
            {
                await _postEfDbRepository.AddPost(post);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }


        [HttpPost("UpdatePost")]
        public async Task<IActionResult> UpdatePost(Post post)
        {
            try
            {
                await _postEfDbRepository.UpdatePost(post);
                return Ok(post);

            }
            catch
            {
                return Problem();
            }

        }

        [HttpPost("GetPostByName")]
        public async Task<IActionResult> GetPostByName(string postName)
        {
            try
            {
                await _postEfDbRepository.GetPostByName(postName);
                return Ok();

            }
            catch
            {

                return Problem();

            }

        }


        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePostById(int id)
        {
            await _postEfDbRepository.DeletePostById(id);
            return Ok();
        }







    }
}
