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
using FMA.API.Helper;

namespace FMA.API.Controllers
{
    [Route("api/")]
    public class NationalitiesController : Controller
    {
        private IFmaRepository _fmaRepository;
        private IMapper _mapper;
        public NationalitiesController(IFmaRepository fmaRepository, IMapper mapper)
        {
            _fmaRepository = fmaRepository;
            _mapper = mapper;
        }

        [HttpGet("nationalities")]
        public IActionResult GetNationalities(ResourceParameters parameters)
        {
            var outerFacingModelNationalities = _fmaRepository.GetNationalities(parameters);

          //  var nationalities = Mapper.Map<IEnumerable<Nationality>, IEnumerable<NationalityDto>>(nationalitiesFromRepo);

            return Ok(outerFacingModelNationalities);
        }

        [HttpGet("nationalities/{id}", Name = "GetNationality")]
        public IActionResult GetNationality(Guid id)
        {
            var nationalityFromRepo = _fmaRepository.GetNationality(id);

            if (nationalityFromRepo == null)
            {
                return NotFound();
            }
            var nationality = _mapper.Map<Nationality, NationalityDto>(nationalityFromRepo);

            return Ok(nationality);
        }

        [HttpPost("countries/{countryId}/nationalities")]
        public IActionResult CreateNationality([FromRoute] Guid countryId, [FromBody] NationalityToCreateDto nationalityToCreateDto)
        {

            if (nationalityToCreateDto == null)
            {
                return BadRequest(new { message = "Need resource in the body" });
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_fmaRepository.CountryExist(countryId))
            {
                return NotFound(new { message = "Country doesn't exist" });
            }

            var nationalityToBeCreated = _mapper.Map<Nationality>(nationalityToCreateDto);


            if (_fmaRepository.NationalityExist(nationalityToBeCreated))
            {
                return StatusCode(422, new { message = "Resource already exist. Cannot create." });
            }


            var createdNationality = _fmaRepository.AddNationality(nationalityToBeCreated, countryId);

            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Cannot save resource." });
            }

            var outerFacingModelNationality = _mapper.Map<NationalityDto>(createdNationality);

            return Created("", outerFacingModelNationality);
        }

        [HttpDelete("nationalities/{id}")]
        public IActionResult DeleteNationality([FromRoute] Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!_fmaRepository.NationalityExist(id))
            {
                return NotFound();
            }

            var nationality = _fmaRepository.GetNationality(id);
            _fmaRepository.DeleteNationality(nationality);

            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem deleting nationality" });
            }

            return NoContent();
        }

        [HttpPut("nationalites/{id}")]
        public IActionResult UpdateNationality([FromRoute] Guid id, [FromBody] NationalityToUpdateDto nationality)
        {
            if (nationality == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (!_fmaRepository.NationalityExist(id))
            {
                var nationalityToCreate = _mapper.Map<Nationality>(nationality);
                nationalityToCreate.Id = id;

                _fmaRepository.AddNationality(nationalityToCreate);

                if (!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var nationalityDto = _mapper.Map<Nationality>(nationalityToCreate);

                return CreatedAtRoute("GetNationality", new { id = id }, nationalityDto);
            }

            var nationalityFromRepo = _fmaRepository.GetNationality(id);
            _mapper.Map(nationality, nationalityFromRepo);

            _fmaRepository.UpdateNationality(nationalityFromRepo);

            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem updating nationality" });
            }

            var outerFacingModelNationality = _mapper.Map<NationalityDto>(nationalityFromRepo);
            return Ok(outerFacingModelNationality);
        }

        [HttpPatch("nationalities/{id}")]
        public IActionResult PartialNationalityUpdate([FromRoute] Guid id,
            [FromBody]JsonPatchDocument<NationalityToUpdateDto> nationality) {

            if(nationality is null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.NationalityExist(id))
            {
                var nationalityUpdateDto = new NationalityToUpdateDto();

                nationality.ApplyTo(nationalityUpdateDto, ModelState);

                TryValidateModel(nationalityUpdateDto);

                if(!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var nationalityToCreate = _mapper.Map<Nationality>(nationalityUpdateDto);

                nationalityToCreate.Id = id;

                _fmaRepository.AddNationality(nationalityToCreate);

                if(!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var nationalityDto = _mapper.Map<NationalityDto>(nationalityToCreate);


                return CreatedAtRoute("GetNationality", new { id = id }, nationalityDto);
            }

            var nationalityFromRepo = _fmaRepository.GetNationality(id);
            var nationalityToUpdate = _mapper.Map<NationalityToUpdateDto>(nationalityFromRepo);

            nationality.ApplyTo(nationalityToUpdate, ModelState);

            TryValidateModel(nationalityToUpdate);

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            _mapper.Map(nationalityToUpdate, nationalityFromRepo);

            _fmaRepository.UpdateNationality(nationalityFromRepo);


            if(!_fmaRepository.Save())
            {
                throw new Exception();
            }

            var outerFacingModelNationality = _mapper.Map<CountryDto>(nationalityFromRepo);

            return Ok(outerFacingModelNationality);

        }
    }
}
