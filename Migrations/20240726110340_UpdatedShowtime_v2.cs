﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBookingBackend.Migrations
{
    public partial class UpdatedShowtime_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Showtimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "PasswordHash", "PasswordHashKey" },
                values: new object[] { new byte[] { 248, 22, 17, 28, 23, 168, 250, 197, 206, 1, 132, 39, 156, 225, 103, 48, 217, 17, 209, 24, 3, 30, 175, 8, 238, 217, 43, 11, 188, 120, 244, 134, 106, 77, 152, 177, 160, 65, 91, 222, 56, 126, 33, 185, 93, 43, 61, 69, 20, 193, 119, 89, 110, 148, 229, 159, 248, 174, 250, 164, 194, 102, 173, 44 }, new byte[] { 217, 142, 50, 126, 253, 200, 168, 116, 121, 163, 244, 231, 205, 78, 122, 27, 133, 244, 105, 55, 59, 216, 226, 64, 140, 141, 239, 32, 30, 117, 114, 213, 192, 224, 190, 0, 126, 140, 115, 245, 211, 188, 173, 121, 125, 179, 157, 26, 93, 104, 188, 235, 64, 190, 180, 148, 3, 143, 27, 160, 195, 19, 40, 195, 115, 26, 33, 220, 25, 221, 205, 251, 135, 177, 224, 25, 213, 90, 163, 130, 42, 190, 135, 157, 65, 30, 226, 138, 122, 86, 125, 39, 188, 145, 133, 139, 133, 0, 229, 66, 83, 10, 72, 136, 232, 196, 13, 73, 177, 39, 80, 36, 31, 109, 56, 195, 204, 252, 58, 23, 186, 177, 110, 91, 171, 72, 52, 197 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Showtimes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "PasswordHash", "PasswordHashKey" },
                values: new object[] { new byte[] { 127, 24, 46, 90, 234, 221, 3, 14, 100, 200, 49, 109, 113, 42, 17, 62, 124, 17, 18, 109, 228, 95, 87, 147, 96, 30, 63, 212, 185, 170, 1, 133, 179, 164, 78, 41, 135, 125, 69, 52, 93, 82, 247, 118, 93, 212, 201, 223, 153, 1, 117, 83, 58, 116, 84, 46, 133, 43, 226, 59, 231, 12, 61, 141 }, new byte[] { 50, 38, 255, 115, 112, 1, 55, 166, 181, 49, 138, 138, 42, 197, 241, 185, 213, 97, 146, 242, 39, 36, 51, 161, 96, 198, 23, 217, 87, 169, 37, 229, 49, 137, 70, 207, 20, 160, 83, 234, 76, 13, 215, 32, 247, 101, 129, 41, 247, 211, 16, 132, 212, 18, 180, 134, 130, 7, 36, 191, 46, 253, 37, 28, 138, 233, 41, 79, 244, 103, 105, 5, 0, 89, 176, 226, 180, 10, 142, 171, 244, 227, 211, 211, 118, 230, 238, 73, 230, 104, 232, 223, 177, 253, 125, 36, 47, 145, 143, 159, 165, 254, 252, 16, 229, 205, 65, 144, 157, 241, 243, 60, 82, 207, 97, 237, 232, 123, 0, 94, 201, 220, 210, 20, 167, 231, 239, 237 } });
        }
    }
}
