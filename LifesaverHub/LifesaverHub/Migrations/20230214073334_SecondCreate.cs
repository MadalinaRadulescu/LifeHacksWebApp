using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LifesaverHub.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersData",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "UsersData",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LifeHacks",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "LifeHacks",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UsersData",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "UsersData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "LifeHacks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "LifeHacks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistredTime",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
    }
}
