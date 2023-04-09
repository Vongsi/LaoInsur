using LaoInsur.Territories.Villages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Territories.Addresses {
    public class Address : AuditedAggregateRoot<Guid> {
        public Address() { }
        public string HouseNo { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string Alley { get; set; }
        public Village Village { get; set; }
    }
}
