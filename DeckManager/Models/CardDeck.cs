using System.Collections.ObjectModel;

namespace DeckManager.Models
{
    public class CardDeck
    {
        public CardDeck() {
            Cards = new Collection<Card>();
            Decks = new Collection<Deck>();
        }
        public int CardDeckId { get; set; }
        
        public int CardId { get; set; }
        public ICollection<Card> Cards { get; set; }
        
        public int DeckId { get; set; }
        public ICollection<Deck> Decks { get; set; }
    }
}
