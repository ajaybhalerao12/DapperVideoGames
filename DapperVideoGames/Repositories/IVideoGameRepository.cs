using DapperVideoGames.Models;

namespace DapperVideoGames.Repositories
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetAllAsync();

        Task<VideoGame> GetByIdAsync();

        Task AddAsycn(VideoGame game);

        Task UpdateAsync(VideoGame game);

        Task DeleteAsycn(int id);
    }
}
