using System;
using EntityFrameWorkLib;
using Model;

namespace DbDataManager.Mapper
{
	public static class StatsMapper
	{
        public static Stats ToModel(this StatsEntity statsEntity)
        {
            var stats = new Stats
            {
                Id = statsEntity.Id,
                NbWin = statsEntity.NbWin,
                NbPlayed = statsEntity.NbPlayed,
                MaxZone = statsEntity.MaxZone,
                MaxChain = statsEntity.MaxChain,
                MaxPoints = statsEntity.MaxPoints
            };
            return stats;
        }

        public static StatsEntity ToEntity(this Stats statsModel)
        {
            var stats = new StatsEntity
            {
                Id = statsModel.Id,
                MaxChain = statsModel.MaxChain,
                MaxPoints = statsModel.MaxPoints,
                MaxZone = statsModel.MaxZone,
                NbPlayed = statsModel.NbPlayed,
                NbWin = statsModel.NbWin,

            };
            return stats;
        }

    }
}

