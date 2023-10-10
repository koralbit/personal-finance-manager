using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddCheckingAccount : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CheckingAccounts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                AccountType = table.Column<int>(type: "int", nullable: false),
                Balance = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                FinanceEntityId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CheckingAccounts", x => x.Id);
                table.ForeignKey(
                    name: "FK_CheckingAccounts_FinanceEntity_FinanceEntityId",
                    column: x => x.FinanceEntityId,
                    principalTable: "FinanceEntity",
                    principalColumn: "FinanceEntityId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CheckingAccounts_FinanceEntityId",
            table: "CheckingAccounts",
            column: "FinanceEntityId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CheckingAccounts");
    }
}
