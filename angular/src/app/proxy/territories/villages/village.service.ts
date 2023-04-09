import type { CreateUpdateVillageDto, SearchVillageDto, VillageDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class VillageService {
  apiName = 'Default';
  

  create = (input: CreateUpdateVillageDto) =>
    this.restService.request<any, VillageDto>({
      method: 'POST',
      url: '/api/app/village',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/village/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, VillageDto>({
      method: 'GET',
      url: `/api/app/village/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: SearchVillageDto) =>
    this.restService.request<any, PagedResultDto<VillageDto>>({
      method: 'GET',
      url: '/api/app/village',
      params: { code: input.code, nameEng: input.nameEng, nameLao: input.nameLao, descriptionEng: input.descriptionEng, descriptionLao: input.descriptionLao, postalCode: input.postalCode, districtId: input.districtId, districtName: input.districtName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateVillageDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/village/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
