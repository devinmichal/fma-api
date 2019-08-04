using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FMA.API.Services;


namespace FMA.API.Controllers
{
    [Route("api/affiliations")]
    public class AffiliationsController : Controller
    {
        private IFmaRepository _fmaRepository;
        public AffiliationsController(IFmaRepository fmaRepository)
        {
            _fmaRepository = fmaRepository;
        }

        [HttpGet()]
        public IActionResult GetAffiliations()
        {
            var affiliationsFromRepo = _fmaRepository.GetAffiliations();

            return Ok(affiliationsFromRepo);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAffilation(Guid id)
        {
            var affiliationFromRepo = _fmaRepository.GetAffiliation(id);

            if(affiliationFromRepo == null)
            {
                return NotFound();
            }

            return Ok(affiliationFromRepo);
        }
    }
}
