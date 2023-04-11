using System;
namespace EntityFrameWorkLib
{
	public class StatsEntity
	{
        public int Id { get; set; }
        public int NbWin { get; set; }
        public int NbPlayed { get; set; }
        public int MaxChain { get; set; }
        public int MaxZone { get; set; }
        public int MaxPoints { get; set; }

        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}

