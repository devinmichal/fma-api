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
    public class NationalitiesController : Controller
    {
        private IFmaRepository _fmaRepository;
        public NationalitiesController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet("nationalities")]
        public IActionResult GetNationalities()
        {
            var nationalitiesFromRepo = _fmaRepository.GetNationalities();

            var nationalities = Mapper.Map<IEnumerable<Nationality>, IEnumerable<NationalityDto>>(nationalitiesFromRepo);

            return Ok(nationalities);
        }

        [HttpGet("nationalities/{id}")]
        public IActionResult GetNationality(Guid id)
        {
            var nationalityFromRepo = _fmaRepository.GetNationality(id);

            if(nationalityFromRepo == null)
            {
                return NotFound();
            }
            var nationality = Mapper.Map<Nationality, NationalityDto>(nationalityFromRepo);

            return Ok(nationality);
        }

        [HttpPost("countries/{countryId}/nationalities")]
        public IActionResult CreateNationality([FromRoute] Guid countryId, [FromBody] NationalityToCreateDto nationalityToCreateDto)
        {
           
            if(nationalityToCreateDto == null)
            {
                return BadRequest(new { message = "Need resource in the body"});
            }

           
            if(!_fmaRepository.CountryExist(countryId))
            {
                return NotFound(new { message = "Country doesn't exist"});
            }

            var nationalityToBeCreated = Mapper.Map<Nationality>(nationalityToCreateDto);

          
            if (_fmaRepository.NationalityExist(nationalityToBeCreated))
            {
                return StatusCode(422, new { message = "Resource already exist. Cannot create." });
            }

           
           var createdNationality =  _fmaRepository.AddNationality(nationalityToBeCreated, countryId);
        
            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Cannot save resource." });
            }
            
            var outerFacingModelNationality = Mapper.Map<NationalityDto>(createdNationality);

            return Created("", outerFacingModelNationality);
        }
    }
}
