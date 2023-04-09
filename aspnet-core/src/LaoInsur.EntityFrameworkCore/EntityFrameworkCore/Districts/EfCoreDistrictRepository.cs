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
using LaoInsur.Territories.Districts;

namespace LaoInsur.EntityFrameworkCore.Districts
{
    public class EfCoreDistrictRepository : EfCoreRepository<LaoInsurDbContext, District, Guid>,
        IDistrictRepository
    {
        public EfCoreDistrictRepository(
            IDbContextProvider<LaoInsurDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public async Task<District> GetAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(c => c.Id.Equals(id)).Include(c => c.Province).FirstAsync();
        }

        public async Task<District> FindByCodeAsync(string code) 
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(district => district.Code == code).Include(c => c.Province).FirstAsync();
        }

        public async Task<List<District>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null) {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    district => district.NameEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    district => district.NameLao.Contains(filter)
                )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    district => district.DescriptionEng.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    district => district.DescriptionLao.Contains(filter)
                )
                .Include(c => c.Province)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
