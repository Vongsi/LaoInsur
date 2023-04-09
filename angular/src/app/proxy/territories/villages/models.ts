import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { DistrictDto } from '../districts/models';

export interface CreateUpdateVillageDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  districtId?: string;
}

export interface SearchVillageDto extends PagedAndSortedResultRequestDto {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  districtId?: string;
  districtName?: string;
}

export interface VillageDto extends AuditedEntityDto<string> {
  code?: string;
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  postalCode?: string;
  districtDto: DistrictDto;
}
