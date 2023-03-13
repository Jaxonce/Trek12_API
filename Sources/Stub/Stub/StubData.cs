using Model;

namespace Stub
{
    public partial class StubData : IDataManager
    {
        public StubData()
        {
            //ChampionsMgr = new ChampionsManager(this);
            //SkinsMgr = new SkinsManager(this);
            //RunesMgr = new RunesManager(this);
            //RunePagesMgr = new RunePagesManager(this);

            PlayersMgr = new PlayersManager(this);
            GamesMgr = new GamesManager(this);
            GamesModeMgr = new GamesModeManager(this);
            CasesMgr = new CasesManager(this);
            GrillesMgr = new GrillesManager(this);
            StatsMgr = new StatsManager(this);
            TurnsMgr = new TurnsManager(this);
        }

        public IPlayersManager PlayersMgr { get; }

        public IGamesManager GamesMgr { get; }

        public IGamesModeManager GamesModeMgr { get; }

        public ICasesManager CasesMgr { get; }

        public IGrillesManager GrillesMgr { get; }

        public IStatsManager StatsMgr { get; }

        public ITurnsManager TurnsMgr { get; }

    }
}