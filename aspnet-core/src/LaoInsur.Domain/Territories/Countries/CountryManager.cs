using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;
using LaoInsur.Territories.Continents;

namespace LaoInsur.Territories.Countries {
    public class CountryManager : DomainService {

        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;

        public CountryManager(IContinentRepository continentRepository, ICountryRepository countryRepository) {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
        }

        public async Task<Country> CreateAsync(
            [NotNull] string code,
            [NotNull] string nameEng,
            [NotNull] string nameLao,
            [NotNull] string descriptionEng,
            [NotNull] string descriptionLao,
            [NotNull] string nationalityEng,
            [NotNull] string nationalityLao,
            [NotNull] string postalCode,
            [NotNull] string iSO2Codes,
            [NotNull] string iSO3Codes,
            [NotNull] Guid continentId) {

            Check.NotNullOrWhiteSpace(nameEng, nameof(nameEng));

            var continent = await _continentRepository.FindAsync(continentId);
            var existingCountry = await _countryRepository.FindByCodeAsync(code);
            
            if (existingCountry != null) {
                throw new CountryAlreadyExistsException(code);
            }

            return new Country(
                Guid.NewGuid()
                , code
                , nameEng
                , nameLao
                , descriptionEng
                , descriptionLao
                , nationalityEng
                , nationalityLao
                , postalCode
                , iSO2Codes
                , iSO3Codes
                , continent
            );
        }

        //public async Task ChangeNameAsync(
        //    [NotNull] Country country,
        //    [NotNull] string newName) {
        //    Check.NotNull(country, nameof(country));
        //    Check.NotNullOrWhiteSpace(newName, nameof(newName));

        //    var existingAuthor = await _countryRepository.FindByNameAsync(newName);
        //    if (existingAuthor != null && existingAuthor.Id != country.Id) {
        //        throw new CountryAlreadyExistsException(newName);
        //    }

        //    country.ChangeName(newName);
        //}
    }
}
