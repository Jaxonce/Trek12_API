using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkLib
{
    public class GameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateOnly Date { get; set; }
        public int NbPlayers { get; set; }
        public string Name { get; set; }
        //public ICollection<PlayerEntity> NbPoints { get; set; }
    }
}
