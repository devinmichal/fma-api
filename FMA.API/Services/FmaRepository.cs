using FMA.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Services
{
    public class FmaRepository : IFmaRepository
    {
        private FmaContext _context;

       public FmaRepository(FmaContext context)
        {
            _context = context;
        }

     
        public Character AddCharacter(Character character)
        {
            character.Id = Guid.NewGuid();
            character.NationalityId = character.NationalityId == new Guid("00000000-0000-0000-0000-000000000000") ?  new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291") : character.NationalityId;
            character.OccupationId = character.OccupationId == new Guid("00000000-0000-0000-0000-000000000000") ? new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291") : character.OccupationId;
            character.CountryId = character.CountryId == new Guid("00000000-0000-0000-0000-000000000000") ? new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291") : character.CountryId;

            _context.Add(character);

            return character;
        }
        public IEnumerable<Character> GetCharacters()
        {
            var characters = _context.Characters
                .Include(c => c.Nationality)
                .Include(c => c.Occupation)
                .Include(c => c.Country)
                .ToList();
                

            return characters;
        }

        public Character GetCharacter(Guid id)
        {
            var character = _context.Characters
                .Include(c => c.Nationality)
                .Include(c => c.Occupation)
                .Include(c => c.Country)
                .FirstOrDefault(c => c.Id == id);

            return character;
                
                
        }

       
        public IEnumerable<Nationality> GetNationalities()
        {
            var nationalities = _context.Nationalities
                .Include(n => n.Country)
                .Include(n => n.Members)
                .ToList();

            return nationalities;
        }

        public Nationality GetNationality(Guid id)
        {
            var nationality = _context.Nationalities
                .Include(n => n.Country)
                .Include(n => n.Members)
                .FirstOrDefault(n => n.Id == id);

            return nationality;
        }

        public IEnumerable<Occupation> GetOccupations()
        {
            var occupations = _context.Occupations
                .Include(o => o.Members)
                .ToList();

            return occupations;
        }

        public Occupation GetOccupation(Guid id)
        {

            var occupation = _context.Occupations
                .Include(o => o.Members)
                .FirstOrDefault(o => o.Id == id);

            return occupation;
        }
        public IEnumerable<Capital> GetCapitals()
        {
            var capitals = _context.Capitals
                .ToList();

            return capitals;
        }

        public Capital GetCapital(Guid id)
        {
            var capital = _context.Capitals
                .FirstOrDefault(c => c.Id == id);

            return capital;
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            var currencies = _context.Currencies
                .ToList();

            return currencies;
        }

        public Currency GetCurrency(Guid id)
        {
            var currency = _context.Currencies
                .FirstOrDefault(c => c.Id == id);

            return currency;
        }

        public IEnumerable<Country> GetCountries()
        {
            var countries = _context.Countries
                .Include(c => c.Governor)
                .Include(c => c.Nationality)
                .Include(c => c.Capital)
                .Include(c => c.Currency)
                .ToList();

            return countries;
        }

        public Country GetCountry(Guid id)
        {
            var country = _context.Countries
                .Include(c => c.Governor)
                .Include(c => c.Nationality)
                .Include(c => c.Capital)
                .Include(c => c.Currency)
                .FirstOrDefault(c => c.Id == id);

            return country;
                
        }

        public Boolean Save()
        {
            if(_context.SaveChanges() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
