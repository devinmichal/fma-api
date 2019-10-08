﻿// <auto-generated />
using System;
using FMA.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FMA.API.Migrations
{
    [DbContext(typeof(FmaContext))]
    [Migration("20191008204404_CharacterRequirements")]
    partial class CharacterRequirements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FMA.API.Entities.Capital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Capitals");
                });

            modelBuilder.Entity("FMA.API.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abilities")
                        .HasMaxLength(500);

                    b.Property<int>("Age")
                        .HasMaxLength(3);

                    b.Property<string>("Aliases")
                        .HasMaxLength(100);

                    b.Property<Guid?>("CountryId")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("Goal")
                        .HasMaxLength(500);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<Guid?>("NationalityId")
                        .IsRequired();

                    b.Property<Guid?>("OccupationId")
                        .IsRequired();

                    b.Property<string>("Rank")
                        .HasMaxLength(100);

                    b.Property<string>("Weapon")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("OccupationId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("FMA.API.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CapitalId");

                    b.Property<Guid?>("CurrencyId");

                    b.Property<int>("Founded");

                    b.Property<string>("Government");

                    b.Property<Guid?>("GovernorId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("NationalityId");

                    b.Property<int>("Population");

                    b.HasKey("Id");

                    b.HasIndex("CapitalId")
                        .IsUnique()
                        .HasFilter("[CapitalId] IS NOT NULL");

                    b.HasIndex("CurrencyId")
                        .IsUnique()
                        .HasFilter("[CurrencyId] IS NOT NULL");

                    b.HasIndex("GovernorId");

                    b.HasIndex("NationalityId")
                        .IsUnique()
                        .HasFilter("[NationalityId] IS NOT NULL");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FMA.API.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("FMA.API.Entities.Nationality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("FMA.API.Entities.Occupation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Decsription");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("FMA.API.Entities.Character", b =>
                {
                    b.HasOne("FMA.API.Entities.Country", "Country")
                        .WithMany("Members")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("FMA.API.Entities.Nationality", "Nationality")
                        .WithMany("Members")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FMA.API.Entities.Occupation", "Occupation")
                        .WithMany("Members")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("FMA.API.Entities.Country", b =>
                {
                    b.HasOne("FMA.API.Entities.Capital", "Capital")
                        .WithOne("Country")
                        .HasForeignKey("FMA.API.Entities.Country", "CapitalId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("FMA.API.Entities.Currency", "Currency")
                        .WithOne("Country")
                        .HasForeignKey("FMA.API.Entities.Country", "CurrencyId");

                    b.HasOne("FMA.API.Entities.Character", "Governor")
                        .WithMany()
                        .HasForeignKey("GovernorId");

                    b.HasOne("FMA.API.Entities.Nationality", "Nationality")
                        .WithOne("Country")
                        .HasForeignKey("FMA.API.Entities.Country", "NationalityId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
