using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkLib
{
    public class TrekContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }

        public DbSet<GameEntity> Game { get; set; }

        public DbSet<GrilleEntity> Grille { get; set; }

        public DbSet<CaseEntity> Case { get; set; }

        public DbSet<TurnEntity> Turn { get; set; }

        public DbSet<ScoreEntity> Score { get; set; }

        public DbSet<StatsEntity> Stats { get; set; }

        public TrekContext() { }
        public TrekContext(DbContextOptions<TrekContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                base.OnConfiguring(options.UseSqlite($"DataSource=projet.AllTables.db"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Définition de la clé primaire de PlayerEntity
            modelBuilder.Entity<PlayerEntity>().HasKey(n => n.PlayerId);
            //Définition de la clé primaire de GameEntity
            modelBuilder.Entity<GameEntity>().HasKey(n => n.GameId);
            //Définition de la clé primaire de GrilleEntity
            modelBuilder.Entity<GrilleEntity>().HasKey(n => n.GrilleId);
            //Définition de la clé primaire de CaseEntity
            modelBuilder.Entity<CaseEntity>().HasKey(n => n.CaseId);
            //Définition de la clé primaire de TurnEntity
            modelBuilder.Entity<TurnEntity>().HasKey(n => n.TurnId);
            //Définition du mode de generation de la clé : génération à l'insertion
            modelBuilder.Entity<PlayerEntity>().Property(n => n.PlayerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<GameEntity>().Property(n => n.GameId).ValueGeneratedOnAdd();
            modelBuilder.Entity<GrilleEntity>().Property(n => n.GrilleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CaseEntity>().Property(n => n.CaseId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TurnEntity>().Property(n => n.TurnId).ValueGeneratedOnAdd();

            //Configuration des clés primaires et étrangères pour la table Score
            modelBuilder.Entity<GameEntity>()
                .HasKey(g => g.GameId);

            modelBuilder.Entity<PlayerEntity>()
                .HasKey(p => p.PlayerId);

            modelBuilder.Entity<ScoreEntity>()
                .HasKey(s => new { s.GameId, s.PlayerId });

            modelBuilder.Entity<ScoreEntity>()
                .HasOne(s => s.Game)
                .WithMany(g => g.Scores)
                .HasForeignKey(s => s.GameId);

            modelBuilder.Entity<ScoreEntity>()
                .HasOne(s => s.Player)
                .WithMany()
                .HasForeignKey(s => s.PlayerId);

            // Configuration de la relation "one-to-many" entre GrilleEntity et CaseEntity
            modelBuilder.Entity<GrilleEntity>()
                .HasMany(g => g.Cases)
                .WithOne(c => c.Grille)
                .HasForeignKey(c => c.GrilleId);

            modelBuilder.Entity<PlayerEntity>() //l'entité Player...
             .HasOne(n => n.stats) //a une propriété obligatoire stats...
             .WithOne(c => c.Player) //reliée à la propriété Player de Stats...
             .HasForeignKey<StatsEntity>(c => c.PlayerId);//dont la propriété Id est une Foreign Key

            //Configuration des clés primaires et étrangères pour la table Participate


            base.OnModelCreating(modelBuilder);
        }
    }
}

