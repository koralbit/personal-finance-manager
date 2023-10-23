using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateSequence(
            name: "accountseq",
            incrementBy: 10);

        migrationBuilder.CreateSequence(
            name: "transactionseq",
            incrementBy: 10);

        migrationBuilder.CreateTable(
            name: "FinanceEntity",
            columns: table => new
            {
                FinanceEntityId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FinanceEntity", x => x.FinanceEntityId);
            });

        migrationBuilder.CreateTable(
            name: "TransactionCategory",
            columns: table => new
            {
                TransactionCategoryId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsCommonCategory = table.Column<bool>(type: "bit", nullable: false),
                UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TransactionCategory", x => x.TransactionCategoryId);
            });

        migrationBuilder.CreateTable(
            name: "CreditCards",
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
                FinanceEntityId = table.Column<int>(type: "int", nullable: false),
                CreditLimit = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                StatementDay = table.Column<int>(type: "int", nullable: false),
                PaymentDay = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CreditCards", x => x.Id);
                table.ForeignKey(
                    name: "FK_CreditCards_FinanceEntity_FinanceEntityId",
                    column: x => x.FinanceEntityId,
                    principalTable: "FinanceEntity",
                    principalColumn: "FinanceEntityId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Transactions",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                Type = table.Column<int>(type: "int", nullable: false),
                TransactionCategoryId = table.Column<int>(type: "int", nullable: false),
                AccountId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transactions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Transactions_TransactionCategory_TransactionCategoryId",
                    column: x => x.TransactionCategoryId,
                    principalTable: "TransactionCategory",
                    principalColumn: "TransactionCategoryId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CreditCards_FinanceEntityId",
            table: "CreditCards",
            column: "FinanceEntityId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_AccountId",
            table: "Transactions",
            column: "AccountId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_TransactionCategoryId",
            table: "Transactions",
            column: "TransactionCategoryId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CreditCards");

        migrationBuilder.DropTable(
            name: "Transactions");

        migrationBuilder.DropTable(
            name: "FinanceEntity");

        migrationBuilder.DropTable(
            name: "TransactionCategory");

        migrationBuilder.DropSequence(
            name: "accountseq");

        migrationBuilder.DropSequence(
            name: "transactionseq");
    }
}
