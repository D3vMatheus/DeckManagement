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
       
        [Required]
        [DisplayName("Deck Name")]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Deck Url image")]
        public string? ImageUrl { get; set; }
        
        public ICollection<Card>? Cards { get; set; }
    }
}
