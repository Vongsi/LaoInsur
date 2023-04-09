import { NgModule } from '@angular/core';
import { ProvinceRoutingModule } from './province-routing.module';
import { ProvinceComponent } from './province.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    ProvinceComponent
  ],
  imports: [
    SharedModule,
    ProvinceRoutingModule,
    NgbDatepickerModule
  ]
})
export class ProvinceModule { }
