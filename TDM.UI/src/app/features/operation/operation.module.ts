import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperationRoutingModule } from './operation-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { SharedModule } from '../../shared/shared.module';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { GateService } from './services/gate.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { GateInComponent } from './components/gate-in/gate-in.component';
import { GateInListComponent } from './components/gate-in/gate-in-list/gate-in-list.component';
import { GateOutComponent } from './components/gate-out/gate-out.component';
import { GateOutListComponent } from './components/gate-out/gate-out-list/gate-out-list.component';
import { WeighBridgeComponent } from './components/weigh-bridge/weigh-bridge.component';
import { WeighBridgeListComponent } from './components/weigh-bridge/weigh-bridge-list/weigh-bridge-list.component';
import { WeighBridgeService } from './services/weigh-bridge.service';
import { DischargeComponent } from './components/discharge/discharge.component';
import { DischargeListComponent } from './components/discharge/discharge-list/discharge-list.component';
import { OperationPlanningComponent } from './components/operation-planning/operation-planning.component';
import { OperationPlanningListComponent } from './components/operation-planning/operation-planning-list/operation-planning-list.component';
import { OperationPlanningService } from './services/operation-planning.service';
import { OperationDetailService } from './services/operation-detail.service';
import { CargoArrivalComponent } from './components/cargo-arrival/cargo-arrival.component';
import { CargoArrivalListComponent } from './components/cargo-arrival/cargo-arrival-list/cargo-arrival-list.component';
import { CargoArrivalService } from './services/cargo-arrival.service';
import { OperationAggregationService } from './services/operation-aggregation.service';
import { OperationAggregationComponent } from './components/operation-aggregation/operation-aggregation.component';
import { ChangePackageComponent } from './components/change-package/change-package.component';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { StoreReceiptRequestComponent } from './components/store-receipt-request/store-receipt-request.component';
import { StoreReceiptRequestService } from './services/store-receipt-request.service';
import { StuffComponent } from './components/stuff/stuff.component';
import { StuffService } from './services/stuff.service';
import { DeclarationService } from './services/declaration.service';
import { ExitFromStoreListComponent } from './components/exit-from-store-list/exit-from-store-list.component';
import { ExitFromStoreComponent } from './components/exit-from-store-list/exit-from-store/exit-from-store.component';

@NgModule({
  declarations: [    
    GateInComponent,
    GateInListComponent,
    GateOutComponent,
    GateOutListComponent,
    WeighBridgeComponent,
    WeighBridgeListComponent,
    DischargeComponent,
    DischargeListComponent,
    OperationPlanningComponent,
    OperationPlanningListComponent,
    CargoArrivalComponent,
    CargoArrivalListComponent,
    OperationAggregationComponent,
    ChangePackageComponent,
    StoreReceiptRequestComponent,
    StuffComponent,
    ExitFromStoreListComponent,
    ExitFromStoreComponent    
  ],
  imports: [
    CommonModule,
    OperationRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    ToastModule,
    SharedModule,
    ButtonModule,
    TableModule,
    ToolbarModule,
    DialogModule,
    InputNumberModule,
    ConfirmDialogModule,
    AutoCompleteModule,
  ],
  providers: [
    DeclarationService,
    GateService,
    ConfirmationService,
    MessageService,
    WeighBridgeService,
    OperationPlanningService,
    OperationDetailService,
    CargoArrivalService,
    OperationAggregationService,
    StoreReceiptRequestService,
    StuffService
  ]
})
export class OperationModule { }
