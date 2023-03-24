using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkLib
{
    public class ParticipateEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("GrilleId")]
        public int GrilleId { get; set; }
        public GrilleEntity Grille { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("GameId")]
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}
