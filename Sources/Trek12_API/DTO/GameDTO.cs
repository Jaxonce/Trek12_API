using Model;
using System.Collections.ObjectModel;

namespace Trek12_API.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateOnly Date { get; set; }
        public List<TurnDTO> Turns { get; set; }
        public Dictionary<PlayerDTO, GrilleDTO> Grilles { get; set; }
        public Dictionary<PlayerDTO, int> Scores { get; set; }
        public GamemodeDTO GameMode { get; set; }
        public PlayerDTO Player { get; set; }

        public GameDTO(int id, DateOnly date, PlayerDTO owner, GamemodeDTO gameMode)
        {
            Date = date;
            Grilles = new Dictionary<PlayerDTO, GrilleDTO>();
            Scores = new Dictionary<PlayerDTO, int>();
            Turns = new List<TurnDTO>();
            Grilles.Add(owner, new GrilleDTO());
            Scores.Add(owner, 0);
            GameMode = gameMode;
            Id = id;
            Player = owner;
        }
    }
}
