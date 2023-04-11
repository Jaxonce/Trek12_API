using System;
using EntityFrameWorkLib;
using Model;

namespace DbDataManager.Mapper
{
	public static class PlayerMapper
	{
        public static Player ToModel(this PlayerEntity playerEntity)
        {
            Player player = new Player(playerEntity.Pseudo, playerEntity.stats.ToModel(), playerEntity.PlayerId);
            return player;
        }

        public static PlayerEntity ToEntity(this Player playerModel)
        {
            PlayerEntity player = new PlayerEntity
            {
                PlayerId = playerModel.Id,
                Pseudo = playerModel.Pseudo,
                stats = playerModel.Stats.ToEntity(),
               
            };
            player.stats.PlayerId = playerModel.Id;
            return player;
        }
       
    }
}

