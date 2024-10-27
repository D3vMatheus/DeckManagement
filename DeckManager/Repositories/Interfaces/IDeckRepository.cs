using DeckManager.Models;

namespace DeckManager.Repositories.Interfaces
{
    public interface IDeckRepository : IRepository<Deck>
    {
        Task<Card> AddCardIntoDeck(int deckId, string number);
        //Task<Card> RemoveCardFromDeck(int deckId, string number);
    }
}
