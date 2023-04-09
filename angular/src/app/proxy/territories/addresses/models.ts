import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { VillageDto } from '../villages/models';

export interface AddressDto extends AuditedEntityDto<string> {
  houseNo?: string;
  unit?: string;
  street?: string;
  alley?: string;
  villageDto: VillageDto;
}

export interface CreateUpdateAddressDto {
  houseNo?: string;
  unit?: string;
  street?: string;
  villageId?: string;
}

export interface SearchAddressDto extends PagedAndSortedResultRequestDto {
  houseNo?: string;
  unit?: string;
  street?: string;
  villageId?: string;
  villageName?: string;
}
