using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Villages
{
    public class SearchVillageDto : PagedAndSortedResultRequestDto
    {
        public SearchVillageDto()
        {
        }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}
