using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Clients.Clients
{
    public class Client : AuditedAggregateRoot<Guid>
    {
        public Client() { }
        public ClientType ClientType { get; set; }
    }
}
