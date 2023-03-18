using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Stats
    {
        public int Id { get; set; }
        public int NbWin { get; set; } = 0;
        public int NbPlayed { get; set; } = 0;
        public int MaxChain { get; set; } = 0;
        public int MaxZone { get; set; } = 0;
        public int MaxPoints { get; set; } = 0;


		public Stats()
        {}

        public override string ToString()
            => $"{NbWin} {NbPlayed} {MaxChain} {MaxZone} {MaxZone}";
    }
}
