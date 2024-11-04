using DeckManager.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeckManager.DTOs
{
    public class DeckDTO
    {
        public int DeckId { get; set; }

        [DisplayName("Deck Name")]
        public string Name { get; set; }

        [DisplayName("Deck Url image")]
        public string? ImageUrl { get; set; }

        public IEnumerable<Card>? Cards { get; set; } = [];
    }
}
