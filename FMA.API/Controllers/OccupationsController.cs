using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FMA.API.Models;
using FMA.API.Entities;

namespace FMA.API.Controllers
{
    [Route("api/occupations")]
    public class OccupationsController : Controller
    {
        private IFmaRepository _fmaRepository;
        public OccupationsController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet("")]
        public IActionResult GetOccupations() {

            var occupationsFromRepo = _fmaRepository.GetOccupations();

            var outerFacingModelOccupations = Mapper.Map<IEnumerable<Occupation>,IEnumerable<OccupationDto>>(occupationsFromRepo);

            return Ok(outerFacingModelOccupations);
        }

        [HttpGet("{id}")]
        public IActionResult GetOccupation(Guid id)
        {
            var occupationFromRepo = _fmaRepository.GetOccupation(id);

            if(occupationFromRepo == null)
            {
                return NotFound();
            }

            var outFacingModelOccupation = Mapper.Map<OccupationDto>(occupationFromRepo);
            return Ok(outFacingModelOccupation);
        }

        [HttpPost()]
        public IActionResult CreateOccupation([FromBody] OccupationToCreateDto occupationToCreateDto)
        {
            if(occupationToCreateDto == null)
            {
                return BadRequest(new { message = "Need resource in the body" });
            }

            var occupationToCreate = Mapper.Map<Occupation>(occupationToCreateDto);

            if(_fmaRepository.OccupationExist(occupationToCreate))
            {
                return StatusCode(422, new { message = "Resource already exist" });
            }

            var createdOccupation = _fmaRepository.AddOccupation(occupationToCreate);

            var outerFacingModelOccupation = Mapper.Map<OccupationDto>(createdOccupation);

            return Created("", outerFacingModelOccupation);
        }
    }
}
