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

        //[HttpGet]
        //public async Task<IActionResult> Get(int index, int count, string? order = null, bool descending = false )
        //{
        //    //si count > nb_max
        //    //_logger.LogWarning + reaffecter count
        //    //var list = await playersManager.GetItems(0, await playersManager.GetNbItems(), order, descending);
        //    var list = await playersManager.GetItems(index, count, order, descending);
        //    return Ok(list.Select(player => player?.toDTO()));

        //}

        [HttpGet]
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


        [HttpGet("players/{pseudo}")]
        public async Task<IActionResult> GetByPseudo([FromRoute] string pseudo, int index, int count, string? order = null, bool descending = false)
        {
            var player = await playersManager.GetItemsByPseudo(pseudo, index, count, order, descending);
            return Ok(player?.toDTOs());
        }

        [HttpGet("players/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, int index, int count, string? order = null, bool descending = false)
        {
            var player = await playersManager.GetItemsById(id);
            return Ok(player?.toDTOs());
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlayerDTO player)
        {
            Player playerToCreate = player.toModel();
            await playersManager.AddItem(playerToCreate);
            return Ok(playerToCreate?.toDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(PlayerDTO player)
        {
            var playerToDelete = player.toModel();
            //faire recherche pour voir si player existe
            await playersManager.DeleteItem(playerToDelete);
            return Ok();
        }

        [HttpDelete("pseudo/{pseudo}")]
        public async Task<IActionResult> DeleteByPseudo(PlayerDTO player)
        {
            var playerToDelete = player.toModel();
            //faire recherche pour voir si player existe
            await playersManager.DeleteItem(playerToDelete);
            return Ok();
        }


        [HttpPut(Name= "UpdatePlayer")]
        public async Task<IActionResult> Update(int id, PlayerDTO newPlayer)
        {
            await playersManager.UpdateItem(playersManager.GetItems(0,1).Result.FirstOrDefault(), newPlayer.toModel());
            return Ok(newPlayer);
        }
/*
        [HttpPut("name=UpdateMaxChain")]
        public async Task<IActionResult> UpdateMaxChain(int newMaxChain, PlayerDTO playerOld)
        {
            Player playerOldModel = playerOld.toModel();
            Player playerNew = new Player(playerOldModel.Pseudo, playerOldModel.Stats);
            playerNew.Stats.MaxChain = newMaxChain;
            await playersManager.UpdateItem(playerOldModel, playerNew);
            return Ok(playerNew);
        }

        [HttpPut("name=UpdateMaxPoints")]
        public async Task<IActionResult> UpdateMaxPoints(int newMaxPoints, PlayerDTO playerOld)
        {
            Player playerOldModel = playerOld.toModel();
            Player playerNew = new Player(playerOldModel.Pseudo, playerOldModel.Stats);
            playerNew.Stats.MaxPoints = newMaxPoints;
            await playersManager.UpdateItem(playerOldModel, playerNew);
            return Ok(playerNew);
        }

        [HttpPut("name=UpdateMaxZone")]
        public async Task<IActionResult> UpdateMaxZone(int newMaxZone, PlayerDTO playerOld)
        {
            Player playerOldModel = playerOld.toModel();
            Player playerNew = new Player(playerOldModel.Pseudo, playerOldModel.Stats);
            playerNew.Stats.MaxZone = newMaxZone;
            await playersManager.UpdateItem(playerOldModel, playerNew);
            return Ok(playerNew);
        }

        [HttpPut("name=UpdateWin")]
        public async Task<IActionResult> UpdateWin(int newMaxZone, PlayerDTO playerOld)
        {
            Player playerOldModel = playerOld.toModel();
            Player playerNew = new Player(playerOldModel.Pseudo, playerOldModel.Stats);
            playerNew.AddWin();
            await playersManager.UpdateItem(playerOldModel, playerNew);
            return Ok(playerNew);
        }*/
    }
}
