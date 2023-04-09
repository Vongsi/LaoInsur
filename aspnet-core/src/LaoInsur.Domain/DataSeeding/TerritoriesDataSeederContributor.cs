using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.DataSeeding {
    public class TerritoriesDataSeederContributor : IDataSeedContributor, ITransientDependency {

        private readonly IRepository<Continent, Guid> _continentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly CountryManager _countryManager;

        public TerritoriesDataSeederContributor(IRepository<Continent, Guid> continentRepository,
            ICountryRepository countryRepository,
        CountryManager countryManager) {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _countryManager = countryManager;
        }

        public async Task SeedAsync(DataSeedContext context) {

            if (await _continentRepository.GetCountAsync() <= 0) {
                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "Africa",
                        NameLao = "ອາຟຣິກກາ",
                        DescriptionEng = "Africa",
                        DescriptionLao = "ອາຟຣິກກາ",
                        ISO2Codes = "AF",
                    },
                    autoSave: true
                );

                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "North America",
                        NameLao = "ອາເມລິກາເໜືອ",
                        DescriptionEng = "North America",
                        DescriptionLao = "ອາເມລິກາເໜືອ",
                        ISO2Codes = "NA",
                    },
                    autoSave: true
                );

                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "Oceania",
                        NameLao = "ໂອເຊອານີ",
                        DescriptionEng = "Oceania",
                        DescriptionLao = "ໂອເຊອານີ",
                        ISO2Codes = "OC",
                    },
                    autoSave: true
                );

                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "Antarctica",
                        NameLao = "ທະວີບອັງຕາກຕິກ",
                        DescriptionEng = "Antarctica",
                        DescriptionLao = "ທະວີບອັງຕາກຕິກ",
                        ISO2Codes = "AN",
                    },
                    autoSave: true
                );

                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "Asia",
                        NameLao = "ອາຊີ",
                        DescriptionEng = "Asia",
                        DescriptionLao = "ອາຊີ",
                        ISO2Codes = "AS",
                    },
                    autoSave: true
                );

                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "Europe",
                        NameLao = "ເອີຣົບ",
                        DescriptionEng = "Europe",
                        DescriptionLao = "ເອີຣົບ",
                        ISO2Codes = "EU",
                    },
                    autoSave: true
                );

                await _continentRepository.InsertAsync(
                    new Continent {
                        NameEng = "South America",
                        NameLao = "ອາເມລິກາໃຕ້",
                        DescriptionEng = "South America",
                        DescriptionLao = "ອາເມລິກາໃຕ້",
                        ISO2Codes = "SA",
                    },
                    autoSave: true
                );
            }

            // Added seed data for countries
            if (await _countryRepository.GetCountAsync() <= 0) {
                await _countryRepository.InsertAsync(
                    await _countryManager.CreateAsync(
                        code: "+855",
                        nameEng: "",
                        nameLao: "",
                        descriptionEng: "",
                        descriptionLao: "",
                        nationalityEng: "",
                        nationalityLao: "",
                        postalCode: "",
                        iSO2Codes: "KH",
                        iSO3Codes: "KHM",
                        Guid.NewGuid()
                    )
                );

                await _countryRepository.InsertAsync(
                    await _countryManager.CreateAsync(
                        code: "+856",
                        nameEng: "",
                        nameLao: "",
                        descriptionEng: "",
                        descriptionLao: "",
                        nationalityEng: "",
                        nationalityLao: "",
                        postalCode: "",
                        iSO2Codes: "LA",
                        iSO3Codes: "LAO",
                        Guid.NewGuid()
                    )
                );
            }
        }
    }
}
