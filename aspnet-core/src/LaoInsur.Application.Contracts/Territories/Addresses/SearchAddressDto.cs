using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Addresses
{
    public class SearchAddressDto : PagedAndSortedResultRequestDto
    {
        public SearchAddressDto()
        {
        }
        public string HouseNo { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string Alley { get; set; }
        public Guid VillageId { get; set; }
        public string VillageName { get; set; }
    }
}
