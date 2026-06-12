import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CargoTypes, cargoTypesDropdown } from '../../../../shared/constants/cargo-types';
import { FormControl, FormGroup } from '@angular/forms';
import { getEnumOptions } from '../../../../shared/utils/get-enum-options';
import { Commodity } from '../../../basic-information/models/commodity.model';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { Package } from '../../../basic-information/models/package.model';
import { Traffic } from '../../../basic-information/models/traffic.model';
import { DeclarationItem } from '../../models/declaration-item.model';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { DeclarationItemService } from '../../services/declaration-item.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-declaration-item',
  templateUrl: './declaration-item.component.html',
  styleUrl: './declaration-item.component.scss'
})
export class DeclarationItemComponent {
  @Input() declarationId?: string;
  @Output() successfulOperation = new EventEmitter<boolean>();
  id?: any;
  cargoTypes: { name: string; value: number }[] = [];
  commodities: DropdownOption[] = [];
  packages: DropdownOption[] = [];
  traffics: DropdownOption[] = [];

  form = new FormGroup({
    cargoType: new FormControl<{ name: string; value: CargoTypes; } | undefined>(undefined),
    commodity: new FormControl<DropdownOption | undefined>(undefined),
    package: new FormControl<DropdownOption | undefined>(undefined),
    traffic: new FormControl<DropdownOption | undefined>(undefined),
    packNumber: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
    volume: new FormControl<number | undefined>(0),
    shipMark: new FormControl<string | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private declarationItemService: DeclarationItemService,
    private messageService: MessageService,
  ) {
    this.cargoTypes = getEnumOptions(CargoTypes);
    this.loadCommodities();
    this.loadPackages();
    this.loadTraffics();
  }

  loadCommodities() {
    this.basicInformationService.getAll('commodities').subscribe({
      next: (res: any) => {
        this.commodities = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadPackages() {
    this.basicInformationService.getAll('packages').subscribe({
      next: (res: any) => {
        this.packages = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadTraffics() {
    this.basicInformationService.getAll('traffics').subscribe({
      next: (res: any) => {
        this.traffics = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadForm(id: string) {
    this.id = id;
    this.declarationItemService.getById(this.id).subscribe((res: any) => {
      var data = res.data;
      this.form.setValue({
        cargoType: cargoTypesDropdown.find(
          (type) => type.value === data.cargoTypeId),
        commodity: new DropdownOption(data.commodityId, data.commodityName),
        package: new DropdownOption(data.packageId, data.packageName),
        traffic: new DropdownOption(data.trafficId, data.trafficName),
        packNumber: data.packNumber,
        weight: data.weight,
        volume: data.volume,
        shipMark: data.shipMark
      });
    });
  }

  resetForm(){
    this.form.reset({
      cargoType: undefined,
      commodity: undefined,
      package: undefined,
      traffic: undefined,
      packNumber: 0,
      weight: 0,
      volume: 0,
      shipMark: undefined
    });
    this.id = undefined;
  }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    let cargoType: any = this.form.get('cargoType')?.value!;

    const declarationItem: DeclarationItem = new DeclarationItem(
      this.declarationId!,
      cargoType.value,
      this.form.get('commodity')?.value!.id!,
      this.form.get('packNumber')?.value!,
      this.form.get('weight')?.value!,
      this.form.get('volume')?.value!,
      this.form.get('package')?.value!.id!,
      this.form.get('traffic')?.value!.id!,
      this.form.get('shipMark')?.value!,
      this.id);

    const declarationItemAction$ = this.id
      ? this.declarationItemService.putDeclarationItem(declarationItem)
      : this.declarationItemService.postDeclarationItem(declarationItem);

      declarationItemAction$.subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.resetForm();
        this.successfulOperation.emit(true);
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }
  
}
