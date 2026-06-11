import { Component } from '@angular/core';
import { DeclarationService } from '../../../services/declaration.service';
import { OperationAggregationService } from '../../../services/operation-aggregation.service';
import { MessageService } from 'primeng/api';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { ExitFromInventory } from '../../../models/exit-from-inventory.model';

@Component({
  selector: 'app-exit-from-store',
  templateUrl: './exit-from-store.component.html',
  styleUrl: './exit-from-store.component.scss'
})
export class ExitFromStoreComponent {
  selectedDeclaration: any;
  filteredItems: any;
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
    private operationAggregationService: OperationAggregationService,
    private messageService: MessageService) {

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
    this.operationAggregationService.getFinalInventoryForDeclaration(event.value.id).subscribe({
      next: (res: any) => {
        this.declarationInventory = res.data;
      },
      error: (error: any) => { }
    });
  }

  saveExitFromStore() {
    let exitFromInventory = new ExitFromInventory();
    exitFromInventory.ExitPackNb = this.form.get('pack')?.value!;
    exitFromInventory.ExitWeight = this.form.get('weight')?.value!;

    this.operationAggregationService.saveExitFromStore(exitFromInventory, this.selectedInventory.id).subscribe({
      next: (res: any) => {
        this.resetForm();
        this.onDeclarationSelected({ value: { id: this.selectedDeclaration.id } });
        this.messageService.add({ severity: 'success', summary: `Change package saved successfully` });
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
