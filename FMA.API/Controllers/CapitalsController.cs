using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FMA.API.Controllers
{
    [Route("api/")]
    public class CapitalsController : Controller
    {
        private IFmaRepository _fmaRepository;
        public CapitalsController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet("capitals")]
        public IActionResult GetCapitals()
        {
            var capitalsFromRepo = _fmaRepository.GetCapitals();

            var outerFacingModelCapitals = Mapper.Map<IEnumerable<Capital>, IEnumerable<CapitalDto>>(capitalsFromRepo);

            return Ok(outerFacingModelCapitals);
        }
        [HttpGet("capitals/{id}", Name ="GetCapital")]
        public IActionResult GetCapital(Guid id)
        {
            var capitalFromRepo = _fmaRepository.GetCapital(id);

            if(capitalFromRepo == null)
            {
                return NotFound();
            }

            var outFacingModelCapital = Mapper.Map<CapitalDto>(capitalFromRepo);

            return Ok(outFacingModelCapital);
        }

        
        [HttpPost("countries/{countryId}/capitals")]
        public IActionResult CreateCapitalForCountry([FromRoute] Guid countryId, [FromBody] CapitalToCreateDto capitalToCreateDto)
        {
            if(capitalToCreateDto == null)
            {
                return BadRequest(new { message = "Need resource in the body"});
            }

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if(!_fmaRepository.CountryExist(countryId))
            {
                return NotFound(new { message ="Country doesn't exist"});
            }
            var capitalToCreated = Mapper.Map<Capital>(capitalToCreateDto);

            if(_fmaRepository.CapitalExist(capitalToCreated))
            {
                return StatusCode(422, new { message = "Capital already exist" });
            }
          
            var createdCapital = _fmaRepository.AddCapital(capitalToCreated , countryId);

            if (!_fmaRepository.Save()) {
                return StatusCode(500, new { message = "Error saving resource" });
            }

            var outerFacingModelCaptial = Mapper.Map<CapitalDto>(createdCapital);

            return Created("", outerFacingModelCaptial);
            
        }

        [HttpDelete("capitals/{id}")]
        public IActionResult DeleteCapital([FromRoute] Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.CapitalExist(id))
            {
                return NotFound();
            }

            var capital = _fmaRepository.GetCapital(id);
            _fmaRepository.DeleteCapital(capital);

            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem deleting capital" });
            }

            return NoContent();
        }

        [HttpPut("capitals/{id}")]
        public IActionResult UpdateCapital([FromRoute] Guid id , [FromBody] CapitalToUpdateDto capital) 
        {
            if(capital == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_fmaRepository.CapitalExist(id))
            {
                var capitalToCreate = Mapper.Map<Capital>(capital);
                capitalToCreate.Id = id;

                _fmaRepository.AddCapital(capitalToCreate);

                if(!_fmaRepository.Save())
                {
                    return StatusCode(500, new { message = "Problem creating capital" });
                }

                var capitalDto = Mapper.Map<CapitalDto>(capitalToCreate);

                return CreatedAtRoute("GetCapital",new { id = capitalToCreate.Id},capitalDto);
            }

            var capitalFromRepo = _fmaRepository.GetCapital(id);

            Mapper.Map(capital, capitalFromRepo);

            _fmaRepository.UpdateCapital(capitalFromRepo);
            
            if(!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Couldn't update capital" });
            }

            var outerFacingModelCapital = Mapper.Map<CapitalDto>(capitalFromRepo);

            return Ok(outerFacingModelCapital);
        }

        [HttpPatch("capitals/{id}")]
        public IActionResult PartiallyUpdateCapital([FromRoute] Guid id, 
            [FromBody] JsonPatchDocument<CapitalToUpdateDto> capital)
        {
            if (capital == null)
            {
                return BadRequest();
            }

            if (!_fmaRepository.CapitalExist(id))
            {
                var capitalToUpdateDto = new CapitalToUpdateDto();

                capital.ApplyTo(capitalToUpdateDto);

                var capitalToCreate = Mapper.Map<Capital>(capitalToUpdateDto);
                capitalToCreate.Id = id;

                _fmaRepository.AddCapital(capitalToCreate);

                if (!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var capitalDto = Mapper.Map<CapitalDto>(capitalToCreate);

                return CreatedAtRoute("GetCapital", new { id = capitalToCreate.Id }, capitalDto);
            }

            var capitalFromRepo = _fmaRepository.GetCapital(id);

            var capitalToPatch = Mapper.Map<CapitalToUpdateDto>(capitalFromRepo);

            capital.ApplyTo(capitalToPatch);

            Mapper.Map(capitalToPatch, capitalFromRepo);

            _fmaRepository.UpdateCapital(capitalFromRepo);

            if(!_fmaRepository.Save())
            {
                throw new Exception();
            }
            var outerFacingModelCapital = Mapper.Map<CapitalDto>(capitalFromRepo);

            return Ok(outerFacingModelCapital);
        }
    }
}
