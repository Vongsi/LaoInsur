using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace LaoInsur.Territories.Countries {
    public class Country : AuditedAggregateRoot<Guid> {
        public Country() { }

        public Country(
            Guid Id
            , string code
            , string nameEng
            , string nameLao
            , string descriptionEng
            , string descriptionLao
            , string nationalityEng
            , string nationalityLao
            , string postalCode
            , string iSO2Code
            , string iSO3Code
            , Continent continent) : base(Id) {
            Code = code;
            NameEng = nameEng;
            NameLao = nameLao;
            DescriptionEng = descriptionEng;
            DescriptionLao = descriptionLao;
            NationalityEng = nationalityEng;
            NationalityLao = nationalityLao;
            PostalCode = postalCode;
            ISO2Code = iSO2Code;
            ISO3Code = iSO3Code;
            Continent = continent;
        }

        public string Code { get; set; }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string NationalityEng { get; set; }
        public string NationalityLao { get; set; }
        public string PostalCode { get; set; }
        public string ISO2Code { get; set; } = string.Empty;
        public string ISO3Code { get; set; } = string.Empty;
        public Continent Continent { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
}
