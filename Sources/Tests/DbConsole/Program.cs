using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;

PlayerEntity p1 = new PlayerEntity
{
    Pseudo = "Jax",
    NbWin = 0,
    NbPlayed = 0,
    MaxZone = 0,
    MaxPoints = 0,
    NbPoints = 0
};

PlayerEntity p2 = new PlayerEntity
{
    Pseudo = "Theo",
    NbWin = 0,
    NbPlayed = 0,
    MaxZone = 0,
    MaxPoints = 0,
    NbPoints = 0
};

using (var context = new SQLiteContext())
{
    Console.WriteLine("Create and Insert new Champion");
    context.Add(p1);
    context.Add(p2);
    context.SaveChanges();
}

public class SQLiteContext : TrekContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite($"Data Source=projet.Champions.db");
        }
    }
}
