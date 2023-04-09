import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ProvinceDto } from '../provinces/models';

export interface CreateUpdateDistrictDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  provinceId?: string;
}

export interface DistrictDto extends AuditedEntityDto<string> {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  provinceDto: ProvinceDto;
}

export interface SearchDistrictDto extends PagedAndSortedResultRequestDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  provinceId?: string;
  provinceName?: string;
}
