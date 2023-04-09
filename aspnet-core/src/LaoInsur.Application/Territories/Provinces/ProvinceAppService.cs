using LaoInsur.Permissions;
using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Provinces;
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
using Volo.Abp.ObjectMapping;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Provinces
{

    [Authorize(LaoInsurPermissions.Provinces.Default)]
    public class ProvinceAppService : LaoInsurAppService, IProvinceAppService //implement the IBookAppService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceAppService(
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository) {
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
        }

        [Authorize(LaoInsurPermissions.Provinces.Create)]
        public async Task<ProvinceDto> CreateAsync(CreateUpdateProvinceDto input) {
            //throw new NotImplementedException();

            var country = await _countryRepository.GetAsync(input.countryId);

            var province = new Province();

            province.Code = input.Code;
            province.NameEng = input.NameEng;
            province.NameLao =  input.NameLao;
            province.DescriptionEng = input.DescriptionEng;
            province.DescriptionLao = input.DescriptionLao;
            province.PostalCode = input.PostalCode;
            province.ISO2Codes = input.ISO2Codes;
            province.ISO3Codes = input.ISO3Codes;
            province.Country = country;

            await _provinceRepository.InsertAsync(province);

            return ObjectMapper.Map<Province, ProvinceDto>(province);
        }

        public async Task DeleteAsync(Guid id) {
            //throw new NotImplementedException();

            await _provinceRepository.DeleteAsync(id);
        }

        public async Task<ProvinceDto> GetAsync(Guid id) {

            var country = await _provinceRepository.GetAsync(id);

            return ObjectMapper.Map<Province, ProvinceDto>(country);
        }

        public async Task<PagedResultDto<ProvinceDto>> GetListAsync(SearchProvinceDto input) {

            //throw new NotImplementedException();

            if (input.Sorting.IsNullOrWhiteSpace()) {
                input.Sorting = nameof(Province.NameEng);
            }

            var provinces = await _provinceRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.NameEng
            );

            var totalCount = input.NameEng == null
                ? await _provinceRepository.CountAsync()
                : await _provinceRepository.CountAsync(
                    province => province.NameEng.Contains(input.NameEng));

            return new PagedResultDto<ProvinceDto>(
                totalCount,
                ObjectMapper.Map<List<Province>, List<ProvinceDto>>(provinces)
            );
        }

        [Authorize(LaoInsurPermissions.Provinces.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateProvinceDto input) {
            //throw new NotImplementedException();

            var country = await _countryRepository.GetAsync(input.countryId);
            var province = await _provinceRepository.GetAsync(id);

            if (province.Code != input.Code) {
                //await _countryManager.ChangeNameAsync(country, input.Code);
            }

            province.Code = input.Code;
            province.NameEng = input.NameEng;
            province.NameLao = input.NameLao;
            province.DescriptionEng = input.DescriptionEng;
            province.DescriptionLao = input.DescriptionLao;
            province.PostalCode = input.PostalCode;
            province.ISO2Codes = input.ISO2Codes;
            province.ISO3Codes = input.ISO3Codes;
            province.Country = country;

            await _provinceRepository.UpdateAsync(province);
        }
    }
}
