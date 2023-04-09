using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Districts
{
    public class SearchDistrictDto : PagedAndSortedResultRequestDto
    {
        public SearchDistrictDto()
        {
        }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public Guid ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
