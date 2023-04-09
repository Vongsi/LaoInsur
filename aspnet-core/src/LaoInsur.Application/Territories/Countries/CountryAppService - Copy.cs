using LaoInsur.Permissions;
using LaoInsur.Territories.Continents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Countries {
    public class CountryAppService :
    CrudAppService<
        Country, //The Book entity
        CountryDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCountryDto>, //Used to create/update a book
    ICountryAppService //implement the IBookAppService
    {
        public CountryAppService(IRepository<Country, Guid> repository)
        : base(repository) {
            GetPolicyName = LaoInsurPermissions.Continents.Default;
            GetListPolicyName = LaoInsurPermissions.Continents.Default;
            CreatePolicyName = LaoInsurPermissions.Continents.Create;
            UpdatePolicyName = LaoInsurPermissions.Continents.Edit;
            DeletePolicyName = LaoInsurPermissions.Continents.Delete;
        }
    }
}
