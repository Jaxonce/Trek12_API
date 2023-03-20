using Microsoft.AspNetCore.Mvc;
using Stub;

namespace Trek12_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController: ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private StubData.GamesManager gamesManager { get; set; } = new StubData.GamesManager(new StubData());


        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/AllGames")]
        public async Task<IActionResult> Get()
        {
            var list = await gamesManager
        }
    }
}
