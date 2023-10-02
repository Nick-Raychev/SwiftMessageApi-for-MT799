using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftMessageApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SwiftMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageType = table.Column<string>(type: "TEXT", nullable: true),
                    Sender = table.Column<string>(type: "TEXT", nullable: true),
                    Receiver = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionReference = table.Column<string>(type: "TEXT", nullable: true),
                    ValueDate = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    SenderReference = table.Column<string>(type: "TEXT", nullable: true),
                    ReceiverReference = table.Column<string>(type: "TEXT", nullable: true),
                    InstructionsForBeneficiary = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwiftMessages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwiftMessages");
        }
    }
}
