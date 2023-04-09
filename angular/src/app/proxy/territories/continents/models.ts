import type { AuditedEntityDto } from '@abp/ng.core';

export interface ContinentDto extends AuditedEntityDto<string> {
  nameEng?: string;
  nameLao?: string;
  descriptionEng?: string;
  descriptionLao?: string;
  isO2Codes?: string;
}

export interface CreateUpdateContinentDto {
  nameEng: string;
  nameLao: string;
  descriptionEng: string;
  descriptionLao: string;
  isO2Codes: string;
}
