using LaoInsur.Territories.Countries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using LaoInsur.Territories.Continents;

namespace LaoInsur.EntityFrameworkCore.Continents {
    public class EfCoreContinentRepository : EfCoreRepository<LaoInsurDbContext, Continent, Guid>,
        IContinentRepository {
        public EfCoreContinentRepository(
            IDbContextProvider<LaoInsurDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public async Task<Continent> FindByCodeAsync(string code) {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(country => country.ISO2Codes == code);
        }

        public async Task<List<Continent>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null) {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    country => country.NameEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    country => country.NameLao.Contains(filter)
                )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    country => country.DescriptionEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    country => country.DescriptionLao.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
