using System;
using EntityFrameWorkLib;
using Model;
using DbDataManager.Mapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.SqlTypes;

namespace DbDataManager
{
	public class PlayersManager : IPlayersManager
	{
        private TrekContext trekContext;

        public async Task<Player?> AddItem(Player? item)
        {
            if (item == null)
            {
                return null;

            }
            var player = await trekContext.AddAsync<Player>(item);
            await trekContext.SaveChangesAsync();
            return player.Entity;
        }
        public async Task<bool> DeleteItem(Player? item)
        {
            if (item == null)
            {
                return false;
            }
            var deleteItem = trekContext.Remove<Player>(item);
            await trekContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Player?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
        {
            
            IEnumerable<Player> players = trekContext.Players.Skip(index * count)
                                                                  .Take(count)
                                                                  .OrderBy(players => orderingPropertyName)
                                                                  .Select(players => players.ToModel());
            
            return players;
        }
        public Task<IEnumerable<Player?>> GetItemsById(int id)
        {
            return trekContext.Players.Select(player => player.ToModel()).GetItemsWithFilterAndOrdering(player => filterById(player, id),0,1);
        }
        private Func<Player, int, bool> filterById = (player, id) => player.Id.Equals(id);


        public Task<IEnumerable<Player?>> GetItemsByPseudo(string charPseudo)
        {
                return trekContext.Players.Select(player => player.ToModel()).GetItemsWithFilterAndOrdering<Player>(player => filterByPseudo(player, charPseudo), 0, trekContext.Players.Count());
        }
        private Func<Player, string, bool> filterByPseudo = (player, substring) => player.Pseudo.Contains(substring, StringComparison.InvariantCultureIgnoreCase);


        public Task<int> GetNbItems()
        {
            return Task.FromResult(trekContext.Players.Count());
        }

        public Task<int> GetNbItemsByPseudo(string charPseudo)
        {
            return trekContext.Players.Select(player => player.ToModel()).GetNbItemsWithFilter(player => filterByPseudo(player, charPseudo));
        }

        public Task<Player?> UpdateItem(Player? oldItem, Player? newItem)
        {
            if (oldItem == null || newItem == null) return Task.FromResult<Player?>(default(Player));

            if (!trekContext.Players.Select(player => player.ToModel()).Contains(oldItem))
            {
                return Task.FromResult<Player?>(default(Player));
            }

            trekContext.Players.Remove(oldItem!.ToEntity());
            trekContext.Players.AddAsync(newItem!.ToEntity());
            return Task.FromResult<Player?>(newItem);
        }
    }
}

