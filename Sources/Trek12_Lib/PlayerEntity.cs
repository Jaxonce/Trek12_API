using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkLib
{
    public class PlayerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public int NbWin { get; set; }
        public int NbPlayed { get; set; }
        public int MaxZone { get; set; }
        public int MaxChain { get; set; }
        public int MaxPoints { get; set; }
        public int NbPoints { get; set; }
    }
}

