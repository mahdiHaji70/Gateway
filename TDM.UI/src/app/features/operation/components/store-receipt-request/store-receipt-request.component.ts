import { Component } from '@angular/core';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { DeclarationService } from '../../services/declaration.service';
import { StoreReceiptRequestService } from '../../services/store-receipt-request.service';
import { StoreReceiptRequest } from '../../models/store-receipt-request.model';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-store-receipt-request',
  templateUrl: './store-receipt-request.component.html',
  styleUrl: './store-receipt-request.component.scss'
})
export class StoreReceiptRequestComponent {
  selectedDeclaration: any;
  filteredItems: any;
  declarations: DropdownOption[] = [];
  declarationInventory: any[] = [];
  selectedInventory: any;

  form = new FormGroup({
    pack: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private storeReceiptRequestService: StoreReceiptRequestService,
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
    this.storeReceiptRequestService.getFinalInventoryForDeclaration(event.value.id).subscribe({
      next: (res: any) => {
        this.declarationInventory = res.data;
      },
      error: (error: any) => { }
    });
  }

  saveRequest() {
    let storeReceiptRequest = new StoreReceiptRequest();
    storeReceiptRequest.declarationId = this.selectedInventory.declarationId;
    storeReceiptRequest.packageId = this.selectedInventory.packageId;
    storeReceiptRequest.packNb = this.form.get('pack')?.value!;;
    storeReceiptRequest.weight = this.form.get('weight')?.value!;
    storeReceiptRequest.issueDate = new Date();

    this.storeReceiptRequestService.saveStoreReceiptRequest(storeReceiptRequest).subscribe({
      next: (res: any) => {
        this.resetForm();
        this.onDeclarationSelected({ value: { id: this.selectedDeclaration.id } });
        this.messageService.add({ severity: 'success', summary: `Store receipt request saved successfully` });
      },
      error: (error: any) => { }
    });
  }

  resetForm() {
    this.form.reset({
      pack: 0,
      weight: 0
    });
  }
}
