using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Entities
{
    public static class FmaContextExtension
    {
        public static void SeedDataForContext(this FmaContext context)
        {
            //clears the DB
            context.Characters.RemoveRange(context.Characters);
            context.Currencies.RemoveRange(context.Currencies);
            context.Nationalities.RemoveRange(context.Nationalities);
            context.Capitals.RemoveRange(context.Capitals);
            context.Countries.RemoveRange(context.Countries);
            context.Occupations.RemoveRange(context.Occupations);
            context.SaveChanges();



            // seed data
            var currency = new Currency()
            {
                Id = new Guid("f268e74c-1840-4835-ae3e-47e6915099ae"),
                Name = "Cenz",
                Description = "The Cens is the standard unit of currency in Amestris and is available in both paper bills and varied metal coins. It can be inferred that the paper bills are worth more, similar to many real-life currencies. It is equal to about one Japanese Yen in the real world."
             };
            context.Add(currency);
            context.SaveChanges();
            var nationality = new Nationality()
            {
                    Id = new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"),
                    Name = "Amestrian"
             };

            context.Add(nationality);
            context.SaveChanges();
            var capital = new Capital()
            {
                    Id = new Guid("4c793930-8632-48ad-9850-499f74de0853"),
                    Name = "Central City",
                    Description = "Central City is the official capital and also the seat of government in Amestris. The National Central Library, Central Command, the 5 National Laboratories, and Amestris' Parliament are all located in Central. Aside from its symbol as a military headquarters, Central is also a bustling metropolis and arguably Amestris' largest city, complete with nearly everything Amestrian society has to offer as well as a lasting and rarely disturbed sense of peace created by its proximity to the government's imposing presence. After the events in the eastern regions of Amestris and the Elrics' excursion to the southern region, much of the Fullmetal Alchemist story takes place in Central, as it also serves as the Homunculi's home base, the heart of which is located deep beneath Central Command Headquarters",
             };
            context.Add(capital);
            context.SaveChanges();
            var country = new Country()
            {
                    Id = new Guid("63891193-dce2-41ee-bdb0-6cfaf69b6d27"),
                    Name = "Amestris",
                    Population = 50000000,
                    CapitalId = new Guid("4c793930-8632-48ad-9850-499f74de0853"),
                    NationalityId = new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"),
                    CurrencyId = new Guid("f268e74c-1840-4835-ae3e-47e6915099ae")
              };
            context.Add(country);
            context.SaveChanges();
            var occupation = new Occupation()
            {
                    Id = new Guid("99216871-834b-4108-9bfc-86e7bc1f5a50"),
                    Name = "State Alchemist",
                    Decsription = "A State Alchemist is an alchemist employed by the Amestrian State Military as part of an elite government mandated program."
             };
            context.Add(occupation);
            context.SaveChanges();
            var character = new Character()
            {
                    Id = new Guid("b8be8110-3841-4064-b0a5-b8987bf8c3b2"),
                    NationalityId = new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"),
                    OccupationId = new Guid("99216871-834b-4108-9bfc-86e7bc1f5a50"),
                    Age = 29,
                    Abilities = "Flame-Based Alchemy",
                    Weapon = "Ignition Cloth Gloves",
                    Rank = "Lieutenant Colonel",
                    Goal = "Becoming Fuhrer",
                    FirstName = "Roy",
                    LastName = "Mustang",
                    Aliases ="Flame Alchemist,Hero of Ishbal,Roy-Boy, Chief",
                    CountryId = new Guid("63891193-dce2-41ee-bdb0-6cfaf69b6d27")
            };
            context.Add(character);
            context.SaveChanges();
        } 
    }
}
