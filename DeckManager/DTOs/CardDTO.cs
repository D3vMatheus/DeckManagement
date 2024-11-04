using DeckManager.Enums;
using DeckManager.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeckManager.DTOs
{
    public class CardDTO
    {
        public int CardId { get; set; }
         
        [RegularExpression(@"^[A-Z]{2}\d{1,2}-\d{3}$", ErrorMessage = "Card number must be XX0-000 or YY11-111")]
        public string Number { get; set; }
         
        public string UrlImage { get; set; }
         
        public string Name { get; set; }
         
        public CardRarity Rarity { get; set; }
         
        public CardColor Colour { get; set; }

        public CardCategory Category { get; set; }
         
        public string Type { get; set; }
         
        public string Attribute { get; set; }
         
        public int Lv { get; set; }
         
        public int PlayCost { get; set; }
         
        public int DigimonPower { get; set; }
         
        public string DigievolutionCondition { get; set; }
         
        public string Form { get; set; }
         
        public string MainEffect { get; set; }

        public string SecondaryEffect { get; set; }
    }
}
