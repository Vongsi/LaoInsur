using AutoMapper;
using LaoInsur.Territories.Addresses;
using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Districts;
using LaoInsur.Territories.Provinces;
using LaoInsur.Territories.Villages;

namespace LaoInsur;

public class LaoInsurApplicationAutoMapperProfile : Profile
{
    public LaoInsurApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        #region - Territories

        CreateMap<Continent, ContinentDto>();
        CreateMap<CreateUpdateContinentDto, Continent>();

        CreateMap<Country, CountryDto>()
            .ForMember(c => c.ContinentDto, opt => opt.MapFrom(ct => ct.Continent));
        CreateMap<CreateUpdateCountryDto, Country>();

        CreateMap<Province, ProvinceDto>()
    .ForMember(c => c.CountryDto, opt => opt.MapFrom(ct => ct.Country));
        CreateMap<CreateUpdateProvinceDto, Province>();

        CreateMap<District, DistrictDto>()
.ForMember(c => c.ProvinceDto, opt => opt.MapFrom(ct => ct.Province));
        CreateMap<CreateUpdateDistrictDto, District>();

        CreateMap<Village, VillageDto>()
.ForMember(c => c.DistrictDto, opt => opt.MapFrom(ct => ct.District));
        CreateMap<CreateUpdateVillageDto, Village>();

        CreateMap<Address, AddressDto>()
.ForMember(c => c.VillageDto, opt => opt.MapFrom(ct => ct.Village));
        CreateMap<CreateUpdateAddressDto, Address>();

        #endregion - Territories
    }
}
