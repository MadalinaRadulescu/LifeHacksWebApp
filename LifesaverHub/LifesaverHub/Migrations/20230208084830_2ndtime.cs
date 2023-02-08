using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifesaverHub.Migrations
{
    /// <inheritdoc />
    public partial class _2ndtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PublishedAt",
                value: new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PublishedAt",
                value: new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PublishedAt",
                value: new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9735), new List<long> { 0L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9739), new List<long> { 0L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9740), new List<long> { 1L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9741), new List<long> { 3L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9742), new List<long> { 0L } });

            migrationBuilder.UpdateData(
                table: "UsersData",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterTime",
                value: new DateTime(2023, 2, 8, 8, 48, 30, 561, DateTimeKind.Utc).AddTicks(9816));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PublishedAt",
                value: new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PublishedAt",
                value: new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PublishedAt",
                value: new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4320), new List<long> { 0L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4388), new List<long> { 0L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4390), new List<long> { 1L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4392), new List<long> { 3L } });

            migrationBuilder.UpdateData(
                table: "LifeHacks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PublishedAt", "categoriesId" },
                values: new object[] { new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4394), new List<long> { 0L } });

            migrationBuilder.UpdateData(
                table: "UsersData",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterTime",
                value: new DateTime(2023, 2, 8, 10, 46, 2, 769, DateTimeKind.Local).AddTicks(4473));
        }
    }
}
