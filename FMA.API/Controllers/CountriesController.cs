using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FMA.API.Services;
using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;

namespace FMA.API.Controllers
{
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        private IFmaRepository _fmaRepository;
        public CountriesController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet()]
        public IActionResult GetCountries()
        {
            var countriesFromRepo = _fmaRepository.GetCountries();

            var outerFacingModelCountries = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countriesFromRepo);

            return Ok(outerFacingModelCountries);

        }
        [HttpGet("{id}")]
        public IActionResult GetCountry(Guid id)
        {
            var countryFromRepo = _fmaRepository.GetCountry(id);

            if(countryFromRepo == null)
            {
                return NotFound();
            }

            var outerFacingModelCountry = Mapper.Map<CountryDto>(countryFromRepo);

            return Ok(outerFacingModelCountry);
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] CountryToCreateDto countryDto)
        {
            if (countryDto == null)
            {
                return BadRequest();
            }

            var countryToBeCreated = Mapper.Map<Country>(countryDto);

            if(_fmaRepository.CountryExist(countryToBeCreated))
            {
                return StatusCode(422, new { message = "Country already exists" });
            }

            var createdCountry = _fmaRepository.AddCountry(countryToBeCreated);

            if (!_fmaRepository.Save())
            {

                return StatusCode(500, "An error saving resource");
            }

            var outerFacingModelCountry = Mapper.Map<CountryDto>(createdCountry);

            return Created("", outerFacingModelCountry);
        }
    }
}
