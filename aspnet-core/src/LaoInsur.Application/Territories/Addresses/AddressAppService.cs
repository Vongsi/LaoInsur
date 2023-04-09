using LaoInsur.Permissions;
using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Districts;
using LaoInsur.Territories.Provinces;
using LaoInsur.Territories.Villages;
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

namespace LaoInsur.Territories.Addresses
{

    [Authorize(LaoInsurPermissions.Addresses.Default)]
    public class AddressAppService : LaoInsurAppService, IAddressAppService //implement the IBookAppService
    {        
        private readonly IVillageRepository _villageRepository;
        private readonly IAddressRepository _addressRepository;

        public AddressAppService(
            IVillageRepository villageRepository,
            IAddressRepository addressRepository
            ) {
            _villageRepository = villageRepository;
            _addressRepository = addressRepository;
        }

        [Authorize(LaoInsurPermissions.Addresses.Create)]
        public async Task<AddressDto> CreateAsync(CreateUpdateAddressDto input) {

            var village = await _villageRepository.GetAsync(input.VillageId);

            var address = new Address();

            address.HouseNo = input.HouseNo;
            address.Unit = input.Unit;
            address.Street =  input.Street;
            address.Alley = input.Alley;
            address.Village = village;

            await _addressRepository.InsertAsync(address);

            return ObjectMapper.Map<Address, AddressDto>(address);
        }

        public async Task DeleteAsync(Guid id) {

            await _addressRepository.DeleteAsync(id);
        }

        public async Task<AddressDto> GetAsync(Guid id) {

            var address = await _addressRepository.GetAsync(id);

            return ObjectMapper.Map<Address, AddressDto>(address);
        }

        public async Task<PagedResultDto<AddressDto>> GetListAsync(SearchAddressDto input) {

            if (input.Sorting.IsNullOrWhiteSpace()) {
                input.Sorting = nameof(Address.Unit);
            }

            var address = await _addressRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Unit
            );

            var totalCount = input.Unit == null
                ? await _addressRepository.CountAsync()
                : await _addressRepository.CountAsync(
                    e => e.Unit.Contains(input.Unit));

            return new PagedResultDto<AddressDto>(
                totalCount,
                ObjectMapper.Map<List<Address>, List<AddressDto>>(address)
            );
        }

        [Authorize(LaoInsurPermissions.Addresses.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateAddressDto input) 
        {
            var village = await _villageRepository.GetAsync(input.VillageId);
            var address = await _addressRepository.GetAsync(id);

            address.HouseNo = input.HouseNo;
            address.Unit = input.Unit;
            address.Street = input.Street;
            address.Alley = input.Alley;
            address.Village = village;

            await _addressRepository.UpdateAsync(address);
        }
    }
}
