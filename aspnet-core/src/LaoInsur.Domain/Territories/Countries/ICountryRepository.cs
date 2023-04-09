using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Countries {
    public interface ICountryRepository : IRepository<Country, Guid> {

        Task<Country> GetAsync(Guid id);

        Task<Country> FindByCodeAsync(string code);

        Task<List<Country>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
