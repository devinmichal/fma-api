using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FMA.API.Models;
using FMA.API.Entities;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet("{id}", Name ="GetOccupation")]
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

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteOccupation([FromRoute] Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.OccupationExist(id))
            {
                return NotFound();
            }

            var occupation = _fmaRepository.GetOccupation(id);
            _fmaRepository.DeleteOccupation(occupation);

            if(!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem deleting occupation" });
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOccupation([FromRoute] Guid id, [FromBody] OccupationToUpdateDto occupation)
        {
            if(occupation == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if(_fmaRepository.OccupationExist(id))
            {
                var occupationToCreate = Mapper.Map<Occupation>(occupation);
                occupationToCreate.Id = id;

                _fmaRepository.AddOccupation(occupationToCreate);

                if(!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var occupationDto = Mapper.Map<OccupationDto>(occupationToCreate);

                return CreatedAtRoute("GetOccupation",new {id = id },occupationDto);
            }

            var occupationFromRepo = _fmaRepository.GetOccupation(id);
            Mapper.Map(occupation, occupationFromRepo);

            _fmaRepository.UpdateOccupation(occupationFromRepo);

            if(!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem updating occupation" });
            }

            var outerFacingModelOccupation = Mapper.Map<OccupationDto>(occupationFromRepo);

            return Ok(outerFacingModelOccupation);
        }

        [HttpPatch("{id}")]
        public IActionResult PartialOccupationUpdate( [FromRoute] Guid id,
            [FromBody] JsonPatchDocument<OccupationToUpdateDto> occupation)
        {
            if(occupation is null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.OccupationExist(id))
            {

                var occupationToUpdateDto = new OccupationToUpdateDto();

                occupation.ApplyTo(occupationToUpdateDto);

                var occupationToCreate = Mapper.Map<Occupation>(occupationToUpdateDto);

                occupationToCreate.Id = id;

                _fmaRepository.AddOccupation(occupationToCreate);

                if(!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var occupationDto = Mapper.Map<OccupationDto>(occupationToCreate);

                return CreatedAtRoute("GetOccupation", new { id = id }, occupationDto);
            }

            var occupationFromRepo = _fmaRepository.GetOccupation(id);
            var occupationToUpdate = new OccupationToUpdateDto();

            occupation.ApplyTo(occupationToUpdate);

            Mapper.Map(occupationToUpdate, occupationFromRepo);

            _fmaRepository.UpdateOccupation(occupationFromRepo);

            if(!_fmaRepository.Save())
            {
                throw new Exception();
            }

            var outerFacingModelOccupation = Mapper.Map<OccupationDto>(occupationFromRepo);



            return Ok(outerFacingModelOccupation);
        }
    }
}
