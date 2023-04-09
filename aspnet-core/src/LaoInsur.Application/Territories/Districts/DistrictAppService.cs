using LaoInsur.Permissions;
using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Districts;
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

namespace LaoInsur.Territories.Districts
{

    [Authorize(LaoInsurPermissions.Districts.Default)]
    public class DistrictAppService : LaoInsurAppService, IDistrictAppService //implement the IBookAppService
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;

        public DistrictAppService(
            IProvinceRepository provinceRepository,
            IDistrictRepository districtRepository
            ) {
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
        }

        [Authorize(LaoInsurPermissions.Districts.Create)]
        public async Task<DistrictDto> CreateAsync(CreateUpdateDistrictDto input) {
            //throw new NotImplementedException();

            var province = await _provinceRepository.GetAsync(input.ProvinceId);

            var district = new District();

            district.Code = input.Code;
            district.NameEng = input.NameEng;
            district.NameLao =  input.NameLao;
            district.DescriptionEng = input.DescriptionEng;
            district.DescriptionLao = input.DescriptionLao;
            district.PostalCode = input.PostalCode;
            district.Province = province;

            await _districtRepository.InsertAsync(district);

            return ObjectMapper.Map<District, DistrictDto>(district);
        }

        public async Task DeleteAsync(Guid id) {
            //throw new NotImplementedException();

            await _districtRepository.DeleteAsync(id);
        }

        public async Task<DistrictDto> GetAsync(Guid id) {

            var district = await _districtRepository.GetAsync(id);

            return ObjectMapper.Map<District, DistrictDto>(district);
        }

        public async Task<PagedResultDto<DistrictDto>> GetListAsync(SearchDistrictDto input) {

            //throw new NotImplementedException();

            if (input.Sorting.IsNullOrWhiteSpace()) {
                input.Sorting = nameof(Province.NameEng);
            }

            var districts = await _districtRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.NameEng
            );

            var totalCount = input.NameEng == null
                ? await _districtRepository.CountAsync()
                : await _districtRepository.CountAsync(
                    district => district.NameEng.Contains(input.NameEng));

            return new PagedResultDto<DistrictDto>(
                totalCount,
                ObjectMapper.Map<List<District>, List<DistrictDto>>(districts)
            );
        }

        [Authorize(LaoInsurPermissions.Districts.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateDistrictDto input) {
            //throw new NotImplementedException();

            var province = await _provinceRepository.GetAsync(input.ProvinceId);
            var district = await _districtRepository.GetAsync(id);

            if (district.Code != input.Code) {
                //await _countryManager.ChangeNameAsync(country, input.Code);
            }

            district.Code = input.Code;
            district.NameEng = input.NameEng;
            district.NameLao = input.NameLao;
            district.DescriptionEng = input.DescriptionEng;
            district.DescriptionLao = input.DescriptionLao;
            district.PostalCode = input.PostalCode;
            district.Province = province;

            await _districtRepository.UpdateAsync(district);
        }
    }
}
