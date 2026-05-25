using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_PJATK_Cw4_s29764.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "INTEL", new DateOnly(1968, 7, 18), "Intel Corporation" },
                    { 2, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices" },
                    { 3, "NVIDIA", new DateOnly(1993, 4, 5), "NVIDIA Corporation" },
                    { 4, "SAMSUNG", new DateOnly(1969, 1, 13), "Samsung Electronics" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Procesor" },
                    { 2, "GPU", "Karta graficzna" },
                    { 3, "RAM", "Pamięć RAM" },
                    { 4, "SSD", "Dysk SSD" },
                    { 5, "MB", "Płyta główna" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast", 8, 36, 14.8f },
                    { 2, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office Pro", 15, 24, 9.2f },
                    { 3, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creator Ultra", 5, 36, 16.5f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturersId", "ComponentTypesId", "Description", "Name" },
                values: new object[,]
                {
                    { "B760-A", 1, 5, "Socket LGA 1700, DDR5, PCIe 5.0", "ASUS Prime B760-PLUS" },
                    { "DDR4-32", 4, 3, "CL16, 1.35V", "Kingston Fury Beast 32GB (2x16GB) DDR4-3200" },
                    { "I5-12400", 1, 1, "6 rdzeni, 12 wątków, do 4.4 GHz, 18MB cache", "Intel Core i5-12400" },
                    { "RTX4070", 3, 2, "12GB GDDR6X, 5888 CUDA cores", "NVIDIA GeForce RTX 4070" },
                    { "SSD-1TB", 4, 4, "NVMe PCIe 4.0, do 7450 MB/s", "Samsung 990 PRO 1TB" }
                });

            migrationBuilder.InsertData(
                table: "PcComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "B760-A", 1, 1 },
                    { "DDR4-32", 1, 2 },
                    { "I5-12400", 1, 1 },
                    { "RTX4070", 1, 1 },
                    { "SSD-1TB", 1, 1 },
                    { "B760-A", 2, 1 },
                    { "DDR4-32", 2, 1 },
                    { "I5-12400", 2, 1 },
                    { "SSD-1TB", 2, 1 },
                    { "B760-A", 3, 1 },
                    { "DDR4-32", 3, 2 },
                    { "RTX4070", 3, 1 },
                    { "SSD-1TB", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "B760-A", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "DDR4-32", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "I5-12400", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RTX4070", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD-1TB", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "B760-A", 2 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "DDR4-32", 2 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "I5-12400", 2 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD-1TB", 2 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "B760-A", 3 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "DDR4-32", 3 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RTX4070", 3 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD-1TB", 3 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "B760-A");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "DDR4-32");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "I5-12400");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "RTX4070");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "SSD-1TB");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
