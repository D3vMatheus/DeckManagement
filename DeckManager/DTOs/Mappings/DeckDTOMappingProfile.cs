using AutoMapper;
using DeckManager.Models;

namespace DeckManager.DTOs.Mappings
{
    public class DeckDTOMappingProfile : Profile
    {
        public DeckDTOMappingProfile() {
            CreateMap<Deck, DeckDTO>().ReverseMap();
        }
    }
}
