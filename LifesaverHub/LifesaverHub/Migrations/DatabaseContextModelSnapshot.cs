﻿// <auto-generated />
using System;
using System.Collections.Generic;
using LifesaverHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LifesaverHub.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LifesaverHub.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistredTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food",
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Name = "Home",
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tech",
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Name = "Funny",
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LifesaverHub.Models.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("LifeHackId")
                        .HasColumnType("bigint");

                    b.Property<long>("Points")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegistredTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LifeHackId = 4L,
                            Points = 0L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "That actually save my cookies!",
                            UserId = 0L
                        },
                        new
                        {
                            Id = 2,
                            LifeHackId = 3L,
                            Points = 5L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Why should i want to do that???",
                            UserId = 0L
                        },
                        new
                        {
                            Id = 3,
                            LifeHackId = 0L,
                            Points = -5L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Boring",
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("LifesaverHub.Models.Entities.LifeHack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Points")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegistredTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<List<long>>("categoriesId")
                        .IsRequired()
                        .HasColumnType("bigint[]");

                    b.HasKey("Id");

                    b.ToTable("LifeHacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "To easily remove the steam from the strawberries we recommend to use a straw as in image from bellow.",
                            Link = "",
                            PhotoName = "strawberries and the straw",
                            Points = 27L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "How to remove the steam from the strawberries?",
                            UserId = 0L,
                            categoriesId = new List<long> { 0L }
                        },
                        new
                        {
                            Id = 2,
                            Description = "The best way to kip chips fresh after opening is by using any clipper, like the ones from hanger.",
                            Link = "",
                            PhotoName = "chips and hanger",
                            Points = 0L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "How to properly close a bag of chips?",
                            UserId = 0L,
                            categoriesId = new List<long> { 0L }
                        },
                        new
                        {
                            Id = 3,
                            Description = "We’re sure you’re stocking up on sweet smelling candles to make your home extra cozy for the colder months. But, if your candles are burning too low to reach the wick, there’s no reason to go without your favorite scent. Instead of burning your fingers, light a piece of uncooked spaghetti. It’ll reach into those deep candles and burn long enough to light the candles on grandpa’s birthday cake!",
                            Link = "",
                            PhotoName = "",
                            Points = 12L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pasta Lighter",
                            UserId = 0L,
                            categoriesId = new List<long> { 1L }
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fastest way to do that is simply putting a hair elastic on a vacuum and slowly suck the hair in.",
                            Link = "https://www.boredpanda.com/blog/wp-content/org_uploads/2013/01/life-hacks-36.gif",
                            PhotoName = "",
                            Points = -43L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fastest way to catch the hair in the tail",
                            UserId = 1L,
                            categoriesId = new List<long> { 3L }
                        },
                        new
                        {
                            Id = 5,
                            Description = "Sprinkle dried rice under your cupcake cases before baking. The rice absorbs any grease throughout baking meaning you get lovely dry cupcake bases and no greasy patches on your cases!",
                            Link = "",
                            PhotoName = "cupcakes and rice",
                            Points = 25L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Useful tip for baking cupcakes",
                            UserId = 1L,
                            categoriesId = new List<long> { 0L }
                        });
                });

            modelBuilder.Entity("LifesaverHub.Models.Entities.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExpiryMonth")
                        .HasColumnType("integer");

                    b.Property<int>("ExpiryYear")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Points")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegistredTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UsersData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressLine1 = "123 Maple Street",
                            AddressLine2 = "",
                            CardHolder = "john doe",
                            CardNumber = "1234567890123456",
                            City = "Columbus",
                            Country = "Ohio",
                            Cvv = "123",
                            ExpiryMonth = 10,
                            ExpiryYear = 25,
                            PhoneNumber = "5555555555",
                            Points = 0L,
                            RegistredTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 0L,
                            ZipCode = "1234"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}