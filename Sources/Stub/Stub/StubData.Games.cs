using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public partial class StubData
    {
        private List<Game> games = new()
        {
            //new Game(new TimeSpan(1,20,0),new DateOnly(2023,06,03)),
            //new Game(),
        };

        public class GamesManager : IGamesManager
        {
            private readonly StubData parent;

            public GamesManager(StubData parent)
                => this.parent = parent;

            Task<bool> IGamesManager.AddCaseValueToPlayer(int id, int value, int index)
            {
                throw new NotImplementedException();
            }

            Task<Game?> IGenericDataManager<Game?>.AddItem(Game? item)
            {
                throw new NotImplementedException();
            }

            Task<bool> IGamesManager.AddPlayer(Player player)
            {
                throw new NotImplementedException();
            }

            Task<bool> IGamesManager.AddScoreToPlayer(int id, int score)
            {
                throw new NotImplementedException();
            }

            Task<bool> IGamesManager.AddTime(TimeSpan time)
            {
                throw new NotImplementedException();
            }

            Task<bool> IGamesManager.AddTurn(Turn turn)
            {
                throw new NotImplementedException();
            }

            Task<bool> IGenericDataManager<Game?>.DeleteItem(Game? item)
            {
                throw new NotImplementedException();
            }

            Task<IEnumerable<Game?>> IGenericDataManager<Game?>.GetItems(int index, int count, string? orderingPropertyName, bool descending)
            {
                throw new NotImplementedException();
            }

            Task<int> IGenericDataManager<Game?>.GetNbItems()
            {
                throw new NotImplementedException();
            }

            Task<Game?> IGenericDataManager<Game?>.UpdateItem(Game? oldItem, Game? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
