import { Component } from '@angular/core';
import { StoreReceiptHead } from '../../models/store-receipt-head.model';
import { StoreReceiptService } from '../../services/store-receipt.service';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-store-receipt-list',
  templateUrl: './store-receipt-list.component.html',
  styleUrl: './store-receipt-list.component.scss'
})
export class StoreReceiptListComponent {
  storeReceipts: StoreReceiptHead[] = [];


  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private storeReceiptService: StoreReceiptService) {
  }

  ngOnInit() {
    this.loadStoreReceipts();
  }

  loadStoreReceipts() {
    this.storeReceiptService.getStoreReceipts().subscribe({
      next: (res: any) => {
        this.storeReceipts = res.data.items;
      },
      error: (error: any) => { }
    });
  }

  onIssueLandSide() {
    this.router.navigate(['/document/land-store-receipt-issue']);
  }

  onIssueMarineSide() {
    this.router.navigate(['/document/marine-store-receipt-issue']);
  }

  onWarehouseAllocation(id: string, srNo: string) {
    this.router.navigate(['/document/warehouse-allocation', id, srNo]);
  }

  onLoadingPermit(storeReceipt: StoreReceiptHead) {
    const route = String(storeReceipt.arrivalTypeCode) === '0'
      ? '/operation/vessel-loading-permit'
      : '/operation/loading-permit';
    this.router.navigate([route, storeReceipt.ipasStoreReceiptId, storeReceipt.ipasStoreReceiptNo]);
  }
}
