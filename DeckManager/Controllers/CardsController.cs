using DeckManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeckManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CardsController(ICardRepository cardRepository,
                               IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }
    }
}
