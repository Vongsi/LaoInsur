import type { ContinentDto, CreateUpdateContinentDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ContinentService {
  apiName = 'Default';
  

  create = (input: CreateUpdateContinentDto) =>
    this.restService.request<any, ContinentDto>({
      method: 'POST',
      url: '/api/app/continent',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/continent/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ContinentDto>({
      method: 'GET',
      url: `/api/app/continent/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ContinentDto>>({
      method: 'GET',
      url: '/api/app/continent',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateContinentDto) =>
    this.restService.request<any, ContinentDto>({
      method: 'PUT',
      url: `/api/app/continent/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
