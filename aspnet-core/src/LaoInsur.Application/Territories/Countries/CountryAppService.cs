using LaoInsur.Clients.Coporates;
using LaoInsur.Clients.Entities;
using LaoInsur.Clients.Individuals;
using LaoInsur.Contracts;
using LaoInsur.Permissions;
using LaoInsur.Territories.Addresses;
using LaoInsur.Territories.Continents;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Countries {

    [Authorize(LaoInsurPermissions.Countries.Default)]
    public class CountryAppService : LaoInsurAppService, ICountryAppService //implement the IBookAppService
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly CountryManager _countryManager;

        public CountryAppService(
            IContinentRepository continentRepository,
            ICountryRepository countryRepository,
            CountryManager countryManager) {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _countryManager = countryManager;
        }

        [Authorize(LaoInsurPermissions.Countries.Create)]
        public async Task<CountryDto> CreateAsync(CreateUpdateCountryDto input) {
            //throw new NotImplementedException();

            var contract = new Contract();
            var individual = new Individual();
            var entity = new Entity();

            individual.FirstName = "";
            individual.LastName = "";
            individual.MiddleName = "";
            //individual.DateOfBirth = DateTime.Now.Date.ToShortDateString();
            individual.Gender = new Clients.Clients.Gender();
            individual.Nationalities = new List<Country>();
            individual.Addresses = new List<Address>();
            individual.ClientType = Clients.ClientType.Individual;

            contract.Client = individual.ClientType == Clients.ClientType.Individual ? individual : entity;

            var country = await _countryManager.CreateAsync(
                                    input.Code,
                                    input.NameEng,
                                    input.NameLao,
                                    input.DescriptionEng,
                                    input.DescriptionLao,
                                    input.NationalityEng,
                                    input.NationalityLao,
                                    input.PostalCode,
                                    input.ISO2Code,
                                    input.ISO3Code,
                                    input.continentId
                                );

            await _countryRepository.InsertAsync(country);

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        public async Task DeleteAsync(Guid id) {
            //throw new NotImplementedException();

            await _countryRepository.DeleteAsync(id);
        }

        public async Task<CountryDto> GetAsync(Guid id) {

            var country = await _countryRepository.GetAsync(id);

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        public async Task<PagedResultDto<CountryDto>> GetListAsync(SearchCountryDto input) {

            //throw new NotImplementedException();

            if (input.Sorting.IsNullOrWhiteSpace()) {
                input.Sorting = nameof(Country.NameEng);
            }

            var countries = await _countryRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.NameEng
            );

            var totalCount = input.NameEng == null
                ? await _countryRepository.CountAsync()
                : await _countryRepository.CountAsync(
                    country => country.NameEng.Contains(input.NameEng));

            return new PagedResultDto<CountryDto>(
                totalCount,
                ObjectMapper.Map<List<Country>, List<CountryDto>>(countries)
            );
        }

        [Authorize(LaoInsurPermissions.Countries.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateCountryDto input) {
            //throw new NotImplementedException();

            var country = await _countryRepository.GetAsync(id);
            var continent = await _continentRepository.GetAsync(input.continentId);

            if (country.Code != input.Code) {
                //await _countryManager.ChangeNameAsync(country, input.Code);
            }

            country.Code = input.Code;
            country.NameEng = input.NameEng;
            country.NameLao = input.NameLao;
            country.DescriptionEng = input.DescriptionEng;
            country.DescriptionLao = input.DescriptionLao;
            country.NationalityEng = input.NationalityEng;
            country.NationalityLao = input.NationalityLao;
            country.PostalCode = input.PostalCode;
            country.ISO2Code = input.ISO2Code;
            country.ISO3Code = input.ISO3Code;
            country.Continent = continent;

            await _countryRepository.UpdateAsync(country);
        }
    }
}
