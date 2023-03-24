using System;
using Model;
namespace DbDataManager
{
    public class TurnManager : ITurnsManager
    {
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

