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
    [Route("api/nationalities")]
    public class NationalitiesController : Controller
    {
        private IFmaRepository _fmaRepository;
        public NationalitiesController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet()]
        public IActionResult GetNationalities()
        {
            var nationalitiesFromRepo = _fmaRepository.GetNationalities();

            var nationalities = Mapper.Map<IEnumerable<Nationality>, IEnumerable<NationalityDto>>(nationalitiesFromRepo);

            return Ok(nationalities);
        }

        [HttpGet("{id}")]
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
    }
}
