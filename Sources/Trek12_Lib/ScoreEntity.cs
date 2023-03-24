using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkLib
{
    public class ScoreEntity
    {
        public int NbPointsTotal { get; set; }
        [ForeignKey("GameId")]
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}
