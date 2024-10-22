using DeckManager.Context;
using DeckManager.Repositories.Interfaces;

namespace DeckManager.Repositories.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DeckManagerDbContext _context;
        private ICardRepository _cardRepo;
        private IDeckRepository _deckRepo;

        public UnitOfWork(DeckManagerDbContext context)
        {
            _context = context;
        }

        public ICardRepository CardRepository
        {
            get
            {
                return _cardRepo = _cardRepo ?? new CardRepository(_context);
            }
        }

        public IDeckRepository DeckRepository
        {
            get
            {
                return _deckRepo = _deckRepo ?? new DeckRepository(_context);

            }
        }

        public async Task commitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
