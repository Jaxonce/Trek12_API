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
        private List<Grille> grilles = new()
        {
            new Grille(new List<Case> {new Case(3), new Case(5), new Case(6), new Case(7), new Case(8), new Case(9),
            new Case(12), new Case(4), new Case(2), new Case(10), new Case(8), new Case(2),}),
            //new Grille(),
        };

        public class GrillesManager : IGrillesManager
        {
            private readonly StubData parent;

            public GrillesManager(StubData parent)
                => this.parent = parent;

            public Task<Grille?> AddItem(Grille? item)
                => parent.grilles.AddItem(item);

            public Task<bool> DeleteItem(Grille? item)
                => parent.grilles.DeleteItem(item);

            public Task<IEnumerable<Grille?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.grilles.GetItemsWithFilterAndOrdering(
                        c => true,
                        index, count,
                        orderingPropertyName, descending);

            public Task<int> GetNbItems()
                => Task.FromResult(parent.grilles.Count);

            public Task<Grille?> UpdateItem(Grille? oldItem, Grille? newItem)
                => parent.grilles.UpdateItem(oldItem,newItem);
        }
    }
}
