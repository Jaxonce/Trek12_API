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
        private List<Case> Cases = new()
        {
            new Case(1),
            new Case(12),
            new Case(4),
            new Case(9),
            new Case(8),
            new Case(6),
        };

        public class CasesManager : ICasesManager
        {
            private readonly StubData parent;

            public CasesManager(StubData parent)
                => this.parent = parent;

            public Task<Case?> AddItem(Case? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Case? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Case?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<Case?> UpdateItem(Case? oldItem, Case? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
