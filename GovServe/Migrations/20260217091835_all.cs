using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovServe.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaisedByUserId",
                table: "Escalation");

            migrationBuilder.DropColumn(
                name: "CurrentStage",
                table: "Case");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Case",
                newName: "SLADeadline");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notification",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Escalation",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RaisedByType",
                table: "Escalation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Case",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaisedByType",
                table: "Escalation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Case");

            migrationBuilder.RenameColumn(
                name: "SLADeadline",
                table: "Case",
                newName: "LastUpdated");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Escalation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "RaisedByUserId",
                table: "Escalation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentStage",
                table: "Case",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
