using LaoInsur.Territories.Countries;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Territories.Continents {
    public class Continent : AuditedAggregateRoot<Guid> {
        public Continent() { }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string ISO2Codes { get; set; } = string.Empty;
        public ICollection<Country> Countries { get; set; }
    }
}
