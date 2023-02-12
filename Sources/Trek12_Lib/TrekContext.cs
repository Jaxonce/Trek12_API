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

        public TrekContext() { }
        public TrekContext(DbContextOptions<TrekContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                base.OnConfiguring(options.UseSqlite($"DataSource=projet.Players.db"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Définition de la clé primaire de PlayerEntity
            modelBuilder.Entity<PlayerEntity>().HasKey(n => n.PlayerId);
            //Définition du mode de generation de la clé : génération à l'insertion
            modelBuilder.Entity<PlayerEntity>().Property(n => n.PlayerId).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

        }

    }
}

