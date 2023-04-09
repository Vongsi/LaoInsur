using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LaoInsur.Territories.Countries {
    public interface ICountryAppService : ICrudAppService< //Defines CRUD methods
        CountryDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCountryDto> //Used to create/update a book
    {

    }
}
