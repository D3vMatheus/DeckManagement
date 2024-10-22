namespace DeckManager.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICardRepository CardRepository { get; }
        IDeckRepository DeckRepository { get; }

        Task commitAsync();
    }
}
