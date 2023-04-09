import { NgModule } from '@angular/core';

import { VillageRoutingModule } from './village-routing.module';
import { VillageComponent } from './village.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    VillageComponent
  ],
  imports: [
    SharedModule,
    VillageRoutingModule,
    NgbDatepickerModule
  ]
})
export class VillageModule { }
