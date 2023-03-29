using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Stub;
using Trek12_API.Converter;
using Trek12_API.DTO;

namespace Trek12_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private StubData.PlayersManager playersManager { get; set; } = new StubData.PlayersManager(new StubData());

        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }


        [HttpGet ("/AllPlayers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await playersManager.GetItems(0, playersManager.GetNbItems().Result);
                return Ok(list);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpGet("/PlayerByPseudo/{pseudo}")]
        
        public async Task<IActionResult> GetByPseudo([FromRoute] string pseudo)
        {
            var player = await playersManager.GetItemsByPseudo(pseudo);
            return Ok(player?.toDTOs());
        }

        [HttpGet ("/PlayerById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await playersManager.GetItemsById(id);
            if (player == null) return NotFound("Joueur non trouvé"); 
            return Ok(player?.toDTOs());
        }

        [HttpPost(Name= "AddPlayer")]
        public async Task<IActionResult> Post(PlayerDTO player)
        {
            Player playerToCreate = player.toModel();
            await playersManager.AddItem(playerToCreate);
            return Ok(playerToCreate?.toDTO());
        }

        [HttpDelete(Name= "DeletePlayerById")]
        public async Task<IActionResult> Delete(int idPlayer)
        {
            var playerToDelete = await playersManager.GetItemsById(idPlayer);
            if(playerToDelete == null)
            {
                return NotFound("Joueur non trouvé");
            }

            if(!await playersManager.DeleteItem(playerToDelete.SingleOrDefault(p => p.Id == idPlayer)))
            {
                return BadRequest("Erreur lors de la suppression du joueur");
            }

            return Ok("Joueur bien supprimé");
        }


        [HttpPut(Name= "UpdatePlayerById")]
        public async Task<IActionResult> Update(int id, PlayerDTO newPlayer)
        {
            await playersManager.UpdateItem(playersManager.GetItems(0,1).Result.FirstOrDefault(), newPlayer.toModel());
            return Ok(newPlayer);
        }
    }
}
