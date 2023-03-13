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
	}

    public interface IGamesManager : IGenericDataManager<Game?>
    {
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
