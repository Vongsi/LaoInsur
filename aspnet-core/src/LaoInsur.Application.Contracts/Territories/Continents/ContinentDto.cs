using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LaoInsur.Territories.Continents {
    public class ContinentDto : AuditedEntityDto<Guid> {
        public ContinentDto() { }
        public string NameEng { get; set; }
        public string NameLao { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionLao { get; set; }
        public string ISO2Codes { get; set; } = string.Empty;
    }
}
