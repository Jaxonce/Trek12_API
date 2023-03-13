using Model;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class StatsConverter
    {
        public static StatsDTO toDTO(this Stats stats)
        {
            return new StatsDTO()
            {
               NbPlayed = stats.NbPlayed,
               NbWin = stats.NbWin,
               MaxChain = stats.MaxChain,
               MaxPoints = stats.MaxPoints,
               MaxZone = stats.MaxZone,
            };
        }

        public static Stats toModel(this StatsDTO stats)
        {
            return new Stats()
            {
                NbPlayed = stats.NbPlayed,
                NbWin = stats.NbWin,
                MaxChain = stats.MaxChain,
                MaxPoints = stats.MaxPoints,
                MaxZone = stats.MaxZone,
            };
        }

        public static IEnumerable<Stats> toModels(this IEnumerable<StatsDTO?> stats)
        {
            return stats.Select(c => c.toModel());
        }

        public static IEnumerable<StatsDTO> toDTOs(this IEnumerable<Stats?> stats)
        {
            return stats.Select(c => c.toDTO());
        }
    }
}
