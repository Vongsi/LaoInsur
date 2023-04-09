using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Provinces
{
    public class ProvinceDto : AuditedEntityDto<Guid> {
        public ProvinceDto() {
        }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public string ISO2Codes { get; set; } = string.Empty;
        public string ISO3Codes { get; set; } = string.Empty;
        public CountryDto CountryDto { get; set; }
    }
}
