using LaoInsur.Territories.Addresses;
using LaoInsur.Territories.Districts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Territories.Villages {
    public class Village : AuditedAggregateRoot<Guid> {
        public Village() { }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public District District { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
