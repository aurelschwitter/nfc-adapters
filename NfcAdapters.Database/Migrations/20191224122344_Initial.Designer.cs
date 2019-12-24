﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NfcAdapters.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NfcAdapters.Database.Migrations
{
    [DbContext(typeof(AdapterContext))]
    [Migration("20191224122344_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NfcAdapters.Database.Entities.Adapter", b =>
                {
                    b.Property<int>("AdapterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdapterTypeId")
                        .HasColumnType("integer");

                    b.HasKey("AdapterId");

                    b.HasIndex("AdapterTypeId");

                    b.ToTable("Adapters");
                });

            modelBuilder.Entity("NfcAdapters.Database.Entities.AdapterType", b =>
                {
                    b.Property<int>("AdapterTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AdapterTypeId");

                    b.ToTable("AdapterTypes");
                });

            modelBuilder.Entity("NfcAdapters.Database.Entities.DbUser", b =>
                {
                    b.Property<int>("DbUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AuthKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Authorized")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DbUserId");

                    b.ToTable("DbUsers");
                });

            modelBuilder.Entity("NfcAdapters.Database.Entities.Lending", b =>
                {
                    b.Property<int>("LendingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdapterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LendingStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LendingId");

                    b.HasIndex("AdapterId");

                    b.ToTable("Lendings");
                });

            modelBuilder.Entity("NfcAdapters.Database.Entities.Adapter", b =>
                {
                    b.HasOne("NfcAdapters.Database.Entities.AdapterType", "AdapterType")
                        .WithMany("Adapters")
                        .HasForeignKey("AdapterTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NfcAdapters.Database.Entities.Lending", b =>
                {
                    b.HasOne("NfcAdapters.Database.Entities.Adapter", "Adapter")
                        .WithMany("Lendings")
                        .HasForeignKey("AdapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}