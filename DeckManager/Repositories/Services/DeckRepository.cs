using DeckManager.Context;
using DeckManager.Models;
using DeckManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeckManager.Repositories.Services
{
    public class DeckRepository : Repository<Deck>, IDeckRepository
    {
        public DeckRepository(DeckManagerDbContext context) : base(context)
        {
        }

        public async Task<Card> AddCardIntoDeck(int deckId, string number)
        {
            var card = await _context.cards.FirstOrDefaultAsync(c => c.Number == number);
            var deck = await _context.decks.Include(d => d.Cards).FirstOrDefaultAsync(d => d.DeckId == deckId);

            if (card is null || deck is null)
                throw new ArgumentNullException("Deck or card doesn't exist");

            if (deck.Cards == null)
                throw new ArgumentNullException("Deck or card doesn't exist");

            var maxDuplicates = deck.Cards.Count(c => c.CardId == card.CardId);

            if(maxDuplicates > 5)
                throw new InvalidOperationException("Card limit exceeded. You can only add up to 5 of the same card.");

            deck.Cards.Add(card);

            return card;
        }

        //public Task<Card> RemoveCardFromDeck(int deckId, string number)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
