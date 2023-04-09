using LaoInsur.Clients.Clients;
using LaoInsur.Territories.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Clients.Entities
{
    public class Entity : Client
    {
        public Entity() { }
        public string EntityName { get; set; }
        public string Description { get; set; }
        public string BusinessType { get; set; }
        public string RegistrationNo { get; set; }
        public string RegisterName { get; set; }
        public DateOnly EstablishedDate { get; set; }
        public Address Address { get; set; }
    }
}
