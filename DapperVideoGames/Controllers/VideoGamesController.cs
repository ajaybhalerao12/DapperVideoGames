using DapperVideoGames.Models;
using DapperVideoGames.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperVideoGames.Controllers
{
    [Route("api/videogames")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public VideoGamesController(IVideoGameRepository videoGameRepository)
        {
            this._videoGameRepository = videoGameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAllAsync()
        {
            var videos = await _videoGameRepository.GetAllAsync();
            return Ok(videos);
        }
    }
}
