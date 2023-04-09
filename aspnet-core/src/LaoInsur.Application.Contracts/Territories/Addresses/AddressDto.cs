using LaoInsur.Territories.Villages;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static LaoInsur.Permissions.LaoInsurPermissions;

namespace LaoInsur.Territories.Addresses
{
    public class AddressDto : AuditedEntityDto<Guid> {
        public AddressDto() {
        }
        public string HouseNo { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string Alley { get; set; }
        public VillageDto VillageDto { get; set; }
    }
}
