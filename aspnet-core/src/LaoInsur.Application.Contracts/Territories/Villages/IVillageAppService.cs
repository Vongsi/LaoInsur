using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Villages
{
    public interface IVillageAppService : IApplicationService {
        Task<VillageDto> GetAsync(Guid id);

        Task<PagedResultDto<VillageDto>> GetListAsync(SearchVillageDto input);

        Task<VillageDto> CreateAsync(CreateUpdateVillageDto input);

        Task UpdateAsync(Guid id, CreateUpdateVillageDto input);

        Task DeleteAsync(Guid id);
    }
}
