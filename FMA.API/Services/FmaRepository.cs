﻿using FMA.API.Entities;
using FMA.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public void UpdateCharacter(Character character) { }
        public Boolean CharacterExist(Character character)
        {

            var boolean = _context.Characters.Any(c => c.FirstName.Trim().ToLower() == character.FirstName.Trim().ToLower()
            && c.LastName.Trim().ToLower() == character.LastName.Trim().ToLower()
            && c.Age == character.Age);

           return boolean;
           
        }

        public bool CharacterExist(Guid id)
        {
           
                 var boolean = _context.Characters.Any(c => c.Id == id);

                     return boolean;    

            
        }
        public Character AddCharacter(Character character)
        {
            if (character.Id == null)
            {
                character.Id = Guid.NewGuid();
            }

            if(character.CountryId is null)
            {
                character.CountryId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291");
            }

            if (character.NationalityId is null)
            {
                character.NationalityId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291");
            }


            if (character.OccupationId is null)
            {
                character.OccupationId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291");
            }

            if(character.Rank is null)
            {
                character.Rank = "None";
            }

            if(character.Weapon is null)
            {
                character.Weapon = "None";
            }

            if(character.Goal is null)
            {
                character.Goal = "Unknown";
            }

            if(character.Abilities is null)
            {
                character.Abilities = "No abilities";
            }

            if(character.Aliases is null)
            {
                character.Aliases = "No aliases";
            }

            _context.Add(character);

            return character;
        }

        public void DeleteCharacter(Character character)
        {
            _context.Remove(character);
        }

        public IEnumerable<CharacterDto> GetCharacters()
        {
           
                 var characters =
                 _context.Characters
                 .Select(c =>
                     new CharacterDto()
                     {
                         Id = c.Id,
                         FullName = c.FirstName + " " + c.LastName,
                         Abilities = c.Abilities,
                         Age = c.Age.ToString(),
                         Aliases = c.Aliases,
                         Country = c.Country.Name,
                         Goal = c.Goal,
                         Nationality = c.Nationality.Name,
                         Occupation = c.Occupation.Name,
                         Rank = c.Rank,
                         Weapon = c.Weapon
                     })
                 .AsNoTracking()
                 .ToList();
                 
                return characters;
            
        }

        public IEnumerable<CharacterDto> GetCharacters(IEnumerable<Guid> ids)
        {
         
           
                var characters =
                _context.Characters
            .Where(c => ids.Contains(c.Id))
            .Select(c =>
                new CharacterDto()
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.LastName,
                    Abilities = c.Abilities,
                    Age = c.Age.ToString(),
                    Aliases = c.Aliases,
                    Country = c.Country.Name,
                    Goal = c.Goal,
                    Nationality = c.Nationality.Name,
                    Occupation = c.Occupation.Name,
                    Rank = c.Rank,
                    Weapon = c.Weapon
                })
                .AsNoTracking()
                .ToList();
   
                return characters;
            
           

                

          
                
        }
        public CharacterDto GetCharacterDto(Guid id)
        {

          
                var character = _context.Characters
                    .Where(c => c.Id == id)
                       .Select(c =>
                    new CharacterDto()
                    {
                        Id = c.Id,
                        FullName = c.FirstName + " " + c.LastName,
                        Abilities = c.Abilities,
                        Age = c.Age.ToString(),
                        Aliases = c.Aliases,
                        Country = c.Country.Name,
                        Goal = c.Goal,
                        Nationality = c.Nationality.Name,
                        Occupation = c.Occupation.Name,
                        Rank = c.Rank,
                        Weapon = c.Weapon
                    }
                    )
                    .AsNoTracking()
                    .Single();



                return character;
            
                
        }

        public Character GetCharacter(Guid id)
        {
            
                var character = _context.Characters
                    .FirstOrDefault(c => c.Id == id);

                return character;

                    
        }

        public void UpdateNationality(Nationality nationality) { }
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
        public Boolean NationalityExist(Nationality nationality)
        {
            var nationalities = _context.Nationalities
                .ToList();

            var boolean = nationalities.
                Any(n => n.Name.ToLower().Contains(nationality.Name.ToLower()));

            return boolean;
        }

        public Nationality AddNationality(Nationality nationality, Guid countryId)
        {
            nationality.Id = Guid.NewGuid();

            var country = GetCountry(countryId);
            country.NationalityId = nationality.Id;

            _context.Update(country);
            _context.Add(nationality);

            return nationality;
        }

        public Nationality AddNationality(Nationality nationality)
        {
            if(nationality.Id == null)
            {
                nationality.Id = Guid.NewGuid();
            }

            _context.Add(nationality);

            return nationality;
        }

        public Boolean NationalityExist(Guid id)
        {
            var boolean = _context.Nationalities
                .Any(n => n.Id == id);

            return boolean;
        }

        public void DeleteNationality(Nationality nationality)
        {
            _context.Remove(nationality);
        }

        public void UpdateOccupation(Occupation occupation) { }
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

        public Boolean OccupationExist(Occupation occupation)
        {
            var occupations = _context.Occupations.ToList();
            var boolean = occupations
                .Any(o => o.Name.ToLower().Contains(occupation.Name.ToLower()));

            return boolean;
        }

        public Boolean OccupationExist(Guid id)
        {
            var boolean = _context.Occupations
                .Any(o => o.Id == id);

            return boolean;
        }
        public Occupation AddOccupation(Occupation occupation)
        {
            occupation.Id = Guid.NewGuid();
            _context.Add(occupation);

            return occupation;
        }

        public void DeleteOccupation(Occupation occupation)
        {
            _context.Remove(occupation);
        }

        public void UpdateCapital(Capital capital)
        {

        }
        public Capital AddCapital(Capital capital, Guid countryId) {

            var country = GetCountry(countryId);

            capital.Id = Guid.NewGuid();

            country.CapitalId = capital.Id;

            _context.Update(country);
            _context.Add(capital);

            return capital;
        }

        public void AddCapital(Capital capital)
        {
            _context.Add(capital);
        }

        public Boolean CapitalExist(Capital capital)
        {
            var capitals = _context.Capitals.ToList();

            var boolean = capitals
                .Any(c => c.Name.ToLower().Contains(capital.Name.ToLower()));

            return boolean;
        }

        public Boolean CapitalExist(Guid capitalId)
        {
            var boolean = _context.Capitals
                .Any(c => c.Id == capitalId);

            return boolean;
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

        public void DeleteCapital(Capital capital)
        {
            _context.Remove(capital);
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
                .Include(c => c.Nationality)
                .Include(c => c.Capital)
                .Include(c => c.Currency)
                .ToList();

            return countries;
        }

        public void UpdateCountry(Country country) { }
        public Country GetCountry(Guid id)
        {
            var country = _context.Countries
                .Include(c => c.Nationality)
                .Include(c => c.Capital)
                .Include(c => c.Currency)
                .FirstOrDefault(c => c.Id == id);

            return country;
                
        }

        public Country AddCountry(Country country)
        {
            if (country.Id == null)
            {
                country.Id = Guid.NewGuid();
            }

            if(country.CurrencyId is null)
            {
                country.CurrencyId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291");
            }

            if(country.CapitalId is null)
            {
                country.CapitalId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291");
            }

            if(country.NationalityId is null)
            {
                country.NationalityId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291");
            }


            if(country.Government is null)
            {
                country.Government = "Unknown";
            }

     
            _context.Add(country);

            return country;
        }

        public Boolean CountryExist(Country country)
        {
         
                var boolean = _context.Countries
                .Any(c => c.Name.ToLower().Contains(country.Name.ToLower()) && c.Government.ToLower().Contains(country.Government.ToLower()));


            return boolean;
        }

        public Boolean CountryExist(Guid id)
        {

            
                var boolean = _context.Countries.Any(c => c.Id == id);

                return boolean;
            
        }

        public void DeleteCountry(Country country)
        {
            _context.Remove(country);
        }

        public Boolean Save()
        {

            return (_context.SaveChanges() >= 0);
               
        }
    }
}
