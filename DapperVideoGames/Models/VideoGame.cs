namespace DapperVideoGames.Models
{
    /// <summary>
    /// Represents a video game with its details.
    /// </summary>
    public class VideoGame
    {
        /// <summary>
        /// Gets or sets the unique identifier for the video game.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the video game.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the video game.
        /// </summary>
        public required string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the developer of the video game.
        /// </summary>
        public required string Developer { get; set; }

        /// <summary>
        /// Gets or sets the release date of the video game.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }

}
