import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SyncGatewayComponent } from './components/sync-gateway/sync-gateway.component';


const routes: Routes = [
   { path: 'sync-gateway', component: SyncGatewayComponent },
  // { path: 'home', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SyncRoutingModule { }
