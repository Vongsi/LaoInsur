using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Provinces
{
    public interface IProvinceAppService : IApplicationService {
        Task<ProvinceDto> GetAsync(Guid id);

        Task<PagedResultDto<ProvinceDto>> GetListAsync(SearchProvinceDto input);

        Task<ProvinceDto> CreateAsync(CreateUpdateProvinceDto input);

        Task UpdateAsync(Guid id, CreateUpdateProvinceDto input);

        Task DeleteAsync(Guid id);
    }
}
