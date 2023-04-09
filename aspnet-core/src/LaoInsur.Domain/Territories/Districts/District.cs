using LaoInsur.Territories.Provinces;
using LaoInsur.Territories.Villages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Territories.Districts {
    public class District : AuditedAggregateRoot<Guid> {
        public District() { }
        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string PostalCode { get; set; }
        public Province Province { get; set; }
        public ICollection<Village> Villages { get; set; }
    }
}
