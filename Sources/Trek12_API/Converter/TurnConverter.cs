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

        public static Turn toModel(this TurnDTO turnDTO)
        {
            return new Turn(turnDTO.Id, turnDTO.diceValue1, turnDTO.diceValue2);
        }

        public static IEnumerable<Turn> toModels(this IEnumerable<TurnDTO> turns)
        {
            var turnsList = new List<Turn>();
            foreach(var turn in turns)
            {
                turnsList.Add(turn.toModel());
            }
            return turnsList;
        }
    }
}
