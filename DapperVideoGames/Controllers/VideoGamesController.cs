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

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<VideoGame>> GetByIdAsync(int id)
        {
            var videoGame = await _videoGameRepository.GetByIdAsync(id);
            if (videoGame == null)
            {
                return NotFound($"Video game with id {id} not found");
            }
            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(VideoGame videoGame)
        {
            await _videoGameRepository.AddAsycn(videoGame);
            return CreatedAtAction("GetById", new { id = videoGame.Id }, videoGame);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, VideoGame videoGame)
        {
            var existingGame = await _videoGameRepository.GetByIdAsync(id);
            if (existingGame == null)
            {
                return NotFound($"Video Game with id {id} not found");
            }
            videoGame.Id = id;
            await _videoGameRepository.UpdateAsync(videoGame);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingGame = await _videoGameRepository.GetByIdAsync(id);
            if (existingGame == null)
            {
                return NotFound($"Video Game with id {id} not found");
            }

            await _videoGameRepository.DeleteAsycn(id);
            return NoContent();
        }
    }
}
