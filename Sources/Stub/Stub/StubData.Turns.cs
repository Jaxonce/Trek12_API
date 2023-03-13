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
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Turn? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Turn?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<Turn?> UpdateItem(Turn? oldItem, Turn? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
