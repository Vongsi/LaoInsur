using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Provinces {
    public class CreateUpdateProvinceDto
    {
        public CreateUpdateProvinceDto() {
        }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public string ISO2Codes { get; set; } = string.Empty;
        public string ISO3Codes { get; set; } = string.Empty;
        public Guid countryId { get; set; }
    }
}
