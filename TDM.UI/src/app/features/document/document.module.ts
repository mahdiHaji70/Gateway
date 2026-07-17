import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentRoutingModule } from './document-routing.module';
import { DeclarationService } from './services/declaration.service';
import { DeclarationItemService } from './services/declaration-item.service';
import { DeclarationContainerService } from './services/declaration-container.service';
import { DeclarationContainerInfoService } from './services/declaration-container-info.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { SharedModule } from '../../shared/shared.module';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { DeclarationComponent } from './components/declaration/declaration.component';
import { DeclarationListComponent } from './components/declaration/declaration-list/declaration-list.component';
import { DeclarationItemComponent } from './components/declaration-item/declaration-item.component';
import { DeclarationContainerComponent } from './components/declaration-container/declaration-container.component';
import { DeclarationContainerInfoComponent } from './components/declaration-container-info/declaration-container-info.component';
import { StoreReceiptIssueComponent } from './components/store-receipt-issue/store-receipt-issue.component';
import { StoreReceiptService } from './services/store-receipt.service';
import { StoreReceiptIssueRequestComponent } from './components/store-receipt-issue-request/store-receipt-issue-request.component';
import { StoreReceiptIssueRequestService } from './services/store-receipt-issue-request.service';
import { RequestConfirmationService } from './services/request-confirmation.service';



@NgModule({
  declarations: [
    DeclarationComponent,
    DeclarationListComponent,
    DeclarationItemComponent,
    DeclarationContainerComponent,
    DeclarationContainerInfoComponent,
    StoreReceiptIssueComponent,
    StoreReceiptIssueRequestComponent,
  ],
  imports: [
    CommonModule,
    DocumentRoutingModule,
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
  providers: [DeclarationService,
    DeclarationItemService,
    DeclarationContainerService,
    DeclarationContainerInfoService,
    StoreReceiptService,
    StoreReceiptIssueRequestService,
    RequestConfirmationService
  ]
})
export class DocumentModule { }
