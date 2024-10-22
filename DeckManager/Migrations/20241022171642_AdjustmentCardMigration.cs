using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeckManager.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentCardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                table: "cards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards",
                column: "DeckId",
                principalTable: "decks",
                principalColumn: "DeckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                table: "cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards",
                column: "DeckId",
                principalTable: "decks",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
