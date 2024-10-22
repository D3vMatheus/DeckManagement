using DeckManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DeckManager.Context
{
    public class DeckManagerDbContext : DbContext
    {
        public DeckManagerDbContext(DbContextOptions<DeckManagerDbContext> options) : base(options) { }

        public DbSet<Card> cards {  get; set; }
        public DbSet<Deck> decks {  get; set; }
    }
}
