import { Component } from '@angular/core';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { DeclarationService } from '../../services/declaration.service';
import { MessageService } from 'primeng/api';
import { StoreReceiptIssueRequestService } from '../../services/store-receipt-issue-request.service';
import { StoreReceiptIssueRequest } from '../../models/store-receipt-issue-request.model';
import { RequestConfirmationService } from '../../services/request-confirmation.service';

@Component({
  selector: 'app-store-receipt-issue-request',
  templateUrl: './store-receipt-issue-request.component.html',
  styleUrl: './store-receipt-issue-request.component.scss'
})
export class StoreReceiptIssueRequestComponent {
  declarations: DropdownOption[] = [];
  storeReceiptIssueRequests: StoreReceiptIssueRequest[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private storeReceiptIssuerequestService: StoreReceiptIssueRequestService,
    private requestConfirmationService: RequestConfirmationService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.loadDeclarations();
  }

  loadDeclarations() {
    this.declarationService.getDeclarations().subscribe({
      next: (res: any) => {
        this.declarations = res.data.items.map((item: any) => new DropdownOption(item.id, item.ipasDeclarationNo));
      },
      error: (error: any) => { }
    });
  }

  loadIssueRequests(event: any) {
    this.storeReceiptIssuerequestService.getByIpasDeclarationNo(event.name).subscribe({
      next: (res: any) => {
        this.storeReceiptIssueRequests = res.data.map((item: any) =>
          new StoreReceiptIssueRequest(item.requestId, item.date, item.ownerName, item.ownerNationalID, item.ownerRepName,
            item.ownerRepNationalID, item.hsCode, item.description, item.packageQuantity, item.weight));
      },
      error: (error: any) => { }
    });
  }

  onConfirmRequest(requestId: string, isApproved: boolean) {
    this.requestConfirmationService.confirmRequest(requestId, isApproved).subscribe({
      next: (res: any) => {
        this.storeReceiptIssueRequests = res.data.map((item: any) =>
          new StoreReceiptIssueRequest(item.requestId, item.date, item.ownerName, item.ownerNationalID, item.ownerRepName,
            item.ownerRepNationalID, item.hsCode, item.description, item.packageQuantity, item.getWeight));
      },
      error: (error: any) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Request Failed',
          detail: error?.error?.Message || error.message
        });
      }
    });
  }
}
