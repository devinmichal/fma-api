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
           
            var currency = new List<Currency>(){ new Currency()
            {
                Id = new Guid("f268e74c-1840-4835-ae3e-47e6915099ae"),
                Name = "Cenz",
                Description = "The Cens is the standard unit of currency in Amestris and is available in both paper bills and varied metal coins. It can be inferred that the paper bills are worth more, similar to many real-life currencies. It is equal to about one Japanese Yen in the real world."
             },
             new Currency()
            {
                    Id = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    Name = "Unknown"

                }
            };
            context.AddRange(currency);

            var nationality = new List<Nationality>(){new Nationality()
            {
                    Id = new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"),
                    Name = "Amestrian"
             },
             new Nationality()
             
             {
                    Id = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    Name = "Unknown"

             }
             
            };

            context.AddRange(nationality);

            var capital =new List<Capital>(){ new Capital()
            {
                    Id = new Guid("4c793930-8632-48ad-9850-499f74de0853"),
                    Name = "Central City",
                    Description = "Central City is the official capital and also the seat of government in Amestris. The National Central Library, Central Command, the 5 National Laboratories, and Amestris' Parliament are all located in Central. Aside from its symbol as a military headquarters, Central is also a bustling metropolis and arguably Amestris' largest city, complete with nearly everything Amestrian society has to offer as well as a lasting and rarely disturbed sense of peace created by its proximity to the government's imposing presence. After the events in the eastern regions of Amestris and the Elrics' excursion to the southern region, much of the Fullmetal Alchemist story takes place in Central, as it also serves as the Homunculi's home base, the heart of which is located deep beneath Central Command Headquarters",
             },
             new Capital()
             
             {
                    Id = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    Name = "Unknown"

             }
            };
            context.AddRange(capital);

            var country = new List<Country>(){new Country()
            {
                Id = new Guid("63891193-dce2-41ee-bdb0-6cfaf69b6d27"),
                Name = "Amestris",
                Population = 50000000,
                CapitalId = new Guid("4c793930-8632-48ad-9850-499f74de0853"),
                NationalityId = new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"),
                CurrencyId = new Guid("f268e74c-1840-4835-ae3e-47e6915099ae"),
                Government = "Parliamentary",
                Founded = 1550

              },
              new Country()
              {
                    Id = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    Name = "Unknown",
                    CapitalId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    CurrencyId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    NationalityId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291")

              }
            };
            context.AddRange(country);

            var occupation = new List<Occupation>(){new Occupation()
            {
                    Id = new Guid("99216871-834b-4108-9bfc-86e7bc1f5a50"),
                    Name = "State Alchemist",
                    Decsription = "A State Alchemist is an alchemist employed by the Amestrian State Military as part of an elite government mandated program."
             },
             new Occupation()
            {
                    Id = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                    Name = "Unknown"

            }
            };
            context.AddRange(occupation);

            var character = new List<Character>() {new Character()
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
            },
            new Character()
            {
                Id = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                OccupationId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                CountryId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                NationalityId = new Guid("0a872c12-38e6-4ca4-67a3-08d71d561291"),
                FirstName = "Unknown",
                LastName = "Unknown"
            }
            };
            context.AddRange(character);
            context.SaveChanges();
        } 
    }
}
