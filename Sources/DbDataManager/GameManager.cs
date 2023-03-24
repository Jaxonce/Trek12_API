using System;
using EntityFrameWorkLib;
using Model;
using System.Linq;
using Shared;
namespace DbDataManager
{
	public class GameManager: IGamesManager
	{
        private TrekContext trekcontext;

        public Task<bool> AddCaseValueToPlayer(int idGame, int idPlayer, int value, int index)
        {
            throw new NotImplementedException();
        }

        public async Task<Game?> AddItem(Game? item)
        {
            if (item == null)
            {
                return null;

            }
            var addItem = await trekcontext.AddAsync<Game>(item);
            await trekcontext.SaveChangesAsync();
            return addItem.Entity;
        }

        public Task<bool> AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddScoreToPlayer(int idGame, int idPlayer, int score)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTime(TimeSpan time)
        {
            var game = trekcontext.Game.FirstOrDefault();
            if (game == null)
            {
                return Task.FromResult(false);
            }
            game.AddTime(time);
            return Task.FromResult(true);
        }

        public Task<bool> AddTurn(Turn turn)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(Game? item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNbItems()
        {
            throw new NotImplementedException();
        }

        public Task<Game?> UpdateItem(Game? oldItem, Game? newItem)
        {
            throw new NotImplementedException();
        }
    }
}

