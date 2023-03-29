using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stub.StubData;

namespace Stub
{
    public partial class StubData
    {
        private List<Player> players = new()
        {
            new Player("Aurelien", 0),
            new Player("Theo",1),
            new Player("Maxence",2),
            new Player("Zakariya",3),
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
                => Task.FromResult(parent.players.Count());

            public Task<Player?> UpdateItem(Player? oldItem, Player? newItem)
                => parent.players.UpdateItem(oldItem, newItem);

            private Func<Player, string, bool> filterByPseudo = (player, substring) => player.Pseudo.Contains(substring, StringComparison.InvariantCultureIgnoreCase);
            private Func<Player, int, bool> filterById = (player, id) => player.Id.Equals(id);




            public Task<IEnumerable<Player?>> GetItemsByPseudo(string charPseudo)
                => parent.players.GetItemsWithFilterAndOrdering<Player>(player => filterByPseudo(player, charPseudo), 0, parent.players.Count());

            public Task<int> GetNbItemsByPseudo(string charPseudo)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Player?>> GetItemsById(int id)
            {
                return parent.players.GetItemsWithFilterAndOrdering<Player>(player => filterById(player, id), 0, 1);
            }
        }
    }
}
