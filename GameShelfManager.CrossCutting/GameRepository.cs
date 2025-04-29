using GameShelfManager.DataAccess.Data;
using GameShelfManager.Domain.Models;
using Microsoft.Extensions.Logging;

namespace GameShelfManager.CrossCutting
{
    public class GameRepository
    {
        private readonly GameShelfContext _context;

        public GameRepository(GameShelfContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> InsertGameAsync(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            try
            {
                await _context.Game.AddAsync(game);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
