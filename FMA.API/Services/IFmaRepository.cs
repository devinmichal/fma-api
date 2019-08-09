using FMA.API.Entities;
using System;
using System.Collections.Generic;

namespace FMA.API.Services
{
   public interface IFmaRepository
    {
         IEnumerable<Character> GetCharacters();
        Character GetCharacter(Guid id);
        IEnumerable<Nationality> GetNationalities();
        Nationality GetNationality(Guid id);

        IEnumerable<Occupation> GetOccupations();
        Occupation GetOccupation(Guid id);
        IEnumerable<Capital> GetCapitals();
        Capital GetCapital(Guid id);
        IEnumerable<Currency> GetCurrencies();
        Currency GetCurrency(Guid id);
        IEnumerable<Country> GetCountries();
        Country GetCountry(Guid id);
    }
}
