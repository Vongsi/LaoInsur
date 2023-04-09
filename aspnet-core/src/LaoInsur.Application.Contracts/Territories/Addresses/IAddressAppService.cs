using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Addresses
{
    public interface IAddressAppService : IApplicationService {
        Task<AddressDto> GetAsync(Guid id);

        Task<PagedResultDto<AddressDto>> GetListAsync(SearchAddressDto input);

        Task<AddressDto> CreateAsync(CreateUpdateAddressDto input);

        Task UpdateAsync(Guid id, CreateUpdateAddressDto input);

        Task DeleteAsync(Guid id);
    }
}
