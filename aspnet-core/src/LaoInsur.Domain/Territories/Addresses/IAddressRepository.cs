using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Addresses
{
    public interface IAddressRepository : IRepository<Address, Guid> {

        Task<Address> GetAsync(Guid id);

        Task<Address> FindByHouseNoAsync(string houseNo);

        Task<List<Address>> FindByUnitAsync(string unit);        

        Task<List<Address>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
        //Task<Province> CreateAsync(string code, string nameEng, string nameLao, string descriptionEng, string descriptionLao, string postalCode, string iSO2Codes, string iSO3Codes, Guid countryId);
    }
}
