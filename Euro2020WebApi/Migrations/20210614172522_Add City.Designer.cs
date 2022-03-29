﻿// <auto-generated />
using System;
using Euro2020WebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Euro2020WebApi.Migrations
{
    [DbContext(typeof(Euro2020Context))]
    [Migration("20210614172522_Add City")]
    partial class AddCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Euro2020WebApi.Models.EuroCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EuroCountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EuroCountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroCoach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EuroCountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EuroCountryId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlagUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayGoals")
                        .HasColumnType("int");

                    b.Property<int>("EuroAwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("EuroGroupId")
                        .HasColumnType("int");

                    b.Property<int>("EuroHomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("EuroRefereeId")
                        .HasColumnType("int");

                    b.Property<int>("EuroStadiumId")
                        .HasColumnType("int");

                    b.Property<int>("HomeGoals")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EuroAwayTeamId");

                    b.HasIndex("EuroGroupId");

                    b.HasIndex("EuroHomeTeamId");

                    b.HasIndex("EuroRefereeId");

                    b.HasIndex("EuroStadiumId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EuroPositionId")
                        .HasColumnType("int");

                    b.Property<int>("EuroTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("OwnGoals")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EuroPositionId");

                    b.HasIndex("EuroTeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroReferee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EuroCountryId")
                        .HasColumnType("int");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EuroCountryId");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroStadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("EuroCityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EuroCityId");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EuroCoachId")
                        .HasColumnType("int");

                    b.Property<int>("EuroCountryId")
                        .HasColumnType("int");

                    b.Property<int>("EuroGroupId")
                        .HasColumnType("int");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<int>("GoalDifference")
                        .HasColumnType("int");

                    b.Property<int>("GoalsAgainst")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("GroupPosition")
                        .HasColumnType("int");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Ties")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EuroCoachId");

                    b.HasIndex("EuroCountryId");

                    b.HasIndex("EuroGroupId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroCity", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroCountry", "FK_Country")
                        .WithMany()
                        .HasForeignKey("EuroCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Country");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroCoach", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroCountry", "FK_Country")
                        .WithMany()
                        .HasForeignKey("EuroCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Country");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroMatch", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroTeam", "FK_AwayTeam")
                        .WithMany()
                        .HasForeignKey("EuroAwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroGroup", "FK_Group")
                        .WithMany()
                        .HasForeignKey("EuroGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroTeam", "FK_HomeTeam")
                        .WithMany()
                        .HasForeignKey("EuroHomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroReferee", "FK_Referee")
                        .WithMany()
                        .HasForeignKey("EuroRefereeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroStadium", "FK_Stadium")
                        .WithMany()
                        .HasForeignKey("EuroStadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_AwayTeam");

                    b.Navigation("FK_Group");

                    b.Navigation("FK_HomeTeam");

                    b.Navigation("FK_Referee");

                    b.Navigation("FK_Stadium");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroPlayer", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroPosition", "FK_Position")
                        .WithMany()
                        .HasForeignKey("EuroPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroTeam", "FK_Team")
                        .WithMany()
                        .HasForeignKey("EuroTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Position");

                    b.Navigation("FK_Team");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroReferee", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroCountry", "FK_Country")
                        .WithMany()
                        .HasForeignKey("EuroCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Country");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroStadium", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroCity", "FK_City")
                        .WithMany()
                        .HasForeignKey("EuroCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_City");
                });

            modelBuilder.Entity("Euro2020WebApi.Models.EuroTeam", b =>
                {
                    b.HasOne("Euro2020WebApi.Models.EuroCoach", "FK_Coach")
                        .WithMany()
                        .HasForeignKey("EuroCoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroCountry", "FK_Country")
                        .WithMany()
                        .HasForeignKey("EuroCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro2020WebApi.Models.EuroGroup", "FK_Group")
                        .WithMany()
                        .HasForeignKey("EuroGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Coach");

                    b.Navigation("FK_Country");

                    b.Navigation("FK_Group");
                });
#pragma warning restore 612, 618
        }
    }
}