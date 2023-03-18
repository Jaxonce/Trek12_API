using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game
    {
        public int Id { get; set; }

        public TimeSpan Duration { get; set; }
        public DateOnly Date { get; set; }
        //public ReadOnlyCollection<Player> Players { get; private set; }
        //private List<Player> players = new();

        public ReadOnlyCollection<Turn> Turns { get; private set; }
        private List<Turn> turns = new();

        public ReadOnlyDictionary<Player, Grille> Grilles { get; private set; }
        private readonly Dictionary<Player, Grille> grilles = new Dictionary<Player, Grille>();

        public ReadOnlyDictionary<Player, int> Scores { get; private set; }
        private readonly Dictionary<Player, int> scores = new Dictionary<Player, int>();

        public GameMode GameMode { get; set; }

        public Player Player { get; set; }


        //public Game(TimeSpan duration, DateOnly date, Dictionary<Player,Grille> grilles, Dictionary<Player, int> scores, List<Turn> turns, GameMode gameMode,int id=0)
        //{
        //    Players = players.AsReadOnly();
        //    Duration = duration;
        //    Date = date;
        //    Grilles = new ReadOnlyDictionary<Player, Grille>(grilles);
        //    Scores = new ReadOnlyDictionary<Player, int>(scores);
        //    Turns = turns.AsReadOnly();
        //    GameMode = gameMode;
        //    Id = id;

        //}
        public Game(DateOnly date, Player owner, GameMode gameMode, int id = 0)
        {
            Date = date;
            Grilles = new ReadOnlyDictionary<Player, Grille>(grilles);
            Scores = new ReadOnlyDictionary<Player, int>(scores);
            Turns = new ReadOnlyCollection<Turn>(turns);
            grilles.Add(owner, new Grille());
            scores.Add(owner, 0);
            GameMode = gameMode;
            Id = id;
            Player = owner;
        }

        public bool AddPlayerToGame(Player player)
        {
            if(grilles.ContainsKey(player) == false && scores.ContainsKey(player) == false)
            {
                grilles.Add(player, new Grille());
                scores.Add(player, 0);
                return true;
            }
            return false;
        }

        public bool AddScoreToPlayer(Player player, int score)
        {
            if (grilles.ContainsKey(player) == true && scores.ContainsKey(player) == true)
            {
                scores[player] = score;
                return true;
            }
            return false;
        }

        public bool AddCaseValue(Player player, int value, int index)
        {
            if (grilles.ContainsKey(player) == true && scores.ContainsKey(player) == true)
            {
                return grilles[player].AddValueToCase(value, index);
            }
            return false;
        }

        public void AddTurn(Turn turn)
        {
            turns.Add(turn);
        }

        public void AddTime(TimeSpan time)
        {
            Duration = time;
        }
    }
}
