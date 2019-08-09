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
    }
}
