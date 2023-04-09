import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';

import { CountryRoutingModule } from './country-routing.module';
import { CountryComponent } from './country.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    CountryComponent
  ],
  imports: [
    SharedModule,
    CountryRoutingModule,
    NgbDatepickerModule
  ]
})
export class CountryModule { }
