using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataManager
    {
        IPlayersManager PlayersMgr { get; }
        IGamesManager GamesMgr { get; }
        IGamesModeManager GamesModeMgr { get; }
        ICasesManager CasesMgr { get; }
        IGrillesManager GrillesMgr { get; }
        IStatsManager StatsMgr { get; }
        ITurnsManager TurnsMgr { get; }
    }

	public interface IPlayersManager : IGenericDataManager<Player?>
	{
        Task<IEnumerable<Player?>> GetItemsByPseudo(string charPseudo);
        Task<int> GetNbItemsByPseudo(string charPseudo);

        Task<IEnumerable<Player?>> GetItemsById(int id);        

    }

    public interface IGamesManager : IGenericDataManager<Game?>
    {
        Task<bool> AddPlayer(Player player);
        Task<bool> AddScoreToPlayer(int idGame, int idPlayer, int score);
        Task<bool> AddCaseValueToPlayer(int idGame, int idPlayer, int value, int index);
        Task<bool> AddTurn(Turn turn);
        Task<bool> AddTime(TimeSpan time);
    }

    public interface IGamesModeManager : IGenericDataManager<GameMode?>
    {
    }

    public interface ICasesManager : IGenericDataManager<Case?>
    {
    }

    public interface IGrillesManager : IGenericDataManager<Grille?>
    {
    }

    public interface IStatsManager : IGenericDataManager<Stats?>
    {
    }

    public interface ITurnsManager : IGenericDataManager<Turn?>
    {
    }
}
