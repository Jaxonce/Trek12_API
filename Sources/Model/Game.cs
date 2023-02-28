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
        public TimeSpan Duration { get; set; }
        public DateOnly Date { get; set; }
        public ReadOnlyCollection<Player> Players { get; private set; }
        private List<Player> players = new();

        public ReadOnlyCollection<Turn> Turns { get; private set; }
        private List<Turn> turns = new();

        public ReadOnlyDictionary<Player, Grille> Grilles { get; private set; }
        private readonly Dictionary<Player, Grille> grilles = new Dictionary<Player, Grille>();

        public ReadOnlyDictionary<Player, int> Scores { get; private set; }
        private readonly Dictionary<Player, int> scores = new Dictionary<Player, int>();

        public GameMode GameMode { get; set; }

        //public Grille Grille
        //{
        //    get => grille;
        //    private init
        //    {
        //        if (value == null)
        //            throw new ArgumentNullException("A grid can't be null for a game");
        //        grille = value;
        //    }
        //}
        //private Grille grille;

        public Game(TimeSpan duration, DateOnly date, Dictionary<Player,Grille> grilles, Dictionary<Player, int> scores, List<Turn> turns, GameMode gameMode)
        {
            Players = players.AsReadOnly();
            Duration = duration;
            Date = date;
            Grilles = new ReadOnlyDictionary<Player, Grille>(grilles);
            Scores = new ReadOnlyDictionary<Player, int>(scores);
            Turns = turns.AsReadOnly();
            GameMode = gameMode;

        }
    }
}
