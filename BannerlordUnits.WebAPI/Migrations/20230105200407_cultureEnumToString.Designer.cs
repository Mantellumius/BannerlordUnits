﻿// <auto-generated />
using System;
using BannerlordUnits.WebAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BannerlordUnits.WebAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230105200407_cultureEnumToString")]
    partial class cultureEnumToString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BannerlordUnits.WebAPI.Unit", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Athletics")
                        .HasColumnType("integer");

                    b.Property<int>("Bow")
                        .HasColumnType("integer");

                    b.Property<int>("Charm")
                        .HasColumnType("integer");

                    b.Property<int>("Crafting")
                        .HasColumnType("integer");

                    b.Property<int>("Crossbow")
                        .HasColumnType("integer");

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Engineering")
                        .HasColumnType("integer");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Leadership")
                        .HasColumnType("integer");

                    b.Property<int>("Medicine")
                        .HasColumnType("integer");

                    b.Property<int>("OneHanded")
                        .HasColumnType("integer");

                    b.Property<int>("Polearm")
                        .HasColumnType("integer");

                    b.Property<int>("Range")
                        .HasColumnType("integer");

                    b.Property<int>("Riding")
                        .HasColumnType("integer");

                    b.Property<int>("Roguery")
                        .HasColumnType("integer");

                    b.Property<int>("Scouting")
                        .HasColumnType("integer");

                    b.Property<int>("Steward")
                        .HasColumnType("integer");

                    b.Property<int>("Tactics")
                        .HasColumnType("integer");

                    b.Property<int>("Throwing")
                        .HasColumnType("integer");

                    b.Property<int>("Trade")
                        .HasColumnType("integer");

                    b.Property<int>("TwoHanded")
                        .HasColumnType("integer");

                    b.Property<string>("UnitImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UpgradeCost")
                        .HasColumnType("integer");

                    b.Property<int>("Wages")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("Units");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Unit");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BannerlordUnits.WebAPI.CustomUnit", b =>
                {
                    b.HasBaseType("BannerlordUnits.WebAPI.Unit");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.HasDiscriminator().HasValue("CustomUnit");
                });
#pragma warning restore 612, 618
        }
    }
}
