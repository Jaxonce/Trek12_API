using System;
using Model;
namespace DbDataManager
{
    public class StatsManager : IStatsManager
    {
        public Task<Stats?> AddItem(Stats? item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(Stats? item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Stats?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItems()
        {
            throw new NotImplementedException();
        }

        public Task<Stats?> UpdateItem(Stats? oldItem, Stats? newItem)
        {
            throw new NotImplementedException();
        }
    }
}

