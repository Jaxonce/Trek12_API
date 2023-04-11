﻿// <auto-generated />
using System;
using EntityFrameWorkLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameWorkLib.Migrations
{
    [DbContext(typeof(TrekContext))]
    [Migration("20230411093944_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("EntityFrameWorkLib.CaseEntity", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GrilleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("CaseId");

                    b.HasIndex("GrilleId");

                    b.ToTable("Case");
                });

            modelBuilder.Entity("EntityFrameWorkLib.GameEntity", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NbPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("EntityFrameWorkLib.GrilleEntity", b =>
                {
                    b.Property<int>("GrilleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxChain")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxZone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbChains")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbZones")
                        .HasColumnType("INTEGER");

                    b.HasKey("GrilleId");

                    b.ToTable("Grille");
                });

            modelBuilder.Entity("EntityFrameWorkLib.PlayerEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pseudo")
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EntityFrameWorkLib.ScoreEntity", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbPointsTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("EntityFrameWorkLib.StatsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxChain")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxZone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbWin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("EntityFrameWorkLib.TurnEntity", b =>
                {
                    b.Property<int>("TurnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiceValue1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiceValue2")
                        .HasColumnType("INTEGER");

                    b.HasKey("TurnId");

                    b.ToTable("Turn");
                });

            modelBuilder.Entity("EntityFrameWorkLib.CaseEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.GrilleEntity", "Grille")
                        .WithMany("Cases")
                        .HasForeignKey("GrilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grille");
                });

            modelBuilder.Entity("EntityFrameWorkLib.GameEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.PlayerEntity", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EntityFrameWorkLib.ScoreEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.GameEntity", "Game")
                        .WithMany("Scores")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameWorkLib.PlayerEntity", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EntityFrameWorkLib.StatsEntity", b =>
                {
                    b.HasOne("EntityFrameWorkLib.PlayerEntity", "Player")
                        .WithOne("stats")
                        .HasForeignKey("EntityFrameWorkLib.StatsEntity", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EntityFrameWorkLib.GameEntity", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("EntityFrameWorkLib.GrilleEntity", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("EntityFrameWorkLib.PlayerEntity", b =>
                {
                    b.Navigation("stats")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}