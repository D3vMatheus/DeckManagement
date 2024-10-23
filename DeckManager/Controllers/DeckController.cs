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
    public class DeckController : ControllerBase
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private DeckController(IDeckRepository deckRepository,
                               IMapper mapper,
                               IUnitOfWork unitOfWork)
        {
            _deckRepository = deckRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Decks")]
        public ActionResult<IEnumerable<DeckDTO>> GetDecks()
        {
            var decks = _unitOfWork.DeckRepository.GetAll();

            if (decks is null)
                return NotFound("Any deck(s) wasn't found");

            var  decksDto = _mapper.Map<DeckDTO>(decks);
            return Ok(decksDto);

        }

        [HttpGet("{id}", Name="GetDeckById")]
        public ActionResult<IEnumerable<DeckDTO>> GetDeckById(int id)
        {
            var deck = _unitOfWork.DeckRepository.Get(d => d.DeckId == id);
            
            if (deck is null)
                return NotFound("Deck(s) wasn't found");

            var deckDto = _mapper.Map<DeckDTO>(deck);

            return Ok(deckDto);
        }

        [HttpPost]
        public async Task<ActionResult<DeckDTO>> PostDeck(DeckDTO deckDto)
        {
            if (deckDto is null)
                return BadRequest("Invalid information detected");

            var deck = _mapper.Map<Deck>(deckDto);

            var newDeck = _unitOfWork.DeckRepository.Post(deck);
            await _unitOfWork.commitAsync();

            var newDeckDto = _mapper.Map<DeckDTO>(deck);

            return new CreatedAtRouteResult("GetDeckById", new { id = newDeckDto.DeckId }, newDeckDto);
        }

        [HttpPut]
        public async Task<ActionResult> PutDeck(int id, DeckDTO deckDTO)
        {
            if (id != deckDTO.DeckId)
                return BadRequest("Invalid information detected");

            var deck = _mapper.Map<Deck>(deckDTO);
            _unitOfWork.DeckRepository.Update(deck);
            await _unitOfWork.commitAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDeck(int id)
        {
            var deck = _unitOfWork.DeckRepository.Get(d => d.DeckId == id);

            if(deck is null)
                return NotFound("Deck doesn't exist");

            _unitOfWork.DeckRepository.Delete(deck);
            await _unitOfWork.commitAsync();

            return NoContent();
        }
    }
}
