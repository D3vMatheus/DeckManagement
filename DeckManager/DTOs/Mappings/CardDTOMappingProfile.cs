using AutoMapper;
using DeckManager.Models;

namespace DeckManager.DTOs.Mappings
{
    public class CardDTOMappingProfile : Profile
    {   
        public CardDTOMappingProfile() {
            CreateMap<Card, CardDTO>().ReverseMap();
        }
    }
}
