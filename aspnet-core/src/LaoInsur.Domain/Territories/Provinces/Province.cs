using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Districts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Territories.Provinces {
    public class Province : AuditedAggregateRoot<Guid> {

        public Province() { }

        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public string ISO2Codes { get; set; } = string.Empty;
        public string ISO3Codes { get; set; } = string.Empty;
        public Country Country { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
