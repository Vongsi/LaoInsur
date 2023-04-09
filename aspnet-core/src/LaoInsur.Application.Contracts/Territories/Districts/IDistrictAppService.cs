using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Districts
{
    public interface IDistrictAppService : IApplicationService {
        Task<DistrictDto> GetAsync(Guid id);

        Task<PagedResultDto<DistrictDto>> GetListAsync(SearchDistrictDto input);

        Task<DistrictDto> CreateAsync(CreateUpdateDistrictDto input);

        Task UpdateAsync(Guid id, CreateUpdateDistrictDto input);

        Task DeleteAsync(Guid id);
    }
}
