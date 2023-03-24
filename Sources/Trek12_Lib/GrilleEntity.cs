using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkLib
{
    public class GrilleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GrilleId { get; set; }
        public int NbChains { get; set; }
        public int NbZones { get; set; }
        public int MaxChain { get; set; }
        public int MaxZone { get; set; }
        public List<CaseEntity> Cases { get; set; }
    }
}
