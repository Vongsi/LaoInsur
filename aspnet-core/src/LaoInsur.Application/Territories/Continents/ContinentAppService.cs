using LaoInsur.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LaoInsur.Territories.Continents {
    public class ContinentAppService :
    CrudAppService<
        Continent, //The Book entity
        ContinentDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateContinentDto>, //Used to create/update a book
    IContinentAppService //implement the IBookAppService
    {
        public ContinentAppService(IRepository<Continent, Guid> repository)
        : base(repository) {
            GetPolicyName = LaoInsurPermissions.Continents.Default;
            GetListPolicyName = LaoInsurPermissions.Continents.Default;
            CreatePolicyName = LaoInsurPermissions.Continents.Create;
            UpdatePolicyName = LaoInsurPermissions.Continents.Edit;
            DeletePolicyName = LaoInsurPermissions.Continents.Delete;
        }
    }
}
