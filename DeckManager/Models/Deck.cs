using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeckManager.Models
{
    public class Deck
    {
        public Deck()
        {
            Cards = new Collection<Card>();
        }
        public int DeckId { get; set; }
       
        [DisplayName("Deck Name")]
        public string Name { get; set; }
        
        [DisplayName("Deck Url image")]
        public string? ImageUrl { get; set; }
        
        public int CardId { get; set; }
        public ICollection<Card>? Cards { get; set; }
    }
}
