using GameShelfManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShelfManager.DataAccess.Data
{
    public  class GameShelfContext : DbContext
    {
        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<GameTag> GameTag { get; set; } = null!;
        public DbSet<Genre> Genre { get; set; } = null!;
        public DbSet<Platform> Platforms { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public GameShelfContext(DbContextOptions<GameShelfContext> options) : base(options) { }
    }
}
