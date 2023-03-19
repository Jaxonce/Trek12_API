using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Stub
{
    public partial class StubData
    {
        private List<Turn> Turns = new()
        {
            //new Turn(),
            //new Turn(),
        };

        public class TurnsManager : ITurnsManager
        {
            private readonly StubData parent;

            public TurnsManager(StubData parent)
                => this.parent = parent;

            public Task<Turn?> AddItem(Turn? item)
                => parent.Turns.AddItem(item);

            public Task<bool> DeleteItem(Turn? item)
                => parent.Turns.DeleteItem(item);

            public Task<IEnumerable<Turn?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.Turns.GetItemsWithFilterAndOrdering(
                    t => true,
                    index, count,
                    orderingPropertyName, descending);

            public Task<int> GetNbItems()
                => Task.FromResult(parent.Turns.Count());

            public Task<Turn?> UpdateItem(Turn? oldItem, Turn? newItem)
                => parent.Turns.UpdateItem(oldItem, newItem);
        }
    }
}
