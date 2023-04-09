using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Continents {
    public interface IContinentRepository : IRepository<Continent, Guid> {
        Task<Continent> FindByCodeAsync(string code);

        Task<List<Continent>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
