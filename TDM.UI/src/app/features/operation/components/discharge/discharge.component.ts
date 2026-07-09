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
  goodwayBillsRaw: any[] = [];
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
    ignitionTemperature: new FormControl<number | undefined>(0),
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

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.dischargeService.getById(this.id!).subscribe((res: any) => {
          this.loadGoodwayBills({name: res.data.ipasDeclarationNo});
          
          this.form.setValue({
            declarationItem: new DropdownOption(res.data.declarationItemId, res.data.ipasDeclarationNo),
            cargoType: new DropdownOption(res.data.cargoTypeId, res.data.cargoTypeName),
            store: new DropdownOption(res.data.storeId, res.data.storeName),
            goodwayBill: new DropdownOption(res.data.waybillId,
              `WayBiil No: ${res.data.waybillNo} , Vehicle Number: ${res.data.vehicleNumber}`),
            vehicleNumber: res.data.vehicleNumber,
            dischargeDate: new Date(res.data.dischargeDate),
            packNumber: res.data.packNB,
            weight: res.data.weight,
            volume: res.data.volume,
            isNonePalletized: res.data.isNonPalletized,
            isDamaged: res.data.isDamaged,
            isVoluminous: res.data.isVoluminous,
            isDangerous: res.data.isDangerous,
            dangerousCode: res.data.dangerousCode,
            classification: res.data.classification,
            ignitionTemperature: res.data.ignitionTemperature,
            ignitionTemperatureUnit: res.data.ignitionTemperatureUnit,

          });
        });
      }

    });
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
        this.goodwayBillsRaw = res.data;
        this.goodwayBills = res.data.map((item: any) => new DropdownOption(item.waybillId,
          `WayBiil No: ${item.waybillNo} , Vehicle Number: ${item.vehicleNumber}`));
      },
      error: (error: any) => { }
    });
  }


  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    var selectedGoodwayBill = this.goodwayBillsRaw.filter(item => item.waybillId == this.form.get('goodwayBill')?.value!.id!)[0];

    const discharge: Discharge = new Discharge(
      this.form.get('declarationItem')?.value!.id!,
      this.form.get('cargoType')?.value!.id!,
      this.form.get('store')?.value!.id!,
      selectedGoodwayBill.waybillNo,
      selectedGoodwayBill.waybillId,
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
          this.showApiError(error);
        }
      });

  }

  clearDangerousFields(event: any) {
    if (!event)
      this.form.patchValue({
        dangerousCode: '',
        classification: '',
        ignitionTemperature: 0,
        ignitionTemperatureUnit: '',
      });
  }
  showApiError(error: any) {
    const message = error?.error?.Message || 'Operation failed';
    const errors = error?.error?.Errors;

    if (errors) {
      const detail = Object.values(errors)
        .flat()
        .join(' | ');

      this.messageService.add({
        severity: 'error',
        summary: message,
        detail
      });
      return;
    }

    this.messageService.add({
      severity: 'error',
      summary: message,
      detail: error?.message || ''
    });
  }

}
