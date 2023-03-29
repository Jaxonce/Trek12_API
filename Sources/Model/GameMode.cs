using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameMode
    {
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("A GameMode's name cannot be null");
                }
                name = value;
            }
        }
        private string name = "";

        public GameMode(int id= 0,string name = "Classique")
        {
            this.Id = id;
            this.Name = name;
            
        }
    }
}
