using LaoInsur.Clients.Occupations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaoInsur.Clients.Clients
{
    public class ClientOccupations
    {
        public ClientOccupations() { }
        public Client Client { get; set; }
        public Occupation Occupation { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set;}
        public DateTimeOffset FromDateOffset { get; set; }
        public DateTimeOffset ToDateOffset { get;set; }
        public bool Active { get; set; }
    }
}
