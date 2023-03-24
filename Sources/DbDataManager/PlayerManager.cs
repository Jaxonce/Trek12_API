using System;
using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;

namespace DbDataManager
{
	public class PlayerManager: IPlayersManager
	{
        private TrekContext trekContext;

        public async Task<Player?> AddItem(Player? item)
        {
            if (item == null)
            {
                return null;

            }
            var addItem = await trekContext.AddAsync<Player>(item);
            await trekContext.SaveChangesAsync();
            return addItem.Entity;
        }

        public async Task<bool> DeleteItem(Player? item)
        {
            if (item == null)
            {
                return false;
            }
            var deleteItem = trekContext.Remove<Player>(item);
            trekContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Player?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {

            //IEnumerable<Player> players = trekContext.Players.Skip(index * count)
            //                                                      .Take(count)
            //                                                      .OrderBy(champions => orderingPropertyName)
            //                                                      .Select(champions => champions.ToPoco());
            //return players;
            throw new NotImplementedException();
        }

        private Func<Player, string, bool> filterByPseudo = (player, substring) => player.Pseudo.Contains(substring, StringComparison.InvariantCultureIgnoreCase);
        private Func<Player, int, bool> filterById = (player, id) => player.Id.Equals(id);

        public async Task<IEnumerable<Player?>> GetItemsById(int id)
        {
            //return trekContext.Players.GetItemsWithFilterAndOrdering<Player>(player => filterById(player, id), 0, 1);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Player?>> GetItemsByPseudo(string charPseudo)
        {
            //return trekContext.Players.GetItemsWithFilterAndOrdering<Player>(player => filterByPseudo(player, charPseudo), 0, trekContext.Players.Count());
            throw new NotImplementedException();
        }

        public Task<int> GetNbItems()
        {
            return Task.FromResult(trekContext.Players.Count());
        }

        public Task<int> GetNbItemsByPseudo(string charPseudo)
        {
            throw new NotImplementedException();
        }

        public Task<Player?> UpdateItem(Player? oldItem, Player? newItem)
        {
            //return trekContext.Players.UpdateItem(oldItem, newItem);
            throw new NotImplementedException();
        }
    }
}

