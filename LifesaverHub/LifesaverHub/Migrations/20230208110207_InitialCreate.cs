using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifesaverHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegistredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    LifeHackId = table.Column<long>(type: "bigint", nullable: false),
                    RegistredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeHacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PhotoName = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    categoriesId = table.Column<List<long>>(type: "bigint[]", nullable: false),
                    RegistredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeHacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardHolder = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    ExpiryMonth = table.Column<int>(type: "integer", nullable: false),
                    ExpiryYear = table.Column<int>(type: "integer", nullable: false),
                    Cvv = table.Column<string>(type: "text", nullable: false),
                    AddressLine1 = table.Column<string>(type: "text", nullable: false),
                    AddressLine2 = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    RegistredTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Home" },
                    { 3, "Tech" },
                    { 4, "Funny" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "LifeHackId", "Points", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 4L, 0L, "That actually save my cookies!", 0L },
                    { 2, 3L, 5L, "Why should i want to do that???", 0L },
                    { 3, 0L, -5L, "Boring", 1L }
                });

            migrationBuilder.InsertData(
                table: "LifeHacks",
                columns: new[] { "Id", "Description", "Link", "PhotoName", "Points", "Title", "UserId", "categoriesId" },
                values: new object[,]
                {
                    { 1, "To easily remove the steam from the strawberries we recommend to use a straw as in image from bellow.", "", "strawberries and the straw", 27L, "How to remove the steam from the strawberries?", 0L, new List<long> { 0L } },
                    { 2, "The best way to kip chips fresh after opening is by using any clipper, like the ones from hanger.", "", "chips and hanger", 0L, "How to properly close a bag of chips?", 0L, new List<long> { 0L } },
                    { 3, "We’re sure you’re stocking up on sweet smelling candles to make your home extra cozy for the colder months. But, if your candles are burning too low to reach the wick, there’s no reason to go without your favorite scent. Instead of burning your fingers, light a piece of uncooked spaghetti. It’ll reach into those deep candles and burn long enough to light the candles on grandpa’s birthday cake!", "", "", 12L, "Pasta Lighter", 0L, new List<long> { 1L } },
                    { 4, "Fastest way to do that is simply putting a hair elastic on a vacuum and slowly suck the hair in.", "https://www.boredpanda.com/blog/wp-content/org_uploads/2013/01/life-hacks-36.gif", "", -43L, "Fastest way to catch the hair in the tail", 1L, new List<long> { 3L } },
                    { 5, "Sprinkle dried rice under your cupcake cases before baking. The rice absorbs any grease throughout baking meaning you get lovely dry cupcake bases and no greasy patches on your cases!", "", "cupcakes and rice", 25L, "Useful tip for baking cupcakes", 1L, new List<long> { 0L } }
                });

            migrationBuilder.InsertData(
                table: "UsersData",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CardHolder", "CardNumber", "City", "Country", "Cvv", "ExpiryMonth", "ExpiryYear", "PhoneNumber", "Points", "UserId", "ZipCode" },
                values: new object[] { 1, "123 Maple Street", "", "john doe", "1234567890123456", "Columbus", "Ohio", "123", 10, 25, "5555555555", 0L, 0L, "1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LifeHacks");

            migrationBuilder.DropTable(
                name: "UsersData");
        }
    }
}
