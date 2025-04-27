using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using GameShelfManager.Domain.Models;
using Azure.Core;

namespace fn_game_shelf_manager
{
    public class ShelfGameTagManager
    {
        private readonly ILogger<ShelfGameTagManager> _logger;

        public ShelfGameTagManager(ILogger<ShelfGameTagManager> logger)
        {
            _logger = logger;
        }

        [Function("AddGameTag")]
        public async Task<HttpResponseData> GetGameData(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            using var reader = new StreamReader(req.Body);
            string requestBody = await reader.ReadToEndAsync();
            GameTag? request =
                JsonSerializer.Deserialize<GameTag>(requestBody);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("Hello from .NET 8 Azure Function!");

            return response;
        }
    }
}
