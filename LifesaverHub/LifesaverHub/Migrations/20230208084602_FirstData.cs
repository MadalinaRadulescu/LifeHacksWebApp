using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifesaverHub.Migrations
{
    /// <inheritdoc />
    public partial class FirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "UsersData");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterTime",
                table: "UsersData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "LifeHacks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Food" },
                    { 2L, "Home" },
                    { 3L, "Tech" },
                    { 4L, "Funny" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "LifeHackId", "PublishedAt", "Text", "UserId", "VoteCount" },
                values: new object[,]
                {
                    { 1L, 4L, new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4397), "That actually save my cookies!", 0L, 0L },
                    { 2L, 3L, new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4403), "Why should i want to do that???", 0L, 5L },
                    { 3L, 0L, new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4405), "Boring", 1L, -5L }
                });

            migrationBuilder.InsertData(
                table: "LifeHacks",
                columns: new[] { "Id", "Description", "Link", "PhotoName", "PublishedAt", "Title", "VoteCount", "categoriesId", "userId" },
                values: new object[,]
                {
                    { 1, "To easily remove the steam from the strawberries we recommend to use a straw as in image from bellow.", "", "strawberries and the straw", new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4320), "How to remove the steam from the strawberries?", 27L, new List<long> { 0L }, 0L },
                    { 2, "The best way to kip chips fresh after opening is by using any clipper, like the ones from hanger.", "", "chips and hanger", new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4388), "How to properly close a bag of chips?", 0L, new List<long> { 0L }, 0L },
                    { 3, "We’re sure you’re stocking up on sweet smelling candles to make your home extra cozy for the colder months. But, if your candles are burning too low to reach the wick, there’s no reason to go without your favorite scent. Instead of burning your fingers, light a piece of uncooked spaghetti. It’ll reach into those deep candles and burn long enough to light the candles on grandpa’s birthday cake!", "", "", new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4390), "Pasta Lighter", 12L, new List<long> { 1L }, 0L },
                    { 4, "Fastest way to do that is simply putting a hair elastic on a vacuum and slowly suck the hair in.", "https://www.boredpanda.com/blog/wp-content/org_uploads/2013/01/life-hacks-36.gif", "", new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4392), "Fastest way to catch the hair in the tail", -43L, new List<long> { 3L }, 1L },
                    { 5, "Sprinkle dried rice under your cupcake cases before baking. The rice absorbs any grease throughout baking meaning you get lovely dry cupcake bases and no greasy patches on your cases!", "", "cupcakes and rice", new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4394), "Useful tip for baking cupcakes", 25L, new List<long> { 0L }, 1L }
                });

            migrationBuilder.InsertData(
                table: "UsersData",
                columns: new[] { "Id", "AddressLine1", "CardHolder", "CardNumber", "City", "Country", "Cvv", "ExpiryMonth", "ExpiryYear", "PhoneNumber", "Points", "RegisterTime", "UserId", "ZipCode" },
                values: new object[] { 1, "123 Maple Street", "john doe", "1234567890123456", "Columbus", "Ohio", "123", 10, 25, "5555555555", 0L, new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4473), 0L, "1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UsersData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RegisterTime",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "LifeHacks");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "UsersData",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
