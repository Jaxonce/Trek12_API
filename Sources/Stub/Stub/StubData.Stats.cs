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
        private List<Stats> stats = new()
        {
            new Stats(),
            //new Stat(),
        };

        public class StatsManager : IStatsManager
        {
            private readonly StubData parent;

            public StatsManager(StubData parent)
                => this.parent = parent;

            public Task<Stats?> AddItem(Stats? item)
                => parent.stats.AddItem(item);

            public Task<bool> DeleteItem(Stats? item)
                => parent.stats.DeleteItem(item);

            public Task<IEnumerable<Stats?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            => parent.stats.GetItemsWithFilterAndOrdering(
                        c => true,
                        index, count,
                        orderingPropertyName, descending);

            public Task<int> GetNbItems()
                => Task.FromResult(parent.stats.Count());

            public Task<Stats?> UpdateItem(Stats? oldItem, Stats? newItem)
                => parent.stats.UpdateItem(oldItem, newItem);
        }
    }
}
