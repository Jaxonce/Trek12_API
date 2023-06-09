﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkLib
{
    public class CaseEntity 
    { 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId { get; set; }
        [ForeignKey("GrilleId")]
        public int GrilleId { get; set; }
        public GrilleEntity Grille { get; set; }
        public int Value { get; set; }
    }
}
