using Dapper;
using DapperVideoGames.Models;
using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;

namespace DapperVideoGames.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {        
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public VideoGameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString= _configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection GetConnection() =>
            new NpgsqlConnection(_connectionString);

        public async Task<List<VideoGame>> GetAllAsync()
        {
            var query = "SELECT* FROM \"VideoGames\"";
            using var connection = GetConnection();
            var videos = await connection
                 .QueryAsync<VideoGame>(query);
            return videos.ToList();
        }

        public Task<VideoGame> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsycn(VideoGame game)
        {

            throw new NotImplementedException();
        }

        public Task UpdateAsync(VideoGame game)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsycn(int id)
        {
            throw new NotImplementedException();
        }
    }
}
