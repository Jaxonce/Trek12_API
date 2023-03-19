using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public partial class StubData
    {
        private List<GameMode> GamesMode = new()
        {
            //new GameMode(),
            //new GameMode(),
        };

        public class GamesModeManager : IGamesModeManager
        {
            private readonly StubData parent;

            public GamesModeManager(StubData parent)
                => this.parent = parent;

            public Task<GameMode?> AddItem(GameMode? item)
                => parent.GamesMode.AddItem(item);

            public Task<bool> DeleteItem(GameMode? item)
                => parent.GamesMode.DeleteItem(item);

            public Task<IEnumerable<GameMode?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.GamesMode.GetItemsWithFilterAndOrdering(
                    g => true,
                    index, count,
                    orderingPropertyName, descending);

            public Task<int> GetNbItems()
                => Task.FromResult(parent.GamesMode.Count());

            public Task<GameMode?> UpdateItem(GameMode? oldItem, GameMode? newItem)
                => parent.GamesMode.UpdateItem(oldItem, newItem);
        }
    }
}
