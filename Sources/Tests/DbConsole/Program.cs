using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;
using Model;
using Stub;


/*GameEntity g1 = new GameEntity
{
    GameId = 1,
};*/

/*PlayerEntity p1 = new PlayerEntity
{
    PlayerId = 1,
    Pseudo = "Jax",
    NbWin = 0,
    NbPlayed = 0,
    MaxZone = 0,
    MaxPoints = 0,
};*/

/*using (var context = new TrekContext())
{
    Console.WriteLine("Create and Insert new Player");
    context.Add(p1);
    context.Add(p2);
    context.SaveChanges();
}*/

// Ajout de 3 Game, 1 Player "Jax" et 3 Scores totaux dans chaque Game attribués au Player par son Id
/*using (var context = new TrekContext())
{
    var firstGame = new GameEntity
    {
        GameId = 1,
        Name = "First Game",
    };
    var secondGame = new GameEntity
    {
        GameId = 2,
        Name = "Second Game",
    };
    var thirdGame = new GameEntity
    {
        GameId = 3,
        Name = "Third Game",
    };
    var newPlayer = new PlayerEntity
    {
        PlayerId = 2,
        Pseudo = "Jax"
    };
    var scores = new List<ScoreEntity>
    {
        new ScoreEntity { GameId = 1, NbPointsTotal = 5 },
        new ScoreEntity { GameId = 2, NbPointsTotal = 10 },
        new ScoreEntity { GameId = 3, NbPointsTotal = 15 }
    };
    newPlayer.Scores = scores;
    context.AddRange(firstGame, secondGame, thirdGame, newPlayer);
    context.AddRange(scores);
    context.SaveChanges();
}*/

/*using(var context = new TrekContext())
{
    var grille = new GrilleEntity
    {
        GrilleId = 1,
        NbChains = 1,
        NbZones = 4,
        MaxChain = 20,
        MaxZone = 25
    };

    var case1 = new CaseEntity
    {
        CaseId = 1,
        Value = 5,
        GrilleId = 1
    };
    var case2 = new CaseEntity
    {
        CaseId = 2,
        Value = 10,
        GrilleId = 1
    };
    var case3 = new CaseEntity
    {
        CaseId = 3,
        Value = 12,
        GrilleId = 1
    };
    context.AddRange(grille, case1, case2, case3);
    context.SaveChanges();
*/

using (var context = new TrekContext())
{
    var grille = new GrilleEntity
    {
        GrilleId = 1,
        Cases = new List<CaseEntity>
        {
            new CaseEntity { CaseId = 1, GrilleId = 1, Value = 2  },
            new CaseEntity { CaseId = 2, GrilleId = 1, Value = 5  },
            new CaseEntity { CaseId = 3, GrilleId = 1, Value = 10  },
            new CaseEntity { CaseId = 4, GrilleId = 1, Value = 12  },
            new CaseEntity { CaseId = 5, GrilleId = 1, Value = 7  }
        }
    };
    context.Add(grille);
    context.SaveChanges();
}
    