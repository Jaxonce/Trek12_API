using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;

PlayerEntity p1 = new PlayerEntity
{
    PlayerId = 0,
    Pseudo = "Jax",
    NbWin = 0,
    NbPlayed = 0,
    MaxZone = 0,
    MaxPoints = 0,
    NbPoints = 0
};

GameEntity g1 = new GameEntity
{
    GameId = 1,
};

PlayerEntity p2 = new PlayerEntity
{
    PlayerId = 0,
    Pseudo = "Theo",
    NbWin = 0,
    NbPlayed = 0,
    MaxZone = 0,
    MaxPoints = 0,
    NbPoints = 0
};

/*using (var context = new SQLiteContext())
{
    Console.WriteLine("Create and Insert new Player");
    context.Add(p1);
    context.Add(p2);
    context.SaveChanges();
}*/

using (var context = new SQLiteContext())
{
    var newScore = new ScoreEntity
    {
        GameId = 1,
        PlayerId = 2,
        NbPoints = 5
    };

    context.Add(newScore);
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
