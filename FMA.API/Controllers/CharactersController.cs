using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.JsonPatch;
using FMA.API.Helper;

namespace FMA.API.Controllers
{
    [Route("api/characters")]
    public class CharactersController : Controller
    {
        private IFmaRepository _fmaRepository;
        private IMapper _mapper;


        public CharactersController(IFmaRepository fmaRepository, IMapper mapper)
        {
            _fmaRepository = fmaRepository;
            _mapper = mapper;


        }

        [HttpGet()]
        public IActionResult GetCharacters(ResourceParameters parameters)
        {
            var charactersFromRepo = _fmaRepository.GetCharacters(parameters);
            //var characters = Mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDto>>(charactersFromRepo);


            return Ok(charactersFromRepo);
        }

        [HttpGet("{id}", Name = "GetCharacter")]
        public IActionResult GetCharacter(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            if (!_fmaRepository.CharacterExist(id))
            {
                return NotFound();
            }
            var outerfacingModelCharacter = _fmaRepository.GetCharacterDto(id);
          
            return Ok(outerfacingModelCharacter);
        }
        [HttpPost("")]
        public IActionResult CreateCharacter([FromBody]CharacterToCreateDto characterDto)
        {
            if (characterDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return  new UnprocessableEntityObjectResult(ModelState);
            }
            
           
            var characterToBeCreated = _mapper.Map<Character>(characterDto);

            var exist = _fmaRepository.CharacterExist(characterToBeCreated);

            if (exist)
            {
                return StatusCode(422, "Character already exists");
            }

             _fmaRepository.AddCharacter(characterToBeCreated);

            if (!_fmaRepository.Save()) {

                return StatusCode(500, "An error saving resource");
            }

            var outerFacingModelCharacter = _mapper.Map<CharacterDto>(characterToBeCreated);

            return CreatedAtRoute("GetCharacter",new { id = characterToBeCreated.Id} ,outerFacingModelCharacter);
        }

        [HttpPost("{id}")]
        public IActionResult BlockCharacterCreate([FromRoute] Guid id)
        {
            if (_fmaRepository.CharacterExist(id))
            {
                return StatusCode(422, new { message = "Resource already exist" });
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult CharacterDelete([FromRoute] Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.CharacterExist(id))
            {
                return NotFound();
            }

            var character = _fmaRepository.GetCharacter(id);

            _fmaRepository.DeleteCharacter(character);

            if(!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem deleting resource" });
            }


            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult CharacterUpdate([FromRoute] Guid id, [FromBody] CharacterToUpdateDto character)
        {
            if(character == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
         
            if(!_fmaRepository.CharacterExist(id))
            {
                var characterToCreate = _mapper.Map<Character>(character);
                characterToCreate.Id = id;

                _fmaRepository.AddCharacter(characterToCreate);

                if(!_fmaRepository.Save())
                {
                    return StatusCode(500, new { message ="Problem creating character"});
                }

                var characterDto = _mapper.Map<CharacterDto>(characterToCreate);

                return CreatedAtRoute("GetCharacter", new { id =id},characterDto);
            }

            var characterFromRepo = _fmaRepository.GetCharacter(id);
            _mapper.Map(character, characterFromRepo);

            _fmaRepository.UpdateCharacter(characterFromRepo);

            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem updating character" });
            }

            var outerFacingModelCharacter = _mapper.Map<CharacterDto>(characterFromRepo);

            return Ok(outerFacingModelCharacter);
        }
        
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCharacter([FromRoute] Guid id,
            [FromBody] JsonPatchDocument<CharacterToUpdateDto> character)
        {
            if(character == null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.CharacterExist(id))
            {
                var characterToUpdateDto = new CharacterToUpdateDto();
                character.ApplyTo(characterToUpdateDto, ModelState);

                TryValidateModel(characterToUpdateDto);

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var characterToCreate = _mapper.Map<Character>(characterToUpdateDto);
                characterToCreate.Id = id;

                _fmaRepository.AddCharacter(characterToCreate);

                if(!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var characterDto = _mapper.Map<CharacterDto>(characterToCreate);

                return CreatedAtRoute("GetCharacter",new { id = id},characterDto);
            }

            var characterFromRepo = _fmaRepository.GetCharacter(id);
            var characterUpdateDto = _mapper.Map<CharacterToUpdateDto>(characterFromRepo);

            character.ApplyTo(characterUpdateDto,ModelState);

            TryValidateModel(characterUpdateDto);

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            _mapper.Map(characterUpdateDto, characterFromRepo);

            _fmaRepository.UpdateCharacter(characterFromRepo);

            if(!_fmaRepository.Save())
            {
                throw new Exception();
            }

            var outerFacingModelCharacter = _mapper.Map<CharacterDto>(characterFromRepo);

            return Ok(outerFacingModelCharacter);
        }
    }
}