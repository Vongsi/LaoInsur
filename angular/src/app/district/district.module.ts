import { NgModule } from '@angular/core';

import { DistrictRoutingModule } from './district-routing.module';
import { DistrictComponent } from './district.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    DistrictComponent
  ],
  imports: [
    SharedModule,
    DistrictRoutingModule,
    NgbDatepickerModule
  ]
})
export class DistrictModule { }
