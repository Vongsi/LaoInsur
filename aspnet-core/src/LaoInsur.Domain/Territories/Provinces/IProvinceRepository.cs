using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Provinces
{
    public interface IProvinceRepository : IRepository<Province, Guid> {

        Task<Province> GetAsync(Guid id);

        Task<Province> FindByCodeAsync(string code);

        Task<List<Province>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
        //Task<Province> CreateAsync(string code, string nameEng, string nameLao, string descriptionEng, string descriptionLao, string postalCode, string iSO2Codes, string iSO3Codes, Guid countryId);
    }
}
