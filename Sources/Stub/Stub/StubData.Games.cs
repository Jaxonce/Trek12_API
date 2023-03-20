using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public partial class StubData
    {
        private List<Game> games = new()
        {
            new Game(new DateOnly(2023,06,03), new Player("test1"),new GameMode("gamemode test1")),
            new Game(new DateOnly(2023,06,03), new Player("test2"),new GameMode("gamemode test2")),
            new Game(new DateOnly(2023,06,03), new Player("test3"),new GameMode("gamemode test3")),
            new Game(new DateOnly(2023,06,03), new Player("test4"),new GameMode("gamemode test4")),
            new Game(new DateOnly(2023,06,03), new Player("test5"),new GameMode("gamemode test5")),

        };

        public class GamesManager : IGamesManager
        {
            private readonly StubData parent;

            public GamesManager(StubData parent)
                => this.parent = parent;

            public Task<bool> IGamesManager.AddCaseValueToPlayer(int idGame, int idPlayer, int value, int index)
            {
                var game = parent.games.FirstOrDefault(g => g.Id == idGame);
                if(game == null)
                {
                    return Task.FromResult(false);
                }
                var player = game.Players.FirstOrDefault(p => p.Id == idPlayer);
                if(player == null)
                {
                    return Task.FromResult(false);
                }
                game.AddCaseValueToPlayer(player, value, index);
                return Task.FromResult(true);
            }

            public Task<bool> IGamesManager.AddPlayer(Player player)
            {
                var game = parent.games.FirstOrDefault();
                if(game == null)
                {
                    return Task.FromResult(false) ;
                }
                game.Players.AddItem(player);
                return Task.FromResult(true);
            }

            public Task<bool> IGamesManager.AddScoreToPlayer(int idGame, int idPlayer, int score)
            {
                var game = parent.games.FirstOrDefault(g => g.Id == idGame);
                if( game == null)
                {
                    return Task.FromResult(false);
                }
                var player = game.Players.FirstOrDefault(p => p.Id == idPlayer);
                if(player == null)
                {
                    return Task.FromResult(false);
                }
                game.AddScoreToPlayer(player, score);
                return Task.FromResult(true);
            }

            public Task<bool> IGamesManager.AddTime(TimeSpan time)
            {
                var game = parent.games.FirstOrDefault();
                if (game == null)
                {
                    return Task.FromResult(false);
                }
                game.AddTime(time);
                return Task.FromResult(true);
            }

            public Task<bool> IGamesManager.AddTurn(Turn turn)
            {
                var game = parent.games.FirstOrDefault();
                if( game == null)
                {
                    return Task.FromResult(false);
                }
                game.AddTurn(turn);
                return Task.FromResult(true);
            }

            public Task<Game?> IGenericDataManager<Game?>.AddItem(Game? item)
                => parent.games.AddItem(item);

            public Task<bool> IGenericDataManager<Game?>.DeleteItem(Game? item)
                => parent.games.DeleteItem(item);

            public Task<IEnumerable<Game?>> IGenericDataManager<Game?>.GetItems(int index, int count, string? orderingPropertyName, bool descending)
                => parent.games.GetItemsWithFilterAndOrdering(
                    g => true,
                    index, count,
                    orderingPropertyName, descending);

            public Task<int> IGenericDataManager<Game?>.GetNbItems()
                => Task.FromResult(parent.games.Count());

            public Task<Game?> IGenericDataManager<Game?>.UpdateItem(Game? oldItem, Game? newItem)
                => parent.games.UpdateItem(oldItem, newItem);
        }
    }
}
