import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GateInListComponent } from './components/gate-in/gate-in-list/gate-in-list.component';
import { GateInComponent } from './components/gate-in/gate-in.component';
import { GateOutListComponent } from './components/gate-out/gate-out-list/gate-out-list.component';
import { GateOutComponent } from './components/gate-out/gate-out.component';
import { WeighBridgeListComponent } from './components/weigh-bridge/weigh-bridge-list/weigh-bridge-list.component';
import { WeighBridgeComponent } from './components/weigh-bridge/weigh-bridge.component';
import { DischargeListComponent } from './components/discharge/discharge-list/discharge-list.component';
import { DischargeComponent } from './components/discharge/discharge.component';
import { OperationPlanningListComponent } from './components/operation-planning/operation-planning-list/operation-planning-list.component';
import { OperationPlanningComponent } from './components/operation-planning/operation-planning.component';
import { CargoArrivalListComponent } from './components/cargo-arrival/cargo-arrival-list/cargo-arrival-list.component';
import { CargoArrivalComponent } from './components/cargo-arrival/cargo-arrival.component';
import { OperationAggregationComponent } from './components/operation-aggregation/operation-aggregation.component';
import { ChangePackageComponent } from './components/change-package/change-package.component';
import { StoreReceiptRequestComponent } from './components/store-receipt-request/store-receipt-request.component';
import { StuffComponent } from './components/stuff/stuff.component';
import { ExitFromStoreListComponent } from './components/exit-from-store-list/exit-from-store-list.component';
import { ExitFromStoreComponent } from './components/exit-from-store-list/exit-from-store/exit-from-store.component';
import { SendDischargeComponent } from './components/discharge/send-discharge/send-discharge.component';

const routes: Routes = [  
  { path: 'gate-in-list', component: GateInListComponent},
  { path: 'gate-in', component: GateInComponent},
  { path: 'gate-in/:id', component: GateInComponent},  

  { path: 'gate-out-list', component: GateOutListComponent},
  { path: 'gate-out', component: GateOutComponent},
  { path: 'gate-out/:id', component: GateOutComponent},  

  { path: 'weigh-bridge-list', component: WeighBridgeListComponent},
  { path: 'weigh-bridge', component: WeighBridgeComponent},
  { path: 'weigh-bridge/:id', component: WeighBridgeComponent},  

  { path: 'discharge-list', component: DischargeListComponent},
  { path: 'discharge', component: DischargeComponent},
  { path: 'discharge/:id', component: DischargeComponent},

  { path: 'operation-planning-list', component: OperationPlanningListComponent},
  { path: 'operation-planning', component: OperationPlanningComponent},
  { path: 'operation-planning/:id', component: OperationPlanningComponent},
  
  { path: 'cargo-arrival-list', component: CargoArrivalListComponent},
  { path: 'cargo-arrival', component: CargoArrivalComponent},
  { path: 'cargo-arrival/:id', component: CargoArrivalComponent},

  { path: 'operation-aggregation-list', component: OperationAggregationComponent},
  { path: 'change-package', component: ChangePackageComponent},
  { path: 'stuff', component: StuffComponent},
  { path: 'store-request', component: StoreReceiptRequestComponent},
    
  { path: 'exit-from-store-list', component: ExitFromStoreListComponent},
  { path: 'exit-from-store', component: ExitFromStoreComponent},
  { path: 'exit-from-store/:id', component: ExitFromStoreComponent},
  
  { path: 'send-discharge', component: SendDischargeComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OperationRoutingModule { }
