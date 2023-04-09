using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace LaoInsur.Territories.Countries {
    public class CountryAlreadyExistsException : BusinessException {
        public CountryAlreadyExistsException(string name)
        : base(LaoInsurDomainErrorCodes.CountryAlreadyExists) {
            WithData("name", name);
        }
    }
}
