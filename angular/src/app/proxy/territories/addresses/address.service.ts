import type { AddressDto, CreateUpdateAddressDto, SearchAddressDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AddressService {
  apiName = 'Default';
  

  create = (input: CreateUpdateAddressDto) =>
    this.restService.request<any, AddressDto>({
      method: 'POST',
      url: '/api/app/address',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/address/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, AddressDto>({
      method: 'GET',
      url: `/api/app/address/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: SearchAddressDto) =>
    this.restService.request<any, PagedResultDto<AddressDto>>({
      method: 'GET',
      url: '/api/app/address',
      params: { houseNo: input.houseNo, unit: input.unit, street: input.street, villageId: input.villageId, villageName: input.villageName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateAddressDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/address/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
