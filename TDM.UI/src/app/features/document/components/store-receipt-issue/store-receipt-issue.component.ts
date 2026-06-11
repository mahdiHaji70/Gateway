import { Component } from '@angular/core';
import { DeclarationService } from '../../services/declaration.service';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { StoreReceiptService } from '../../services/store-receipt.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-store-receipt-issue',
  templateUrl: './store-receipt-issue.component.html',
  styleUrl: './store-receipt-issue.component.scss'
})
export class StoreReceiptIssueComponent {
  selectedDeclaration: any;
  filteredItems: any;
  receiptRequests: any;
  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private storeReceiptService: StoreReceiptService,
        private messageService: MessageService
  ) {
  }

  filterItems(event: any) {
    this.filteredItems = [];
    const query = event.query.toLowerCase();

    this.declarationService.getByNumber(query).subscribe({
      next: (res: any) => {
        this.filteredItems = res.data.map((item: any) => new DropdownOption(item.id, item.number));
      },
      error: (error: any) => { }
    });
  }

  onDeclarationSelected(event: any) {
    this.storeReceiptService.getRequestsByDeclarationId(event.value.id).subscribe({
      next: (res: any) => {
        this.receiptRequests = res.data;
      },
      error: (error: any) => { }
    });
  }

  issueStoreReceipt(receiptRequest: any) {
    this.storeReceiptService.createStoreReceiptByRequestId(receiptRequest.id).subscribe({
      next: (res: any) => {       
        this.clearItems();
        this.onDeclarationSelected({ value: { id: this.selectedDeclaration.id } });
          this.messageService.add({ severity: 'success', summary: `Change package saved successfully` }); 
      },
      error: (error: any) => { }
    });
  }

  clearItems(){
    this.receiptRequests = [];
  }
}
