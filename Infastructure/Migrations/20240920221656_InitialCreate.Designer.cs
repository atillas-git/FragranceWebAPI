﻿// <auto-generated />
using System;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infastructure.Migrations
{
    [DbContext(typeof(FragranceDbContext))]
    [Migration("20240920221656_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cons")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FragranceId")
                        .HasColumnType("int");

                    b.Property<string>("Pros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FragranceId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Entities.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("Domain.Entities.Fragrance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fragrances");
                });

            modelBuilder.Entity("Domain.Entities.FragranceCreator", b =>
                {
                    b.Property<int>("FragranceId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.HasKey("FragranceId", "CreatorId");

                    b.HasIndex("CreatorId");

                    b.ToTable("FragranceCreators");
                });

            modelBuilder.Entity("Domain.Entities.FragranceFragranceNote", b =>
                {
                    b.Property<int>("FragranceId")
                        .HasColumnType("int");

                    b.Property<int>("FragranceNoteId")
                        .HasColumnType("int");

                    b.HasKey("FragranceId", "FragranceNoteId");

                    b.HasIndex("FragranceNoteId");

                    b.ToTable("FragranceFragranceNotes");
                });

            modelBuilder.Entity("Domain.Entities.FragranceNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FragranceNotes");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FemininityRating")
                        .HasColumnType("int");

                    b.Property<int>("FragranceId")
                        .HasColumnType("int");

                    b.Property<int>("MasculinityRating")
                        .HasColumnType("int");

                    b.Property<int>("OverallRating")
                        .HasColumnType("int");

                    b.Property<int>("PriceRating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FragranceId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordHash")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.Fragrance", "Fragrance")
                        .WithMany("Comments")
                        .HasForeignKey("FragranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fragrance");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.FragranceCreator", b =>
                {
                    b.HasOne("Domain.Entities.Creator", "Creator")
                        .WithMany("FragranceCreators")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Fragrance", "Fragrance")
                        .WithMany("FragranceCreators")
                        .HasForeignKey("FragranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Fragrance");
                });

            modelBuilder.Entity("Domain.Entities.FragranceFragranceNote", b =>
                {
                    b.HasOne("Domain.Entities.Fragrance", "Fragrance")
                        .WithMany("FragranceFragranceNotes")
                        .HasForeignKey("FragranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.FragranceNote", "FragranceNote")
                        .WithMany("FragranceFragranceNotes")
                        .HasForeignKey("FragranceNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fragrance");

                    b.Navigation("FragranceNote");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.HasOne("Domain.Entities.Fragrance", "Fragrance")
                        .WithMany("Ratings")
                        .HasForeignKey("FragranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fragrance");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Creator", b =>
                {
                    b.Navigation("FragranceCreators");
                });

            modelBuilder.Entity("Domain.Entities.Fragrance", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FragranceCreators");

                    b.Navigation("FragranceFragranceNotes");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.FragranceNote", b =>
                {
                    b.Navigation("FragranceFragranceNotes");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
