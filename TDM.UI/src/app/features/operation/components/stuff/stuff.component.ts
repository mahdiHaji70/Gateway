import { Component } from '@angular/core';
import { DeclarationService } from '../../services/declaration.service';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { OperationAggregationService } from '../../services/operation-aggregation.service';
import { FormControl, FormGroup } from '@angular/forms';
import { StuffAggregation } from '../../models/stuff-aggregation.model';
import { StuffService } from '../../services/stuff.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-stuff',
  templateUrl: './stuff.component.html',
  styleUrl: './stuff.component.scss'
})
export class StuffComponent {
  selectedDeclaration: any;
  filteredItems: any;
  declarationInventory: any[] = [];
 selectedInventory: any;
 containerInventory: DropdownOption[] = [];
 containerDeclarationId: any;
 
 form = new FormGroup({
     container: new FormControl<DropdownOption | undefined>(undefined),
     pack: new FormControl<number | undefined>(0),
     weight: new FormControl<number | undefined>(0),
     date: new FormControl<Date | undefined>(undefined),
   });
  /**
   *
   */
  constructor(private declarationService: DeclarationService,
      private operationAggregationService: OperationAggregationService,
    private stuffService: StuffService,
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

  onSelectInventory(item: any){
    this.selectedInventory = item;

    this.operationAggregationService.getContainerInventoryForConsignee(item.consigneeId).subscribe({
      next: (res: any) => {
        this.containerInventory = res.data.map((item: any) => new DropdownOption(item.containerId, item.container));     
        this.containerDeclarationId = res.data[0].declarationdId;
      },
      error: (error: any) => { }
    });
  }

  saveRequest(){
    let stuffAggregation = new StuffAggregation();
    stuffAggregation.declarationId = this.selectedInventory.declarationId;
    stuffAggregation.newPackNb = this.selectedInventory.packNb;
    stuffAggregation.newWeight = this.selectedInventory.netWeight;
    stuffAggregation.packageId = this.selectedInventory.packageId;
    stuffAggregation.stuffDto.declarationId = this.containerDeclarationId;
    stuffAggregation.stuffDto.containerId = this.form.get('container')?.value?.id;
    stuffAggregation.stuffDto.packNb = this.form.get('weight')?.value!;
    stuffAggregation.stuffDto.netWeight = this.form.get('pack')?.value!;
    stuffAggregation.stuffDto.stuffDate = this.form.get('date')?.value!;
    stuffAggregation.stuffDto.assignmentNumber = '123';

    this.stuffService.create(stuffAggregation).subscribe({
      next: (res: any) => {
        this.resetForm();
        this.onDeclarationSelected({ value: { id: this.selectedDeclaration.id } });
        this.messageService.add({ severity: 'success', summary: `Store receipt request saved successfully` });
      },
      error: (error: any) => { 
        this.messageService.add({ severity: 'error', summary: error.error.Message });
      }
    });
  }

  
  resetForm() {
    this.form.reset({
      container: undefined,
      pack: 0,
      weight: 0,
      date: undefined
    });
  }
}
