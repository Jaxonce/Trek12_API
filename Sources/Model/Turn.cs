using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Turn
    {
        public int Id { get; set; }

        public int DiceValue1
        {
            get => diceValue1;
            set
            {
                if (value > 6)
                {
                    throw new ArgumentException("a Cell must have a value lower or equal to 12");
                }
                diceValue1 = value;
            }
        }
        private int diceValue1;

        public int DiceValue2
        {
            get => diceValue2;
            set
            {
                if (value > 6)
                {
                    throw new ArgumentException("a Cell must have a value lower or equal to 12");
                }
                diceValue2 = value;
            }
        }
        private int diceValue2;

        public Turn(int Id, int diceValue1, int diceValue2)
        {
            this.Id = Id;
            DiceValue1 = diceValue1;
            DiceValue2 = diceValue2;
        }
    }
}
