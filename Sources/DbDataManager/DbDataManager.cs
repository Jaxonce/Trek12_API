using Model;

namespace DbDataManager;
public class DbDataManager : IDataManager
{
    public IPlayersManager PlayersMgr => new PlayersManager();

    public IGamesManager GamesMgr => throw new NotImplementedException();

    public IGamesModeManager GamesModeMgr => throw new NotImplementedException();

    public ICasesManager CasesMgr => throw new NotImplementedException();

    public IGrillesManager GrillesMgr => throw new NotImplementedException();

    public IStatsManager StatsMgr => throw new NotImplementedException();

    public ITurnsManager TurnsMgr => throw new NotImplementedException();
}

