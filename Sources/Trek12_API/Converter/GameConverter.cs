using Model;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class GameConverter
    {
        public static GameDTO toDTO(this Game game) 
        {
            var gameDTO = new GameDTO();
            gameDTO.Duration = game.Duration;
            gameDTO.Date = game.Date;
            gameDTO.Turns = new List<TurnDTO>();
            foreach (var turn in game.Turns)
            {
                gameDTO.Turns.Add(turn.toDTO());
            }
            gameDTO.Grilles = new Dictionary<PlayerDTO, GrilleDTO>();
            foreach ( var grille in game.Grilles)
            {
                gameDTO.Grilles.Add(grille.Key.toDTO(), grille.Value.toDTO());
            }
            gameDTO.Scores = new Dictionary<PlayerDTO, int>();
            foreach ( var score in game.Scores)
            {
                gameDTO.Scores.Add(score.Key.toDTO(), score.Value);
            }
            gameDTO.Players = new List<PlayerDTO>();
            foreach ( var player in game.Players) 
                { 
                gameDTO.Players.Add(player.toDTO()); 
            }
            gameDTO.GameMode = new GamemodeDTO() {
                Id = game.GameMode.Id,
                Name = game.GameMode.Name
            };
            return gameDTO;
        }

        public static Game toModel(this GameDTO gameDTO)
        {
            {
                var turnsList = new List<Turn>();
                foreach (var turn in gameDTO.Turns)
                {
                    turnsList.Add(turn.toModel());
                }

                var playersList = new List<Player>();
                foreach (var player in gameDTO.Players)
                {
                    playersList.Add(player.toModel());
                }

                var grillesDict = new Dictionary<Player, Grille>();
                foreach (var (key, value) in gameDTO.Grilles)
                {
                    grillesDict.Add(key.toModel(), value.toModel());
                }

                var scoresDict = new Dictionary<Player, int>();
                foreach (var (key, value) in gameDTO.Scores)
                {
                    scoresDict.Add(key.toModel(), value);
                }

                var game = new Game(gameDTO.Id, gameDTO.Duration, gameDTO.Date, playersList, turnsList, grillesDict, scoresDict, gameDTO.GameMode.toModel());
                return game;
            }
        }
    }
}
