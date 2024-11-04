using DeckManager.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeckManager.Models
{
    public class Card
    {
        public Card() {
            Decks  = new Collection<Deck>();
        }
        public int CardId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{1,2}-\d{3}$", ErrorMessage = "Card number must be XX0-000 or YY11-111")]
        public string Number {  get; set; }
        
        [Required]
        public string UrlImage { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public CardRarity Rarity { get; set; }
        
        [Required]
        public CardColor Colour { get; set; }
        
        [Required]
        public CardCategory Category { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        public string Attribute { get; set; }
        
        public int Lv { get; set; }
        
        public int PlayCost { get; set; }
        
        [Required]
        public int DigimonPower { get; set; }
        
        public string DigievolutionCondition { get; set; }
        
        public string Form { get; set; }
        
        public string MainEffect { get; set; }
        
        public string SecondaryEffect { get; set; }

        public int DeckId { get; set; }

        [JsonIgnore]
        public ICollection<Deck>? Decks { get; set; }
    }
}
