﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM_Api.Migrations
{
    /// <inheritdoc />
    public partial class ActModelforWorkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Workers",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cifrado",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Workers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cifrado",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Workers",
                newName: "Telephone");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Workers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
