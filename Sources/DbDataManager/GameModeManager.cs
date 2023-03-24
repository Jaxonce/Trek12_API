using System;
using Model;
namespace DbDataManager
{
	public class GameModeManager: IGamesModeManager
	{

        public Task<GameMode?> AddItem(GameMode? item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(GameMode? item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameMode?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItems()
        {
            throw new NotImplementedException();
        }

        public Task<GameMode?> UpdateItem(GameMode? oldItem, GameMode? newItem)
        {
            throw new NotImplementedException();
        }
    }
}

