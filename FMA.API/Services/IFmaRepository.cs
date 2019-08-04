using FMA.API.Entities;
using System;
using System.Collections.Generic;

namespace FMA.API.Services
{
   public interface IFmaRepository
    {
         IEnumerable<Character> GetCharacters();
        Character GetCharacter(Guid id);
        IEnumerable<Affiliation> GetAffiliations();
        Affiliation GetAffiliation(Guid id);
        IEnumerable<Nationality> GetNationalities();
        Nationality GetNationality(Guid id);
    }
}
