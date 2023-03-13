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
        private List<Game> games = new()
        {
            //new Game(new TimeSpan(1,20,0),new DateOnly(2023,06,03)),
            //new Game(),
        };

        public class GamesManager : IGamesManager
        {
            private readonly StubData parent;

            public GamesManager(StubData parent)
                => this.parent = parent;

            public Task<Game?> AddItem(Game? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Game? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Game?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<Game?> UpdateItem(Game? oldItem, Game? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
