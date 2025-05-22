using GameShelfManager.CrossCutting;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using GameShelfManager.Domain.Models;
using System.Net;
using System.Text.Json;

namespace fn_game_shelf_manager
{
    public class ShelfGameManager
    {
        private readonly GameRepository _repository;

        public ShelfGameManager(GameRepository repository)
        {
            _repository = repository;
        }
        [Function("AddGame")]
        public async Task<HttpResponseData> AddGame(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            using var reader = new StreamReader(req.Body);
            string requestBody = await reader.ReadToEndAsync();
            Game? request = JsonSerializer.Deserialize<Game>(requestBody);

            var response = req.CreateResponse(HttpStatusCode.OK);
            bool inserted = await _repository.InsertGameAsync(request);

            if (inserted)
            {
                await response.WriteStringAsync("GameTag inserted successfully.");
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                await response.WriteStringAsync("Failed to insert GameTag.");
            }
            return response;
        }

        [Function("GetAllGames")]
        public async Task<Game> GetAllGames(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            Game gameList = new Game();

            return gameList;
        }
    }
}