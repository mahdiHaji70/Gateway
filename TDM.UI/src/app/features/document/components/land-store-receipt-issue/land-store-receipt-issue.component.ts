import { Component } from '@angular/core';
import { showApiError } from '../../../../shared/services/api-error-handler.service';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { DeclarationService } from '../../services/declaration.service';
import { StoreReceiptService } from '../../services/store-receipt.service';
import { StoreReceiptHead } from '../../models/store-receipt-head.model';

@Component({
  selector: 'app-land-store-receipt-issue',
  templateUrl: './land-store-receipt-issue.component.html',
  styleUrl: './land-store-receipt-issue.component.scss'
})
export class LandStoreReceiptIssueComponent {
  declarations: DropdownOption[] = [];
  storeReceipts: StoreReceiptHead[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private messageService: MessageService,
    private storeReceiptService: StoreReceiptService
  ) {
  }

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

  loadStoreReceipts(event: any) {
    this.storeReceiptService.getStoreReceiptsByDeclarationNo(event.name).subscribe({
      next: (res: any) => {
        this.storeReceipts = res.data;
      },
      error: (error: any) => { }
    });
  }

  createStoreReceipt(storeReceipt: StoreReceiptHead) {
    this.storeReceiptService.createStoreReceipt(storeReceipt).subscribe({
      next: (res: any) => {
        this.storeReceipts = [];
        this.loadDeclarations();
        this.messageService.add({ severity: 'success', summary: `Successfully created` });
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }
}