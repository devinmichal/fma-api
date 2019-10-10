using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMA.API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FMA.API.Models;
using FMA.API.Entities;
using FMA.API.Helper;

namespace FMA.API.Controllers
{
    [Route("api/currencies")]
    public class CurrenciesController : Controller
    {
        private IFmaRepository _fmaRepository;
        private IMapper _mapper;
        public CurrenciesController(IFmaRepository fmaRepository, IMapper mapper)
        {
            _fmaRepository = fmaRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetCurrencies(ResourceParameters parameters)
        {
            var currenciesFromRepo = _fmaRepository.GetCurrencies(parameters);

            var outerFacingModelCurrencies = _mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyDto>>(currenciesFromRepo);

            return Ok(outerFacingModelCurrencies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCurrency(Guid id)
        {
            var currencyFromRepo = _fmaRepository.GetCurrency(id);

            if (currencyFromRepo == null)
            {
                return NotFound();
            }

            var outerFacingModelCurrency = _mapper.Map<CurrencyDto>(currencyFromRepo);

            return Ok(outerFacingModelCurrency);
        }
    }
}
