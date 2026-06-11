import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { DeclarationService } from '../../services/declaration.service';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { OperationAggregationService } from '../../services/operation-aggregation.service';
import { SplitAggregation } from '../../models/split-aggregation.model';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-change-package',
  templateUrl: './change-package.component.html',
  styleUrl: './change-package.component.scss'
})
export class ChangePackageComponent {
  selectedDeclaration: any;
  filteredItems: any;
  packages: DropdownOption[] = [];
  declarations: DropdownOption[] = [];
  declarationInventory: any[] = [];
  selectedInventory: any;

  form = new FormGroup({
    package: new FormControl<DropdownOption | undefined>(undefined),
    pack: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private basicInformationService: BasicInformationService,
    private operationAggregationService: OperationAggregationService,
    private messageService: MessageService
  ) {
    this.loadPackages();
  }
  
  loadPackages() {
    this.basicInformationService.getAll('Package').subscribe({
      next: (res: any) => {
        this.packages = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  filterItems(event: any) {
    this.filteredItems = [];
    const query = event.query.toLowerCase();
    // this.filteredItems = this.declarations.filter(c =>
    //   c.name.toLowerCase().includes(query)
    // );

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
        console.log(this.declarationInventory);
      },
      error: (error: any) => { }
    });
  }

  saveRequest() {
    let splitAggregation = new SplitAggregation();
    splitAggregation.newPackNb = this.form.get('pack')?.value!;
    splitAggregation.newWeight = this.form.get('weight')?.value!;
    splitAggregation.packageId = this.form.get('package')?.value?.id;
    splitAggregation.operationTypeId = '8940AB97-AFB7-4932-8600-ACF72CCC17AB';

    this.operationAggregationService.saveChangePackage(splitAggregation, this.selectedInventory.id).subscribe({
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
      package: undefined,
      pack: 0,
      weight: 0
    });
  }
}
