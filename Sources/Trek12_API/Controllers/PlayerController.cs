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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //si count > nb_max
            //_logger.LogWarning + reaffecter count
            var list = await playersManager.GetItems(0, await playersManager.GetNbItems());
            return Ok(list.Select(player => player?.toDTO()));
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var list = await playersManager.GetItems(0, await playersManager.GetNbItems());
            return Ok(list.Select(player => player?.toDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlayerDTO player)
        {
            Player playerToCreate = player.toModel();
            await playersManager.AddItem(playerToCreate);
            return Ok(playerToCreate?.toDTO());
        }

        [HttpDelete("{player}")]
        public async Task<IActionResult> Delete(PlayerDTO player)
        {
            var playerToDelete = player.toModel();
            //faire recherche pour voir si player existe
            await playersManager.DeleteItem(playerToDelete);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(string pseudo, PlayerDTO playerOld)
        {
            Player playerOldModel = playerOld.toModel();
            Player playerNew = new Player(pseudo, playerOldModel.Stats);
            await playersManager.UpdateItem(playerOldModel, playerNew);
            return Ok(playerNew);
        }
    }
}
