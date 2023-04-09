using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Countries {
    public interface ICountryAppService : IApplicationService {
        Task<CountryDto> GetAsync(Guid id);

        Task<PagedResultDto<CountryDto>> GetListAsync(SearchCountryDto input);

        Task<CountryDto> CreateAsync(CreateUpdateCountryDto input);

        Task UpdateAsync(Guid id, CreateUpdateCountryDto input);

        Task DeleteAsync(Guid id);
    }
}
