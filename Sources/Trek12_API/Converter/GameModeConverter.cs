using Model;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class GameModeConverter
    {
        public static GamemodeDTO toDTO(this GameMode gameMode)
        {
            return new GamemodeDTO()
            {
                Id = gameMode.Id,
                Name = gameMode.Name,
            };
        }

        public static GameMode toModel( this GamemodeDTO gamemode)
        {
            return new GameMode()
            {
                Id = gamemode.Id,
                Name = gamemode.Name
            };
        }
    }
}
