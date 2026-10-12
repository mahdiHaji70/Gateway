import { Component } from '@angular/core';
import { showApiError } from '../../../../shared/services/api-error-handler.service';
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
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  loadStoreReceipts(event: any) {
    this.storeReceiptService.getStoreReceiptsByIpasManifestItemId(event.id).subscribe({
      next: (res: any) => {
        this.storeReceipts = res.data;
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  createStoreReceipt(storeReceipt: StoreReceiptHead) {
    this.storeReceiptService.createStoreReceipt(storeReceipt).subscribe({
      next: (res: any) => {
        this.storeReceipts = [];
        this.loadManifestItems();
        this.messageService.add({ severity: 'success', summary: `Successfully created` });
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }
}