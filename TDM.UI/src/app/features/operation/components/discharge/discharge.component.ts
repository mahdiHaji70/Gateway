import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { DischargeService } from '../../services/discharge.service';
import { DeclarationService } from '../../services/declaration.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { Discharge } from '../../models/discharge.model';
import { DeclarationItemService } from '../../services/declaration-item.service';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';

@Component({
  selector: 'app-discharge',
  templateUrl: './discharge.component.html',
  styleUrl: './discharge.component.scss'
})
export class DischargeComponent {
  id?: string;
  declarationItems: DropdownOption[] = [];
  cargoTypes: DropdownOption[] = [];
  stores: DropdownOption[] = [];
  goodwayBills: DropdownOption[] = [];

  form = new FormGroup({
    declarationItem: new FormControl<DropdownOption | undefined>(undefined),
    cargoType: new FormControl<DropdownOption | undefined>(undefined),
    store: new FormControl<DropdownOption | undefined>(undefined),
    goodwayBill: new FormControl<DropdownOption | undefined>(undefined),
    dischargeDate: new FormControl<Date | undefined>(undefined),
    vehicleNumber: new FormControl<string | undefined>(''),
    packNumber: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
    volume: new FormControl<number | undefined>(0),
    isNonePalletized: new FormControl<boolean>(false),
    isDamaged: new FormControl<boolean>(false),
    isVoluminous: new FormControl<boolean>(false),
    isDangerous: new FormControl<boolean>(false),
    dangerousCode: new FormControl<string | undefined>(''),
    classification: new FormControl<string | undefined>(''),
    ignitionTemperature: new FormControl<string | undefined>(''),
    ignitionTemperatureUnit: new FormControl<string | undefined>(''),
  });

  /**
   *
   */
  constructor(private declarationItemService: DeclarationItemService,
    private dischargeService: DischargeService,
    private localStorageService: LocalStorageService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
    private basicInformationService: BasicInformationService) {
  }
  ngOnInit() {
    this.loadDeclarationItems();
    this.loadCargoTypes();
    this.loadStores();

    // this.route.params.subscribe((params: any) => {
    //   if (params.id) {
    //     this.id = params.id;
    //     this.operationDetailService.getById(this.id!).subscribe((res: any) => {
    //       this.form.setValue({
    //         declaration: new DropdownOption(res.data.declarationId, res.data.declarationNumber),
    //         vehicle: new DropdownOption(res.data.vehicleId, res.data.vehicleName),
    //         place: new DropdownOption(res.data.placeId, res.data.placeName),
    //         packNumber: res.data.packNumber,
    //         weight: res.data.weight,
    //         volume: res.data.volume,
    //         container: new DropdownOption(res.data.containerId, res.data.containerNumber),
    //         operationDate: new Date(res.data.operationDate),
    //       });
    //     });
    //   }

    // });
  }

  loadDeclarationItems() {
    this.declarationItemService.getAll().subscribe({
      next: (res: any) => {
        this.declarationItems = res.data.items.map((item: any) => new DropdownOption(item.id, item.ipasDeclarationNo));
      },
      error: (error: any) => { }
    });
  }

  loadCargoTypes() {
    this.basicInformationService.getAll('CargoTypes').subscribe({
      next: (res: any) => {
        this.cargoTypes = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadStores() {
    this.basicInformationService.getAll('Stores').subscribe({
      next: (res: any) => {
        this.stores = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadGoodwayBills(event: any) {
    this.dischargeService.getGoodwayBillsByDeclarationNo(event.name).subscribe({
      next: (res: any) => {
        console.log(res)
      },
      error: (error: any) => { }
    });
  }


  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    const discharge: Discharge = new Discharge(
      this.form.get('declarationItem')?.value!.id!,
      this.form.get('cargoType')?.value!.id!,
      this.form.get('store')?.value!.id!,
      this.form.get('goodwayBill')?.value!.name!,
      this.form.get('goodwayBill')?.value!.id!,
      this.form.get('dischargeDate')?.value!,
      this.form.get('vehicleNumber')?.value!,
      this.form.get('packNumber')?.value!,
      this.form.get('weight')?.value!,
      this.localStorageService.getItem('terminalCode')!,
      this.form.get('volume')?.value!,
      this.form.get('isNonePalletized')?.value!,
      this.form.get('isDamaged')?.value!,
      this.form.get('isVoluminous')?.value!,
      this.form.get('isDangerous')?.value!,
      this.form.get('dangerousCode')?.value!,
      this.form.get('classification')?.value!,
      this.form.get('ignitionTemperature')?.value!,
      this.form.get('ignitionTemperatureUnit')?.value!,
      this.id
    );

    const dischargeAction$ = this.id
      ? this.dischargeService.putDischarge(discharge)
      : this.dischargeService.postDischarge(discharge);

    dischargeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/operation/discharge-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      });

  }

  clearDangerousFields(event: any) {
    if (!event)
      this.form.patchValue({
        dangerousCode: '',
        classification: '',
        ignitionTemperature: '',
        ignitionTemperatureUnit: '',
      });
  }
}
