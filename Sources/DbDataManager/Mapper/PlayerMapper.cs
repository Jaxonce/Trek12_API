using System;
using EntityFrameWorkLib;
using Model;
namespace DbDataManager.Mapper
{
	public static class PlayerMapper
	{
		public static Player ToPoco(this PlayerEntity player)
		{
			return new Player(player.Pseudo, new Stats { player.NbWin, player.NbPlayed, player.MaxChain, player.MaxZone, player.MaxPoints }, player.PlayerId);
		}
	}
}

