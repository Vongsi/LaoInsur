import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CountryDto } from '../countries/models';

export interface CreateUpdateProvinceDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  isO2Codes?: string;
  isO3Codes?: string;
  countryId?: string;
}

export interface ProvinceDto extends AuditedEntityDto<string> {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  isO2Codes?: string;
  isO3Codes?: string;
  countryDto: CountryDto;
}

export interface SearchProvinceDto extends PagedAndSortedResultRequestDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  isO2Codes?: string;
  isO3Codes?: string;
}
