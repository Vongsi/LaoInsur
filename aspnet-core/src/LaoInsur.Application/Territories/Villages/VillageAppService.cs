using LaoInsur.Permissions;
using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Districts;
using LaoInsur.Territories.Provinces;
using Microsoft.AspNetCore.Authorization;
using Serilog;
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

namespace LaoInsur.Territories.Villages
{

    [Authorize(LaoInsurPermissions.Villages.Default)]
    public class VillageAppService : LaoInsurAppService, IVillageAppService //implement the IBookAppService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IVillageRepository _villageRepository;

        public VillageAppService(
            IDistrictRepository districtRepository,
            IVillageRepository villageRepository
            ) {
            _districtRepository = districtRepository;
            _villageRepository = villageRepository;
        }

        [Authorize(LaoInsurPermissions.Villages.Create)]
        public async Task<VillageDto> CreateAsync(CreateUpdateVillageDto input) {

            try
            {
                var district = await _districtRepository.GetAsync(input.DistrictId);

                var village = new Village();

                village.Code = input.Code;
                village.NameEng = input.NameEng;
                village.NameLao = input.NameLao;
                village.DescriptionEng = input.DescriptionEng;
                village.DescriptionLao = input.DescriptionLao;
                village.PostalCode = input.PostalCode;
                village.District = district;

                await _villageRepository.InsertAsync(village);

                return ObjectMapper.Map<Village, VillageDto>(village);

            }
            catch (Exception ex)
            {
                Log.Information(ex.Message);
                
                var village = new Village();

                return ObjectMapper.Map<Village, VillageDto>(village);
            }
        }

        public async Task DeleteAsync(Guid id) {
            //throw new NotImplementedException();

            await _villageRepository.DeleteAsync(id);
        }

        public async Task<VillageDto> GetAsync(Guid id) {

            var village = await _villageRepository.GetAsync(id);

            return ObjectMapper.Map<Village, VillageDto>(village);
        }

        public async Task<PagedResultDto<VillageDto>> GetListAsync(SearchVillageDto input) {

            if (input.Sorting.IsNullOrWhiteSpace()) {
                input.Sorting = nameof(Village.NameEng);
            }

            var villages = await _villageRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.NameEng
            );

            var totalCount = input.NameEng == null
                ? await _villageRepository.CountAsync()
                : await _villageRepository.CountAsync(
                    e => e.NameEng.Contains(input.NameEng));

            return new PagedResultDto<VillageDto>(
                totalCount,
                ObjectMapper.Map<List<Village>, List<VillageDto>>(villages)
            );
        }

        [Authorize(LaoInsurPermissions.Villages.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateVillageDto input) {            

            var district = await _districtRepository.GetAsync(input.DistrictId);
            var village = await _villageRepository.GetAsync(id);

            if (village.Code != input.Code) {
                //await _countryManager.ChangeNameAsync(country, input.Code);
            }

            village.Code = input.Code;
            village.NameEng = input.NameEng;
            village.NameLao = input.NameLao;
            village.DescriptionEng = input.DescriptionEng;
            village.DescriptionLao = input.DescriptionLao;
            village.PostalCode = input.PostalCode;
            village.District = district;

            await _villageRepository.UpdateAsync(village);
        }
    }
}
