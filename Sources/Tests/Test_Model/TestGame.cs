using System;
using Model;

namespace Test_Model
{
	public class TestGame
	{

        public static IEnumerable<object[]> GameData_init()
        {
            yield return new object[]
            {
                true,
                new Player[]
                {
                    new Player("Player 1",2)
                },
                new Game(new Player("Player1",2),new GameMode(1,"Classique")),
                new Player("Player1",2)
            };
        }

        [Theory]
        [MemberData(nameof(GameData_init))]
        public void AddPlayerToGame_Should_Return_Correct_Result(bool expectedResult,
                                                                 IEnumerable<Player> expectedPlayers,
                                                                 Game game,
                                                                 Player playerToBeAdded)
        {
            // Act
            bool result = game.AddPlayerToGame(playerToBeAdded);
            Console.WriteLine(result);

            // Assert
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedPlayers.Count(), game.Players.Count());
            Assert.All(expectedPlayers, p => game.Players.Contains(p));
        }
    }
}

