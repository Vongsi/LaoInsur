using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Continents {
    public interface IContinentAppService : ICrudAppService< //Defines CRUD methods
        ContinentDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateContinentDto> //Used to create/update a book
    {

    }
}
