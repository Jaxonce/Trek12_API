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
        private List<Player> players = new()
        {
            new Player("Aurelien"),
            new Player("Theo"),
            new Player("Maxence"),
            new Player("Zakariya"),
        };

        public class PlayersManager : IPlayersManager
        {
            private readonly StubData parent;

            public PlayersManager(StubData parent)
                => this.parent = parent;

            public Task<Player?> AddItem(Player? item)
                => parent.players.AddItem(item);

            public Task<bool> DeleteItem(Player? item)
             => parent.players.DeleteItem(item);

            public Task<IEnumerable<Player?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            => parent.players.GetItemsWithFilterAndOrdering(
                        c => true,
                        index, count,
                        orderingPropertyName, descending);

            public Task<int> GetNbItems()
                => Task.FromResult(parent.players.Count);

            public Task<Player?> UpdateItem(Player? oldItem, Player? newItem)
             => parent.players.UpdateItem(oldItem, newItem);
        }
    }
}
