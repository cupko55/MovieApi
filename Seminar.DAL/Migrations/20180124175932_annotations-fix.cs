using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Seminar.DAL.Migrations
{
    public partial class annotationsfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Type",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Type",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieType",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieLeadingActor",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 706, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Movie",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 665, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Movie",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 661, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "LeadingActor",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "LeadingActor",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 665, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Type",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Type",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieType",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieLeadingActor",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 706, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Movie",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 665, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Movie",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 661, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "LeadingActor",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 666, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "LeadingActor",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 24, 18, 52, 55, 665, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
