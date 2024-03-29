﻿// <auto-generated />
using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations.MembersDb
{
    [DbContext(typeof(MembersDbContext))]
    [Migration("20220831115216_AdditionalIndexesCreate")]
    partial class AdditionalIndexesCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBot")
                        .HasColumnType("bit");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDateTime");

                    b.HasIndex("TelegramId")
                        .IsUnique();

                    b.HasIndex("UpdatedDateTime");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
