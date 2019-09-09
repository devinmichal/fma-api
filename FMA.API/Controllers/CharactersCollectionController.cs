using FMA.API.Models;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FMA.API.Entities;
using FMA.API.Helper;

namespace FMA.API.Controllers
{
    [Route("api/CharactersCollection")]
    public class CharactersCollectionController : Controller
    {
        private IFmaRepository _fmaRepository; 
        public CharactersCollectionController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }
        [HttpPost()]

        public IActionResult CreateCharacterCollection([FromBody] IEnumerable<CharacterToCreateDto> characterToCreateDtos)
        {
            if(characterToCreateDtos == null)
            {
                return BadRequest(new { message = "Need resources in the body" });
            }

            
            
            var charactersToCreate = Mapper.Map<IEnumerable<Character>>(characterToCreateDtos);
            foreach(var characterToCreate in charactersToCreate) { 
                if(_fmaRepository.CharacterExist(characterToCreate))
                {
                    return StatusCode(422, new { message = "Resouce already exist" });
                }

                _fmaRepository.AddCharacter(characterToCreate);
            }

            if(!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Couldn't save resource" });
            }
            var outerFacingModelCharacters = Mapper.Map<IEnumerable<CharacterDto>>(charactersToCreate);

            var idsAsString = string.Join(",", outerFacingModelCharacters.Select(c => c.Id));

            return CreatedAtRoute("GetCharacterCollection",new { ids = idsAsString },outerFacingModelCharacters);
        }

        [HttpGet("({ids})", Name = "GetCharacterCollection")]
        public IActionResult GetCharactersCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if(ids == null)
            {
                return BadRequest(new { message = "Need resource ids"});
            }

            var characters = _fmaRepository.GetCharacters(ids);

            if(!(ids.Count() == characters.Count()))
            {
                return NotFound(new { message = "Resource(s) don't exist" });
            }

            var outerFacingModelCharacters = Mapper.Map<IEnumerable<CharacterDto>>(characters);

            return Ok(outerFacingModelCharacters);

        }
    }
}
