import type { CreateUpdateProvinceDto, ProvinceDto, SearchProvinceDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ProvinceService {
  apiName = 'Default';
  

  create = (input: CreateUpdateProvinceDto) =>
    this.restService.request<any, ProvinceDto>({
      method: 'POST',
      url: '/api/app/province',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/province/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ProvinceDto>({
      method: 'GET',
      url: `/api/app/province/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: SearchProvinceDto) =>
    this.restService.request<any, PagedResultDto<ProvinceDto>>({
      method: 'GET',
      url: '/api/app/province',
      params: { code: input.code, nameEng: input.nameEng, nameLao: input.nameLao, descriptionEng: input.descriptionEng, descriptionLao: input.descriptionLao, postalCode: input.postalCode, isO2Codes: input.isO2Codes, isO3Codes: input.isO3Codes, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateProvinceDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/province/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
