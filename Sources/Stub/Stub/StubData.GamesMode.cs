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
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(GameMode? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<GameMode?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<GameMode?> UpdateItem(GameMode? oldItem, GameMode? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
