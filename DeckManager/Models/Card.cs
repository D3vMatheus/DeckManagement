using DeckManager.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeckManager.Models
{
    public class Card
    {
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
        
        [Required]
        public string Attribute { get; set; }
        
        [Required]
        public int Lv { get; set; }
        
        [Required]
        public int PlayCost { get; set; }
        
        [Required]
        public int DigimonPower { get; set; }
        
        [Required]
        public string DigievolutionCondition { get; set; }
        
        [Required]
        public string Form { get; set; }
        
        [Required]
        public string MainEffect { get; set; }
        
        [Required]
        public string SecondaryEffect { get; set; }


        //[Required]
        //public int DeckId { get; set; }

        //[JsonIgnore]
        //public Deck? Deck { get; set; }
    }
}
