import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'LaoInsur',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44383/',
    redirectUri: baseUrl,
    clientId: 'LaoInsur_App',
    responseType: 'code',
    scope: 'offline_access LaoInsur',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44356',
      rootNamespace: 'LaoInsur',
    },
  },
} as Environment;
