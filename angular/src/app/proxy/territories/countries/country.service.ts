import type { CountryDto, CreateUpdateCountryDto, SearchCountryDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  apiName = 'Default';
  

  create = (input: CreateUpdateCountryDto) =>
    this.restService.request<any, CountryDto>({
      method: 'POST',
      url: '/api/app/country',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/country/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, CountryDto>({
      method: 'GET',
      url: `/api/app/country/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: SearchCountryDto) =>
    this.restService.request<any, PagedResultDto<CountryDto>>({
      method: 'GET',
      url: '/api/app/country',
      params: { code: input.code, nameEng: input.nameEng, nameLao: input.nameLao, descriptionEng: input.descriptionEng, descriptionLao: input.descriptionLao, postalCode: input.postalCode, isO2Codes: input.isO2Codes, isO3Codes: input.isO3Codes, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateCountryDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/country/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
