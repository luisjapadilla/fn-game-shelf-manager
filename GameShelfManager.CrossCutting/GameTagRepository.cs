using GameShelfManager.DataAccess.Data;
using GameShelfManager.Domain.Models;
using System.Net;

namespace GameShelfManager.CrossCutting
{
    public class GameTagRepository
    {
        GameShelfContext _context;

        public GameTagRepository(GameShelfContext shelfContext)
        {
            _context = shelfContext;
        }
        public async Task<bool> InsertGameTag(GameTag gameTag)
        {
            _context.GameTag.Add(gameTag);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return success response
            var response = req.CreateResponse(HttpStatusCode.Created);
        }
    }
}
