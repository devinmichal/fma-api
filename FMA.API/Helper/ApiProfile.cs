using AutoMapper;
using FMA.API.Entities;
using FMA.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Helper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            

                  CreateMap<Character, CharacterDto>()
                      .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                      .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.Name))
                      .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Name))
                      .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));

                  CreateMap<Nationality, NationalityDto>()
                   .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

                  CreateMap<Occupation, OccupationDto>();

                  CreateMap<Capital, CapitalDto>();

                  CreateMap<Currency, CurrencyDto>();

                  CreateMap<Country, CountryDto>()
                  .ForMember(dest => dest.Capital, opt => opt.MapFrom(src => src.Capital.Name))
                  .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Name))
                  .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Name));

                  CreateMap<CharacterToCreateDto, Character>();
                  CreateMap<CountryToCreateDto, Country>();
                  CreateMap<CapitalToCreateDto, Capital>();
                  CreateMap<NationalityToCreateDto, Nationality>();
                  CreateMap<OccupationToCreateDto, Occupation>();
                  CreateMap<CapitalToUpdateDto, Capital>();
                  CreateMap<CharacterToUpdateDto, Character>();
                  CreateMap<NationalityToUpdateDto, Nationality>();
                  CreateMap<OccupationToUpdateDto, Occupation>();
                  CreateMap<CountryToUpdateDto, Country>();
                  CreateMap<Capital, CapitalToUpdateDto>();
                  CreateMap<Character, CharacterToUpdateDto>();
                  CreateMap<Country, CountryToUpdateDto>();
                  CreateMap<Nationality, NationalityToUpdateDto>();



              }
        }
    }

