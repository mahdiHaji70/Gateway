import { Component } from '@angular/core';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { StoreReceiptHead } from '../../models/store-receipt-head.model';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { StoreReceiptService } from '../../services/store-receipt.service';
import { ManifestService } from '../../services/manifest.service';

@Component({
  selector: 'app-marine-store-receipt-issue',
  templateUrl: './marine-store-receipt-issue.component.html',
  styleUrl: './marine-store-receipt-issue.component.scss'
})
export class MarineStoreReceiptIssueComponent {
  manifestItems: DropdownOption[] = [];
  storeReceipts: StoreReceiptHead[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private manifestService: ManifestService,
    private messageService: MessageService,
    private storeReceiptService: StoreReceiptService) {
  }

  ngOnInit() {
    this.loadManifestItems()
  }

  loadManifestItems() {
    this.manifestService.getItemsLookup().subscribe({
      next: (res: any) => {
        this.manifestItems = (res.data || []).map((item: any) =>
          new DropdownOption(item.ipasItemId, `${item.voyageNo} / ${item.manifestNo}`));
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  loadStoreReceipts(event: any) {
    this.storeReceiptService.getStoreReceiptsByIpasManifestItemId(event.id).subscribe({
      next: (res: any) => {
        this.storeReceipts = res.data;
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  createStoreReceipt(storeReceipt: StoreReceiptHead) {
    this.storeReceiptService.createStoreReceipt(storeReceipt).subscribe({
      next: (res: any) => {
        this.storeReceipts = [];
        this.loadManifestItems();
        this.messageService.add({ severity: 'success', summary: `Successfully created` });
      },
      error: (error: any) => {
        const errorResponse = error?.error;

        if (errorResponse?.errors && typeof errorResponse.errors === 'object') {
          const errorMessages = Object.values(errorResponse.errors)
            .flat()
            .join('\n');

          this.messageService.add({
            severity: 'error',
            summary: errorResponse.title || 'Validation Error',
            detail: errorMessages
          });
        } else {
          this.messageService.add({
            severity: 'error',
            summary: 'Request Failed',
            detail: errorResponse?.Message || errorResponse?.title || error.message || 'An unexpected error occurred.'
          });
        }
      }
    });
  }

  showApiError(error: any) {
    const errors = error?.error?.Errors;
    const detail = errors ? Object.values(errors).flat().join(' | ') : error?.message || '';
    this.messageService.add({ severity: 'error', summary: error?.error?.Message || 'Operation failed', detail });
  }

}
