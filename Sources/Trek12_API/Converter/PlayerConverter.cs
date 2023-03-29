using System.Text.Json.Serialization;
using Model;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class PlayerConverter
    {
        public static PlayerDTO toDTO(this Player player)
        {
            return new PlayerDTO()
            {
                Pseudo = player.Pseudo,
                Stats = player.Stats.toDTO(),
            };
        }

        public static Player toModel(this PlayerDTO player)
        {
            return new Player(player.Pseudo, player.Stats.toModel());

        }

        public static IEnumerable<Player> toModels(this IEnumerable<PlayerDTO?> players)
        {
            return players.Select(c => c.toModel());
        }

        public static IEnumerable<PlayerDTO> toDTOs(this IEnumerable<Player?> players)
        {
            return players.Select(c => c.toDTO());
        }
    }
}
