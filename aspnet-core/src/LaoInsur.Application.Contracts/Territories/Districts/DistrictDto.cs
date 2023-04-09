using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Districts
{
    public class DistrictDto : AuditedEntityDto<Guid> {
        public DistrictDto() {
        }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public ProvinceDto ProvinceDto { get; set; }
    }
}
