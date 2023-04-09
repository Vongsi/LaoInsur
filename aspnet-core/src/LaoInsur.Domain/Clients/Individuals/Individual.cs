using LaoInsur.Clients.Clients;
using LaoInsur.Clients.Occupations;
using LaoInsur.Territories.Addresses;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Clients.Individuals
{
    public class Individual : Client
    {
        public Individual () { }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public ICollection<ClientOccupations> ClientOccupations { get; set; }
        public ICollection<Country> Nationalities { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
