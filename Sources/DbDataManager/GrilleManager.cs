using System;
using Model;
namespace DbDataManager
{
	public class GrilleManager: IGrillesManager
	{
        public Task<Grille?> AddItem(Grille? item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(Grille? item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grille?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItems()
        {
            throw new NotImplementedException();
        }

        public Task<Grille?> UpdateItem(Grille? oldItem, Grille? newItem)
        {
            throw new NotImplementedException();
        }
    }
}

