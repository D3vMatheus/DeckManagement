using DeckManager.Models;

namespace DeckManager.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<IEnumerable<Card>> GetByCardNumberAsync(string number);
    }
}
