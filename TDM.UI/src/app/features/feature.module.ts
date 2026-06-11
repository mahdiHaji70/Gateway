import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeatureRoutingModule } from './feature-routing.module';
import { BasicInformationModule } from './basic-information/basic-information.module';
import { OperationModule } from './operation/operation.module';
import { DocumentModule } from './document/document.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FeatureRoutingModule,
    BasicInformationModule,
    // OperationModule,
    // DocumentModule
  ]
})
export class FeatureModule { }
