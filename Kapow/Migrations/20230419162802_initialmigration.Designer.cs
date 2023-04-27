﻿// <auto-generated />
using System;
using Kapow.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kapow.Migrations
{
    [DbContext(typeof(ProfileDbContext))]
    [Migration("20230419162802_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Kapow.Models.FoodTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("FoodTags");
                });

            modelBuilder.Entity("Kapow.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FoodTagId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FoodTagId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Kapow.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("HomeBase")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Kapow.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Kapow.Models.FoodTag", b =>
                {
                    b.HasOne("Kapow.Models.Profile", null)
                        .WithMany("FoodTags")
                        .HasForeignKey("ProfileId");

                    b.HasOne("Kapow.Models.Restaurant", null)
                        .WithMany("FoodTags")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("Kapow.Models.Location", b =>
                {
                    b.HasOne("Kapow.Models.FoodTag", null)
                        .WithMany("Locations")
                        .HasForeignKey("FoodTagId");
                });

            modelBuilder.Entity("Kapow.Models.Restaurant", b =>
                {
                    b.HasOne("Kapow.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Kapow.Models.Profile", null)
                        .WithMany("Restaurants")
                        .HasForeignKey("ProfileId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Kapow.Models.FoodTag", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Kapow.Models.Profile", b =>
                {
                    b.Navigation("FoodTags");

                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Kapow.Models.Restaurant", b =>
                {
                    b.Navigation("FoodTags");
                });
#pragma warning restore 612, 618
        }
    }
}