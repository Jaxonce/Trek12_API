using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Grille
    {
        public int NbChaine { get; set; }
        public int NbZone { get; set; }
        public int MaxChaine { get; set; }
        public int MaxZone { get; set; }

        public ReadOnlyCollection<Case> Cases { get; private set; }
        private List<Case> cases = new();


        public Grille(List<Case> cases)
        {
            Cases = cases.AsReadOnly();
        }
    }
}
