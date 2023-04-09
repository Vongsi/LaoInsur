using LaoInsur.Territories.Districts;
using LaoInsur.Territories.Provinces;
using LaoInsur.Territories.Villages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Villages
{
    public interface IVillageRepository : IRepository<Village, Guid> {

        Task<Village> GetAsync(Guid id);

        Task<Village> FindByCodeAsync(string code);

        Task<List<Village>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
        //Task<Province> CreateAsync(string code, string nameEng, string nameLao, string descriptionEng, string descriptionLao, string postalCode, string iSO2Codes, string iSO3Codes, Guid countryId);
    }
}
