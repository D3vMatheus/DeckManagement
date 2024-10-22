using DeckManager.Context;
using DeckManager.Models;
using DeckManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeckManager.Repositories.Services
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(DeckManagerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Card>> GetByCardNumberAsync(string number)
        {
            var card = await _context.cards.Where(c => c.Number == number).ToListAsync();

            if (!CardNumberExists(number))
                throw new ArgumentNullException(nameof(card));

            return card;
        }

        public bool CardNumberExists(string number)
        {
            return _context.cards.Any(c => c.Number == number);
        }
    }
}
