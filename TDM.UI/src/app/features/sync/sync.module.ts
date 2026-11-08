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
import { I18nModule } from '../../core/i18n/i18n.module';


@NgModule({
  declarations: [
    SyncGatewayComponent
  ],
  imports: [
    CommonModule,
    I18nModule,
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
