﻿// <auto-generated />
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DronesContext))]
    [Migration("20180312002504_AddLogModel")]
    partial class AddLogModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<Guid>("Player1Id");

                    b.Property<Guid>("Player2Id");

                    b.Property<Guid?>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("Level");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<Guid?>("GameId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("Player1Move");

                    b.Property<int>("Player2Move");

                    b.Property<int>("Result");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Game", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Entities.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCore.Entities.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Round", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId");
                });
#pragma warning restore 612, 618
        }
    }
}
