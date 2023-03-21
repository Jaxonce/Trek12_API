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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreId { get; set; }
        public int NbPoints { get; set; }

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public GameEntity Game { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public PlayerEntity Player { get; set; }
    }
}
