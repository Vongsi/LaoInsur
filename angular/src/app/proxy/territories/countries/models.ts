import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ContinentDto } from '../continents/models';

export interface CountryDto extends AuditedEntityDto<string> {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  isO2Codes?: string;
  isO3Codes?: string;
  continentDto: ContinentDto;
}

export interface CreateUpdateCountryDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  isO2Codes?: string;
  isO3Codes?: string;
  continentId?: string;
}

export interface SearchCountryDto extends PagedAndSortedResultRequestDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  isO2Codes?: string;
  isO3Codes?: string;
}
