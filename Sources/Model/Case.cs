using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Case
    {
        public int Id { get; set; }
        public int Valeur
        {
            get => valeur;
            set
            {
                //pas évolutif car case dangereuse c'est 6 MAX
                if (value > 12 || value < 0)
                {
                    throw new ArgumentException("a Case must have a value lower or equal to 12");
                }
                valeur = value;
            }
        }
        private int valeur;

        public Case()
        {

        }

        public Case(int valeur)
        {
            Valeur = valeur;
        }

        public void AddValue(int valeur)
        {
            this.valeur = valeur;
        }
    }
}
