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
       
        public async Task<List<VideoGame>> GetAllAsync()
        {
            var query = "SELECT * FROM \"VideoGames\"";
            using var connection = GetConnection();
            var videos = await connection
                 .QueryAsync<VideoGame>(query);
            return videos.ToList();
        }

        public async Task<VideoGame> GetByIdAsync(int id)
        {            
            using var connection = GetConnection();
            const string query = @"SELECT * FROM ""VideoGames"" WHERE Id = @Id";
            var videoGame = await connection
                .QueryFirstOrDefaultAsync<VideoGame>(query, new { Id = id });
            return videoGame;
        }

        public async Task AddAsycn(VideoGame game)
        {
            using var connection = GetConnection();            
            var query = @"Insert into ""VideoGames""(Id,Title,Publisher,Developer,ReleaseDate) 
                        Values(@Id,@Title,@Publisher,@Developer,@ReleaseDate)";

            await connection.ExecuteAsync(query, game);
        }

        // NOTE:  we would risk SQL injection attacks.
        public async Task UpdateAsync(VideoGame videoGame)
        {
            var query = @"
                UPDATE ""VideoGames"" 
                SET Title = @Title, Publisher = @Publisher, Developer = @Developer, ReleaseDate = @ReleaseDate 
                WHERE Id = @Id";
            using var connection = GetConnection();
            int v = await connection.ExecuteAsync(query, videoGame);            
        }
        public async Task DeleteAsycn(int id)
        {
            var query = @"DELETE FROM ""VideoGames"" 
                        WHERE Id = @Id";
            using var connection = GetConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
        private IDbConnection GetConnection() =>
           new NpgsqlConnection(_connectionString);

    }
}
