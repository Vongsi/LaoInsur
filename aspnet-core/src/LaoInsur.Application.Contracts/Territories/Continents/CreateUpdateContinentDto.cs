using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LaoInsur.Territories.Continents {
    public class CreateUpdateContinentDto {
        [Required]
        public string NameEng { get; set; }
        [Required]
        public string NameLao { get; set; }
        [Required]
        public string DescriptionEng { get; set; }
        [Required]
        public string DescriptionLao { get; set; }
        [Required]
        [MaxLength(2)]
        public string ISO2Codes { get; set; } = string.Empty;
    }
}
