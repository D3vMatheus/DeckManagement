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
    }
}
