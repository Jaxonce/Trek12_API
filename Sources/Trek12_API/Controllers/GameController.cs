using Microsoft.AspNetCore.Mvc;
using Model;
using Stub;
using Trek12_API.DTO;
using static Stub.StubData;

namespace Trek12_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController: ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private GamesManager gamesManager { get; set; } = new StubData.GamesManager(new StubData());


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

        [HttpGet("/GameById/{id}")]
        public async Task<IActionResult> GetGameById([FromRoute] int id)
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
        }
        [HttpDelete (Name = "DeleteGameById")]
        public async Task<IActionResult> DeleteGame(int idGame)
        {
            var gameToDelete = await gamesManager.GetItemsById(idGame);
            if (gameToDelete == null)
            {
                return NotFound("Partie non trouvée");
            }

            if (!await gamesManager.DeleteItem(gameToDelete.SingleOrDefault(game => game.Id == idGame)))
            {
                return BadRequest("Erreur lors de la suppression de la partie");
            }

            return Ok("Partie bien supprimée");
        }

      /*[HttpPut(Name = "UpdateGameById")]
        public async Task<IActionResult> Update(int id, GameDTO newGame)
        {
            await gamesManager.UpdateItem(gamesManager.GetItemsById(id).Result.FirstOrDefault(), newGame.toModel());
            return Ok(newPlayer);
        }*/
    }
}
