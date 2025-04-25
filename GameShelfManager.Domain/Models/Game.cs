namespace GameShelfManager.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<GameTag> GameTags { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
