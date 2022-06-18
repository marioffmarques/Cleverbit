﻿// <auto-generated />
using System;
using Cleverbit.CodingTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cleverbit.CodingTask.Data.Migrations
{
    [DbContext(typeof(CodingTaskContext))]
    [Migration("20220618154322_ModelInit")]
    partial class ModelInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cleverbit.CodingTask.Domain.Entities.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MatchStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MatchTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MatchTypeId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Cleverbit.CodingTask.Domain.Entities.MatchType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("MatchType");
                });

            modelBuilder.Entity("Cleverbit.CodingTask.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Cleverbit.CodingTask.Domain.Entities.UserMatch", b =>
                {
                    b.Property<Guid>("MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("MatchId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMatch");
                });

            modelBuilder.Entity("Cleverbit.CodingTask.Domain.Entities.Match", b =>
                {
                    b.HasOne("Cleverbit.CodingTask.Domain.Entities.MatchType", "MatchType")
                        .WithMany()
                        .HasForeignKey("MatchTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MatchType");
                });

            modelBuilder.Entity("Cleverbit.CodingTask.Domain.Entities.UserMatch", b =>
                {
                    b.HasOne("Cleverbit.CodingTask.Domain.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cleverbit.CodingTask.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
