import { Component } from '@angular/core';
import { showApiError } from '../../../../shared/services/api-error-handler.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { StoreReceiptService } from '../../services/store-receipt.service';
import { StoreReceiptWarehouse } from '../../models/store-receipt-warehouse.model';

@Component({
  selector: 'app-warehouse-allocation',
  templateUrl: './warehouse-allocation.component.html',
  styleUrl: './warehouse-allocation.component.scss'
})
export class WarehouseAllocationComponent {
  storeReceiptId!: string;
  storeReceiptNo!: string;
  warehouses: StoreReceiptWarehouse[] = [];
  sending = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private storeReceiptService: StoreReceiptService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.storeReceiptId = this.route.snapshot.paramMap.get('id')!;
    this.storeReceiptNo = this.route.snapshot.paramMap.get('srNo')!;
    this.loadWarehouses();
  }

  loadWarehouses() {
    this.storeReceiptService.getWarehouses(this.storeReceiptId).subscribe({
      next: (res: any) => this.warehouses = (res.data || []) as StoreReceiptWarehouse[],
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  sendToIpas() {
    this.sending = true;
    this.storeReceiptService.sendIpasStoreAllocation(this.storeReceiptId).subscribe({
      next: (res: any) => {
        this.sending = false;
        const result = res.data;
        if (result?.isSent) {
          this.messageService.add({ severity: 'success', summary: 'Successfully sent to IPAS' });
        } else {
          this.messageService.add({ severity: 'error', summary: 'IPAS submission failed', detail: result?.errorMessage || 'The allocation was not sent.' });
        }
      },
      error: (error: any) => {
        this.sending = false;
        showApiError(this.messageService, error);
      }
    });
  }

}