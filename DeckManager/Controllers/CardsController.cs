using AutoMapper;
using DeckManager.DTOs;
using DeckManager.Models;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CardsController(ICardRepository cardRepository,
                               IMapper mapper,
                               IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        [HttpGet("Cards")]
        public ActionResult<IEnumerable<CardDTO>> GetCards()
        {
            var cards = _unitOfWork.CardRepository.GetAll();
            
            if (cards == null)
                return NotFound("Cards not found or doesn't exist");
            
            var cardsDto = _mapper.Map<IEnumerable<CardDTO>>(cards);
            
            return Ok(cardsDto);
        }

        [HttpGet("{id}", Name = "GetCardById")]
        public ActionResult<CardDTO> GetById(int id)
        {
            var card = _unitOfWork.CardRepository.Get(c => c.CardId == id);

            if (card == null)
                return NotFound("Cards not found or doesn't exist");

            var cardDto = _mapper.Map<CardDTO>(card);

            return Ok(cardDto);
        }

        [HttpGet("{number:regex(^[[A-Z]]{{2}}\\d{{1,2}}-\\d{{3}}$)}")]
        public async Task<ActionResult<CardDTO>> GetByCardNumber(string number)
        {
            if (number == null)
                return NotFound();

            var card = await _unitOfWork.CardRepository.GetByCardNumberAsync(number);

            var cardDto = _mapper.Map<CardDTO>(card);

            return Ok(cardDto);


        }

        [HttpPost]
        public async Task<ActionResult<CardDTO>> PostCard(CardDTO cardDto)
        {
            if(cardDto is null)
                return BadRequest("Invalid information detected");

            var card = _mapper.Map<Card>(cardDto);

            var newCard = _unitOfWork.CardRepository.Post(card);
            await _unitOfWork.commitAsync();

            var newCardDto = _mapper.Map<CardDTO>(newCard);

            return new CreatedAtRouteResult( "GetCardById", new { id = newCardDto.CardId }, newCardDto );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCard(int id, CardDTO cardDto)
        {
            if (id != cardDto.CardId)
                return BadRequest("Invalid information detected");

            var card = _mapper.Map<Card>(cardDto);
            _unitOfWork.CardRepository.Update(card);
            await _unitOfWork.commitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCard(int id)
        {
            var card = _unitOfWork.CardRepository.Get(c => c.CardId == id);

            if (card is null)
                return NotFound("Card not found");

            _unitOfWork.CardRepository.Delete(card);
            await _unitOfWork.commitAsync();

            return NoContent();
        }
    }
}
