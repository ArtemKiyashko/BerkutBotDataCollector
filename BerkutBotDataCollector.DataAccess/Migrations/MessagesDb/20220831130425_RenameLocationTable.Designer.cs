﻿// <auto-generated />
using System;
using BerkutBotDataCollector.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerkutBotDataCollector.DataAccess.Migrations.MessagesDb
{
    [DbContext(typeof(MessagesDbContext))]
    [Migration("20220831130425_RenameLocationTable")]
    partial class RenameLocationTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Heading")
                        .HasColumnType("int");

                    b.Property<float?>("HorizontalAccuracy")
                        .HasColumnType("real");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<int?>("LivePeriod")
                        .HasColumnType("int");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("ProximityAlertRadius")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("SentDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("TelegramChatId")
                        .HasColumnType("bigint");

                    b.Property<long>("TelegramFromId")
                        .HasColumnType("bigint");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDateTime");

                    b.HasIndex("LocationId");

                    b.HasIndex("SentDateTime");

                    b.HasIndex("TelegramChatId");

                    b.HasIndex("TelegramFromId");

                    b.HasIndex("TelegramId")
                        .IsUnique();

                    b.HasIndex("UpdatedDateTime");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TelegramFileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TelegramFileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("TelegramFileUniqueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Message", b =>
                {
                    b.HasOne("BerkutBotDataCollector.DataAccess.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Photo", b =>
                {
                    b.HasOne("BerkutBotDataCollector.DataAccess.Models.Message", null)
                        .WithMany("Photo")
                        .HasForeignKey("MessageId");
                });

            modelBuilder.Entity("BerkutBotDataCollector.DataAccess.Models.Message", b =>
                {
                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}
