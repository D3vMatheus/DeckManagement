using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeckManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    UrlImage = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    Colour = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Attribute = table.Column<string>(type: "text", nullable: false),
                    Lv = table.Column<int>(type: "integer", nullable: false),
                    PlayCost = table.Column<int>(type: "integer", nullable: false),
                    DigimonPower = table.Column<int>(type: "integer", nullable: false),
                    DigievolutionCondition = table.Column<string>(type: "text", nullable: false),
                    Form = table.Column<string>(type: "text", nullable: false),
                    MainEffect = table.Column<string>(type: "text", nullable: false),
                    SecondaryEffect = table.Column<string>(type: "text", nullable: false),
                    DeckId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "decks",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_decks", x => x.DeckId);
                });

            migrationBuilder.CreateTable(
                name: "CardDeck",
                columns: table => new
                {
                    CardsCardId = table.Column<int>(type: "integer", nullable: false),
                    DecksDeckId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDeck", x => new { x.CardsCardId, x.DecksDeckId });
                    table.ForeignKey(
                        name: "FK_CardDeck_cards_CardsCardId",
                        column: x => x.CardsCardId,
                        principalTable: "cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardDeck_decks_DecksDeckId",
                        column: x => x.DecksDeckId,
                        principalTable: "decks",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardDeck_DecksDeckId",
                table: "CardDeck",
                column: "DecksDeckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDeck");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "decks");
        }
    }
}
