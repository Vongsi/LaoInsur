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

namespace LaoInsur.EntityFrameworkCore.Countries {
    public class EfCoreCountryRepository : EfCoreRepository<LaoInsurDbContext, Country, Guid>,
        ICountryRepository {
        public EfCoreCountryRepository(
            IDbContextProvider<LaoInsurDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public async Task<Country> GetAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(c => c.Id.Equals(id)).Include(c => c.Continent).FirstAsync();
        }

        public async Task<Country> FindByCodeAsync(string code) {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(country => country.Code == code);
        }

        public async Task<List<Country>> GetListAsync(
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
                .Include(c => c.Continent)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
