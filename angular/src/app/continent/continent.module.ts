import { NgModule } from '@angular/core';

import { ContinentRoutingModule } from './continent-routing.module';
import { ContinentComponent } from './continent.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap'; // add this line

@NgModule({
  declarations: [
    ContinentComponent
  ],
  imports: [
    ContinentRoutingModule,
    SharedModule,
    NgbDatepickerModule, // add this line
  ]
})
export class ContinentModule { }
