﻿using FMA.API.Entities;
using FMA.API.Models;
using System;
using System.Collections.Generic;

namespace FMA.API.Services
{
   public interface IFmaRepository
    {
         IEnumerable<CharacterDto> GetCharacters();
        IEnumerable<CharacterDto> GetCharacters(IEnumerable<Guid> ids);
        CharacterDto GetCharacterDto(Guid id);
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

        Character AddCharacter(Character character);
        Boolean CharacterExist(Character character);
        Boolean CharacterExist(Guid id);
        Country AddCountry(Country country);
        Boolean CountryExist(Country country);
        Boolean CountryExist(Guid id);
        Capital AddCapital(Capital capital , Guid countryId);
        Boolean CapitalExist(Capital capital);
        Boolean NationalityExist(Nationality nationality);
        Nationality AddNationality(Nationality nationality, Guid countryId);
        Boolean OccupationExist(Occupation occupation);
        Occupation AddOccupation(Occupation occupation);
        void DeleteCharacter(Character character);
        

        Boolean Save();
    }
}
