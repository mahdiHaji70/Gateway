import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SyncGatewayComponent } from './components/sync-gateway/sync-gateway.component';
import { SyncRoutingModule } from './sync-routing.module';
import { SyncService } from './services/sync.service';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DividerModule } from 'primeng/divider';
import { TagModule } from 'primeng/tag';
import { ToastModule } from 'primeng/toast';


@NgModule({
  declarations: [
    SyncGatewayComponent
  ],
  imports: [
    CommonModule,
    SyncRoutingModule,
    ButtonModule, 
    CardModule,
    DividerModule,
    TagModule,
    ToastModule
  ],
  providers: [
    SyncService
  ]
})
export class SyncModule { }
