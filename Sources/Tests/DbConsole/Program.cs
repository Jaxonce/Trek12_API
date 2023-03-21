using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;
using Model;

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

/*using (var context = new SQLiteContext())
{
    Console.WriteLine("Create and Insert new Player");
    context.Add(p1);
    context.Add(p2);
    context.SaveChanges();
}*/

// Ajout de 3 Game, 1 Player "Jax" et 3 Scores totaux dans chaque Game attribués au Player par son Id
using (var context = new SQLiteContext())
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
}

public class SQLiteContext : TrekContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite($"Data Source=projet.ToutesTables.db");
        }
    }
}
