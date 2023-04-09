import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/territories',
        name: '::Menu:Territories',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/continents',
        name: '::Menu:Continents',
        parentName: '::Menu:Territories',
        layout: eLayoutType.application,
        requiredPolicy: 'LaoInsur.Continents',
      },
      {
        path: '/countries',
        name: '::Menu:Countries',
        parentName: '::Menu:Territories',
        layout: eLayoutType.application,
        requiredPolicy: 'LaoInsur.Countries',
      },
      {
        path: '/provinces',
        name: '::Menu:Provinces',
        parentName: '::Menu:Territories',
        layout: eLayoutType.application,
        requiredPolicy: 'LaoInsur.Provinces',
      },
      {
        path: '/districts',
        name: '::Menu:Districts',
        parentName: '::Menu:Territories',
        layout: eLayoutType.application,
        requiredPolicy: 'LaoInsur.Districts',
      },
      {
        path: '/villages',
        name: '::Menu:Villages',
        parentName: '::Menu:Territories',
        layout: eLayoutType.application,
        requiredPolicy: 'LaoInsur.Villages',
      },
      {
        path: '/addresses',
        name: '::Menu:Addresses',
        parentName: '::Menu:Territories',
        layout: eLayoutType.application,
        requiredPolicy: 'LaoInsur.Addresses',
      }


    ]);
  };
}
