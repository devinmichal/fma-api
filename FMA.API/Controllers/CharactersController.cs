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
        public IActionResult getCharacters()
        {
            var charactersFromRepo = _fmaRepository.GetCharacters();
            var characters = Mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDto>>(charactersFromRepo);
            
            
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult getCharacter(Guid id)
        {
            var characterFromRepo = _fmaRepository.GetCharacter(id);
            if(characterFromRepo == null)
            {
                return NotFound();
            }

            var character = Mapper.Map<Character, CharacterDto>(characterFromRepo);
            return Ok(character);
        }
        
    }
}