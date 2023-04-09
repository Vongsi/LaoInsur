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
using LaoInsur.Territories.Provinces;
using LaoInsur.Territories.Continents;
using Volo.Abp;

namespace LaoInsur.EntityFrameworkCore.Provinces
{
    public class EfCoreProvinceRepository : EfCoreRepository<LaoInsurDbContext, Province, Guid>,
        IProvinceRepository
    {
        public EfCoreProvinceRepository(
            IDbContextProvider<LaoInsurDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public async Task<Province> GetAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(c => c.Id.Equals(id)).Include(c => c.Country).FirstAsync();
        }

        public async Task<Province> FindByCodeAsync(string code) {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(province => province.Code == code);
        }

        public async Task<List<Province>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null) {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    province => province.NameEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    province => province.NameLao.Contains(filter)
                )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    province => province.DescriptionEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    province => province.DescriptionLao.Contains(filter)
                )
                .Include(c => c.Country)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
