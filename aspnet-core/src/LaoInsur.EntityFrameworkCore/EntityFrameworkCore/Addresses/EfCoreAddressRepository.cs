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
using LaoInsur.Territories.Addresses;

namespace LaoInsur.EntityFrameworkCore.Addresses
{
    public class EfCoreAddressRepository : EfCoreRepository<LaoInsurDbContext, Address, Guid>,
        IAddressRepository
    {
        public EfCoreAddressRepository(
            IDbContextProvider<LaoInsurDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        public async Task<Address> GetAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(e => e.Id.Equals(id)).Include(e => e.Village).FirstAsync();
        }

        public async Task<Address> FindByHouseNoAsync(string houseNo) 
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(e => e.HouseNo == houseNo).Include(e => e.Village).FirstAsync();
        }

        public async Task<List<Address>> FindByUnitAsync(string unit)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(e => e.Unit == unit).Include(e => e.Village).ToListAsync();
        }        

        public async Task<List<Address>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null) {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.Street.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.Street.Contains(filter)
                )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.Street.Contains(filter)
                    )
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    e => e.Street.Contains(filter)
                )
                .Include(e => e.Village)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
