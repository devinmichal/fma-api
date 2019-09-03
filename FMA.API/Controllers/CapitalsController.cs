using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;

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
        [HttpGet("capitals/{id}")]
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
    }
}
