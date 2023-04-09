using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Countries {
    public class CreateUpdateCountryDto {
        public CreateUpdateCountryDto() {
        }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string NationalityEng { get; set; }
        public string NationalityLao { get; set; }
        public string PostalCode { get; set; }
        public string ISO2Code { get; set; } = string.Empty;
        public string ISO3Code { get; set; } = string.Empty;
        public Guid continentId { get; set; }
    }
}
