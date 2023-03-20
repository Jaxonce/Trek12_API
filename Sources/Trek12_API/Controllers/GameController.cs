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
        public async Task<IActionResult> GetAllGames()
        {
            try
            {
                var list = await gamesManager.GetItems(0, gamesManager.GetNbItems().Result, null, false);
                if (list == null) return NotFound("Pas de parties trouvées");
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

/*        [HttpGet("/GameById")]
        public async Task<IActionResult> GetGameById(int id)
        {
            try
            {
                var game = await gamesManager.GetItemsById(id);
                if (game == null) return NotFound("Pas de parties trouvées");
                return Ok(game.FirstOrDefault());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        /*
        [HttpGet("/GameByPlayer")]
        public async Task<IActionResult> GetGamesByPlayer()
        {
            try
            {
                var games = await gamesManager.GetItems(0, gamesManager)
            }
        }*/
    }
}
