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

        public DateTime Date { get; set; }

        public ReadOnlyCollection<Player> Players { get; private set; }
        private List<Player> players;

        public ReadOnlyCollection<Turn> Turns { get; private set; }
        private List<Turn> turns;

        public ReadOnlyDictionary<Player, Grille> Grilles { get; private set; }
        private readonly Dictionary<Player, Grille> grilles;

        public ReadOnlyDictionary<Player, int> Scores { get; private set; }
        private readonly Dictionary<Player, int> scores;

        public GameMode GameMode { get; set; }


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
        public Game(DateTime date, Player ?owner, GameMode gameMode, int id = 0)
        {
            Date = date;

            // Creation list de player + ajout d'une player owner dans la liste
            players = new();
            Players = new ReadOnlyCollection<Player>(players);
            players.Add(owner);

            turns = new();
            Turns = new ReadOnlyCollection<Turn>(turns);

            if(grilles != null)
            {
                Grilles = new ReadOnlyDictionary<Player, Grille>(new Dictionary<Player, Grille>());
                grilles.Add(owner, new Grille());
            }

            if(scores != null)
            {
                Scores = new ReadOnlyDictionary<Player, int>(new Dictionary<Player, int>());
                scores.Add(owner, 0);
            } 
            GameMode = gameMode;
            Id = id;
        }

        public Game(int id, ReadOnlyCollection<Player> players, GameMode gameMode)
        {
            Id = id;
            GameMode = gameMode;
        }

        public Game(int id, TimeSpan duration, DateTime date, List<Player> players, List<Turn> turns,  Dictionary<Player, Grille> grilles,  Dictionary<Player, int> scores, GameMode gameMode)
        {
            Id = id;
            Duration = duration;
            Date = date;
            this.players = players;
            Players = new ReadOnlyCollection<Player>(this.players);
            this.turns = turns;
            Turns = new ReadOnlyCollection<Turn>(this.turns);
            this.grilles = grilles;
            Grilles = new ReadOnlyDictionary<Player, Grille>(this.grilles);
            this.scores = scores;
            Scores = new ReadOnlyDictionary<Player, int>(this.scores);
            GameMode = gameMode;
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

        public bool AddCaseValueToPlayer(Player player, int value, int index)
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
