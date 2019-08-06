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
    [Route("api/capitals")]
    public class CapitalsController : Controller
    {
        private IFmaRepository _fmaRepository;
        public CapitalsController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet("")]
        public IActionResult GetCapitals()
        {
            var capitalsFromRepo = _fmaRepository.GetCapitals();

            var outerFacingModelCapitals = Mapper.Map<IEnumerable<Capital>, IEnumerable<CapitalDto>>(capitalsFromRepo);

            return Ok(outerFacingModelCapitals);
        }
        [HttpGet("{id}")]
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
    }
}
