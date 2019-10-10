using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FMA.API.Services;
using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using FMA.API.Helper;

namespace FMA.API.Controllers
{
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        private IFmaRepository _fmaRepository;
        private IMapper _mapper;
        public CountriesController(IFmaRepository fmaRepository, IMapper mapper)
        {
            _fmaRepository = fmaRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetCountries(ResourceParameters parameters)
        {
            //need to rename GetCountries to GetCountriesDto

            var outerFacingModelCountries = _fmaRepository.GetCountries(parameters);

            //var outerFacingModelCountries = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countriesFromRepo);

            return Ok(outerFacingModelCountries);

        }
        [HttpGet("{id}", Name = "GetCountry")]
        public IActionResult GetCountry(Guid id)
        {
            var countryFromRepo = _fmaRepository.GetCountry(id);

            if (countryFromRepo == null)
            {
                return NotFound();
            }

            var outerFacingModelCountry = _mapper.Map<CountryDto>(countryFromRepo);

            return Ok(outerFacingModelCountry);
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] CountryToCreateDto countryDto)
        {
            if (countryDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var countryToBeCreated = _mapper.Map<Country>(countryDto);

            if (_fmaRepository.CountryExist(countryToBeCreated))
            {
                return StatusCode(422, new { message = "Country already exists" });
            }

            var createdCountry = _fmaRepository.AddCountry(countryToBeCreated);

            if (!_fmaRepository.Save())
            {

                return StatusCode(500, "An error saving resource");
            }

            var outerFacingModelCountry = _mapper.Map<CountryDto>(createdCountry);

            return Created("", outerFacingModelCountry);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry([FromRoute] Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.CountryExist(id))
            {
                return NotFound();
            }

            var country = _fmaRepository.GetCountry(id);

            _fmaRepository.DeleteCountry(country);

            if(!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem deleting resource" });
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry([FromRoute] Guid id, [FromBody] CountryToUpdateDto country)
        {
            if(country == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if(!_fmaRepository.CountryExist(id))
            {
                var countryToCreate = _mapper.Map<Country>(country);
                countryToCreate.Id = id;

                _fmaRepository.AddCountry(countryToCreate);

                if (!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var countryDto = _mapper.Map<CountryDto>(countryToCreate);

                return CreatedAtRoute("GetCountry",new { id = id},countryDto);
            }

            var countryFromRepo = _fmaRepository.GetCountry(id);
            _mapper.Map(country, countryFromRepo);

            _fmaRepository.UpdateCountry(countryFromRepo);

            if (!_fmaRepository.Save())
            {
                return StatusCode(500, new { message = "Problem updating country" });
            }

            var outerFacingModelCountry = _mapper.Map<CountryDto>(countryFromRepo);

            return Ok(outerFacingModelCountry);
        }

        [HttpPatch("{id}")]
        public IActionResult PartialCountryUpdate([FromRoute] Guid countryId,
            [FromBody] JsonPatchDocument<CountryToUpdateDto> country) {


            if(country is null)
            {
                return BadRequest();
            }

            if(!_fmaRepository.CountryExist(countryId))
            {
                var countryToUpdate = new CountryToUpdateDto();

                country.ApplyTo(countryToUpdate, ModelState);

                TryValidateModel(countryToUpdate);

                if(!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var countryToCreate = _mapper.Map<Country>(countryToUpdate);

                countryToCreate.Id = countryId;

                _fmaRepository.AddCountry(countryToCreate);

                if(!_fmaRepository.Save())
                {
                    throw new Exception();
                }

                var countryDto = _mapper.Map<CountryDto>(countryToCreate);

                return CreatedAtRoute("GetCountry",new { id = countryId},countryDto);
            }

            var countryFromRepo = _fmaRepository.GetCountry(countryId);
            var countryToUpdateDto = _mapper.Map<CountryToUpdateDto>(countryFromRepo);

            country.ApplyTo(countryToUpdateDto, ModelState);

            TryValidateModel(countryToUpdateDto);

            if(!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            _mapper.Map(countryToUpdateDto, countryFromRepo);

            _fmaRepository.UpdateCountry(countryFromRepo);

            if (!_fmaRepository.Save())
            {
                throw new Exception();
            }

            var outerFacingModelCountry = _mapper.Map<CountryDto>(countryFromRepo);

            return Ok(outerFacingModelCountry);
        }

    }
}
