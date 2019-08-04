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

       public IEnumerable<Affiliation> GetAffiliations()
        {
            var affiliations = _context.Affiliations
                .Include(a => a.KnownMembers)
                .ToList();

            return affiliations;
        }

        public Affiliation GetAffiliation(Guid id)
        {
            var affiliation = _context.Affiliations
                .Include(a => a.KnownMembers)
                .FirstOrDefault(a => a.Id == id);

            return affiliation;

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
    }
}
