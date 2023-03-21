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
            //Définition de la clé primaire de ScoreEntity
            modelBuilder.Entity<ScoreEntity>().HasKey(n => n.ScoreId);
            //Définition du mode de generation de la clé : génération à l'insertion
            modelBuilder.Entity<PlayerEntity>().Property(n => n.PlayerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<GameEntity>().Property(n => n.GameId).ValueGeneratedOnAdd();
            modelBuilder.Entity<GrilleEntity>().Property(n => n.GrilleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CaseEntity>().Property(n => n.CaseId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TurnEntity>().Property(n => n.TurnId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ScoreEntity>().Property(n => n.ScoreId).ValueGeneratedOnAdd();

            //Configuration des clés primaires et étrangères pour la table Score
            modelBuilder.Entity<ScoreEntity>()
            .HasKey(s => s.ScoreId);

            modelBuilder.Entity<GameEntity>()
                .HasKey(g => g.GameId);

            modelBuilder.Entity<PlayerEntity>()
                .HasKey(p => p.PlayerId);

            modelBuilder.Entity<ScoreEntity>()
                .HasOne(s => s.Game)
                .WithMany(g => g.Scores)
                .HasForeignKey(s => s.GameId);

            modelBuilder.Entity<ScoreEntity>()
                .HasOne(s => s.Player)
                .WithMany(p => p.Scores)
                .HasForeignKey(s => s.PlayerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

