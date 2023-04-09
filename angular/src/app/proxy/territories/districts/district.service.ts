import type { CreateUpdateDistrictDto, DistrictDto, SearchDistrictDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DistrictService {
  apiName = 'Default';
  

  create = (input: CreateUpdateDistrictDto) =>
    this.restService.request<any, DistrictDto>({
      method: 'POST',
      url: '/api/app/district',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/district/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, DistrictDto>({
      method: 'GET',
      url: `/api/app/district/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: SearchDistrictDto) =>
    this.restService.request<any, PagedResultDto<DistrictDto>>({
      method: 'GET',
      url: '/api/app/district',
      params: { code: input.code, nameEng: input.nameEng, nameLao: input.nameLao, descriptionEng: input.descriptionEng, descriptionLao: input.descriptionLao, postalCode: input.postalCode, provinceId: input.provinceId, provinceName: input.provinceName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateDistrictDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/district/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
