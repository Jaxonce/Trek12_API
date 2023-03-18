using Model;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class TurnConverter
    {
        public static TurnDTO toDTO(this Turn turn)
        {
            return new TurnDTO()
            {
                Id = turn.Id,
                diceValue1 = turn.DiceValue1,
                diceValue2 = turn.DiceValue2,
            };
        }
    }
}
