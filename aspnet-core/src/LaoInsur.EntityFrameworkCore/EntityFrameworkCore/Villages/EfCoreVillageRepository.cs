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
using Volo.Abp;
using LaoInsur.Territories.Villages;

namespace LaoInsur.EntityFrameworkCore.Villages
{
    public class EfCoreVillageRepository : EfCoreRepository<LaoInsurDbContext, Village, Guid>,
        IVillageRepository
    {
        public EfCoreVillageRepository(
            IDbContextProvider<LaoInsurDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public async Task<Village> GetAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(e => e.Id.Equals(id)).Include(e => e.District).FirstAsync();
        }

        public async Task<Village> FindByCodeAsync(string code) 
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(e => e.Code == code).Include(e => e.District).FirstAsync();
        }

        public async Task<List<Village>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null) {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.NameEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.NameLao.Contains(filter)
                )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.DescriptionEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.DescriptionLao.Contains(filter)
                )
                .Include(e => e.District)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
