using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Controllers
{
    [Route("api/characters")]
    public class CharactersController : Controller
    {
        private IFmaRepository _fmaRepository;
        
        
        public CharactersController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
           
          
        }

        [HttpGet()]
        public IActionResult GetCharacters()
        {
            var charactersFromRepo = _fmaRepository.GetCharacters();
            var characters = Mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDto>>(charactersFromRepo);
            
            
            return Ok(characters);
        }

        [HttpGet("{id}", Name = "GetCharacter")]
        public IActionResult GetCharacter(Guid id)
        {
            var characterFromRepo = _fmaRepository.GetCharacter(id);
            if(characterFromRepo == null)
            {
                return NotFound();
            }

            var character = Mapper.Map<Character, CharacterDto>(characterFromRepo);
            return Ok(character);
        }
        [HttpPost("")]
        public IActionResult CreateCharacter([FromBody]CharacterToCreateDto characterDto)
        {
            if (characterDto == null)
            {
                return BadRequest();
            }

            var characterToBeCreated = Mapper.Map<Character>(characterDto);

            var exist = _fmaRepository.CharacterExist(characterToBeCreated);

            if(exist)
            {
                return StatusCode(422, "Character already exists");
            }

           var createdCharacter = _fmaRepository.AddCharacter(characterToBeCreated);

            if(!_fmaRepository.Save()) {

                return StatusCode(500, "An error saving resource");
            }

            var outerFacingModelCharacter = Mapper.Map<CharacterDto>(createdCharacter);

            return Created("",outerFacingModelCharacter);
        }

       
        
    }
}