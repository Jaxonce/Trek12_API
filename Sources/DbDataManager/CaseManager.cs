using System;
using Model;
namespace DbDataManager
{
	public class CaseManager: ICasesManager
	{

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

