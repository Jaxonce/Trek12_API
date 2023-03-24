using System;
using Model;

namespace DbDataManager
{
    public class DbDataManager : IDataManager
    {
        public IPlayersManager PlayersMgr => new PlayerManager();
        public IGamesManager GamesMgr => new GameManager();

        public IGamesModeManager GamesModeMgr => new GameModeManager();

        public ICasesManager CasesMgr => new CaseManager();

        public IGrillesManager GrillesMgr => new GrilleManager();

        public IStatsManager StatsMgr => new StatsManager();

        public ITurnsManager TurnsMgr => new TurnManager();
    }
}

