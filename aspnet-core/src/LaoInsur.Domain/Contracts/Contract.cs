using LaoInsur.Clients;
using LaoInsur.Clients.Clients;
using LaoInsur.Clients.Coporates;
using LaoInsur.Clients.Individuals;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Contracts
{
    public class Contract : AuditedAggregateRoot<Guid>
    {
        public Contract() { }
        public ClientType ClientType { get; set; }
        public Client Client { get; set; }
        public DateTime CommencementDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateOnly IssuanceDate { get; set; }
        public bool Active { get; set; }
    }
}
