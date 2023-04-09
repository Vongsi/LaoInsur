import { NgModule } from '@angular/core';

import { AddressRoutingModule } from './address-routing.module';
import { AddressComponent } from './address.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AddressComponent
  ],
  imports: [
    SharedModule,
    AddressRoutingModule
  ]
})
export class AddressModule { }
