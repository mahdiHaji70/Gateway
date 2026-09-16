import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { ManifestContainer, ManifestItem } from '../../models/manifest-item.model';
import { VesselDischarge } from '../../models/vessel-discharge.model';
import { ManifestService } from '../../services/manifest.service';
import { VesselDischargeService } from '../../services/vessel-discharge.service';

@Component({
  selector: 'app-vessel-discharge',
  templateUrl: './vessel-discharge.component.html',
  styleUrl: './vessel-discharge.component.scss'
})
export class VesselDischargeComponent {
  id?: string;
  manifestItems: DropdownOption[] = [];
  containers: DropdownOption[] = [];
  stores: DropdownOption[] = [];
  manifestItem?: ManifestItem;
  cargoSummary: string[] = [];

  form = new FormGroup({
    manifestItem: new FormControl<DropdownOption | undefined>(undefined),
    container: new FormControl<DropdownOption | undefined>(undefined),
    store: new FormControl<DropdownOption | undefined>(undefined),
    dischargeDate: new FormControl<Date | undefined>(new Date()),
    packNumber: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
    volume: new FormControl<number | undefined>(0),
    unitWeight: new FormControl<number | undefined>({ value: 0, disabled: true }),
    isNonePalletized: new FormControl<boolean>(false),
    isDamaged: new FormControl<boolean>(false),
    isVoluminous: new FormControl<boolean>(false),
    isDangerous: new FormControl<boolean>(false),
    dangerousCode: new FormControl<string | undefined>(''),
    classification: new FormControl<string | undefined>(''),
    ignitionTemperature: new FormControl<number | undefined>(0),
    ignitionTemperatureUnit: new FormControl<string | undefined>(''),
  });

  constructor(
    private manifestService: ManifestService,
    private vesselDischargeService: VesselDischargeService,
    private basicInformationService: BasicInformationService,
    private localStorageService: LocalStorageService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    debugger
    this.loadManifestItems();
    this.loadStores();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.vesselDischargeService.getById(this.id!).subscribe({
          next: (res: any) => this.loadForEdit(res.data),
          error: (error: any) => this.showApiError(error)
        });
      }
    });
  }

  loadManifestItems() {
    this.manifestService.getItemsLookup().subscribe({
      next: (res: any) => {
        this.manifestItems = (res.data || []).map((item: any) =>
          new DropdownOption(item.id, `${item.voyageNo} / ${item.manifestNo}`));
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  loadStores() {
    this.basicInformationService.getAll('Stores').subscribe({
      next: (res: any) => {
        this.stores = (res.data.items || []).map((item: any) =>
          new DropdownOption(item.id, item.name));
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  loadManifestItem(event: any) {
    if (!event?.id) return;

    this.manifestService.getItemById(event.id).subscribe({
      next: (res: any) => {
        this.manifestItem = res.data;
        this.setContainerOptions();
        this.form.patchValue({ container: undefined });
        this.applyCargoSummary();
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  setContainerOptions() {
    const item = this.manifestItem;
    const options = (item?.manifestContainers || []).map((container: ManifestContainer) =>
      new DropdownOption(container.id,
        `${container.containerNo}${container.containerTypeAndSizeCode ? ` / ${container.containerTypeAndSizeCode}` : ''}`));

    if ((item?.manifestGoods || []).length > 0) {
      options.unshift(new DropdownOption('', 'Manifest item goods'));
    }

    this.containers = options;
  }

  loadForEdit(data: any) {
    const itemOption = this.manifestItems.find(x => x.id === data.manifestItemId);
    if (itemOption) {
      this.form.patchValue({ manifestItem: itemOption });
      this.manifestService.getItemById(data.manifestItemId).subscribe({
        next: (res: any) => {
          this.manifestItem = res.data;
          this.setContainerOptions();
          const container = this.containers.find(x => x.id === data.manifestContainerId);
          this.form.patchValue({
            container,
            store: new DropdownOption(data.storeId, data.storeName),
            dischargeDate: new Date(data.dischargeDate),
            packNumber: data.packNB,
            weight: data.weight,
            volume: data.volume,
            unitWeight: data.unitWeight,
            isNonePalletized: data.isNonPalletized,
            isDamaged: data.isDamaged,
            isVoluminous: data.isVoluminous,
            isDangerous: data.isDangerous,
            dangerousCode: data.dangerousCode,
            classification: data.classification,
            ignitionTemperature: data.ignitionTemperature,
            ignitionTemperatureUnit: data.ignitionTemperatureUnit
          });
        },
        error: (error: any) => this.showApiError(error)
      });
    }
  }

  onContainerChange(event: any) {
    this.applyCargoSummary(event);
  }

  applyCargoSummary(selected?: DropdownOption) {
    const item = this.manifestItem;
    if (!item) return;
    debugger;
    const container = selected?.id
      ? item.manifestContainers.find(x => x.id === selected.id)
      : undefined;

    if (container) {
      this.cargoSummary = (container.manifestContainerGoods || []).map(good =>
        `${good.commodityName || 'Goods'} / ${good.packageName || 'Package'}: ${good.packNb} pack, ${good.grossWeight} kg`);
      const packNumber = (container.manifestContainerGoods || [])
        .reduce((sum, good) => sum + (good.packNb || 0), 0);
      const weight = (container.manifestContainerGoods || [])
        .reduce((sum, good) => sum + (good.grossWeight || 0), 0);

      this.form.patchValue({
        packNumber,
        weight,
        volume: 0,
        unitWeight: packNumber ? weight / packNumber : 0,
        isDangerous: !!container.dangerousCode,
        dangerousCode: container.dangerousCode || '',
        classification: container.classification || '',
        ignitionTemperature: container.ignitionTemperature || 0,
        ignitionTemperatureUnit: container.ignitionTemperatureUnit || ''
      });
      return;
    }

    const packNumber = (item.manifestGoods || [])
      .reduce((sum, good) => sum + (good.packNb || 0), 0);
    const weight = (item.manifestGoods || [])
      .reduce((sum, good) => sum + (good.grossWeight || 0), 0);
    const volume = (item.manifestGoods || [])
      .reduce((sum, good: any) => sum + (good.volume || 0), 0);

    this.cargoSummary = (item.manifestGoods || []).map(good =>
      `${good.commodityName || 'Goods'} / ${good.packageName || 'Package'}: ${good.packNb} pack, ${good.grossWeight} kg`);

    this.form.patchValue({
      packNumber,
      weight,
      volume,
      unitWeight: packNumber ? weight / packNumber : 0,
      isDangerous: false,
      dangerousCode: '',
      classification: '',
      ignitionTemperature: 0,
      ignitionTemperatureUnit: ''
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    const discharge = new VesselDischarge();
    discharge.id = this.id;
    discharge.terminalCode = this.localStorageService.getItem('terminalCode')!;
    discharge.storeId = this.form.get('store')?.value?.id!;
    discharge.manifestItemId = this.form.get('manifestItem')?.value?.id!;
    discharge.manifestContainerId = 'DF03DC7C-14A5-4949-9509-08DF13019A9D';//this.form.get('container')?.value?.id || undefined;
    discharge.dischargeDate = this.form.get('dischargeDate')?.value!;
    discharge.packNB = this.form.get('packNumber')?.value || 0;
    discharge.weight = this.form.get('weight')?.value || 0;
    discharge.volume = this.form.get('volume')?.value || 0;
    discharge.unitWeight = this.form.get('unitWeight')?.value || 0;
    discharge.isNonPalletized = this.form.get('isNonePalletized')?.value || false;
    discharge.isDamaged = this.form.get('isDamaged')?.value || false;
    discharge.isVoluminous = this.form.get('isVoluminous')?.value || false;
    discharge.isDangerous = this.form.get('isDangerous')?.value || false;
    discharge.dangerousCode = this.form.get('dangerousCode')?.value || '';
    discharge.classification = this.form.get('classification')?.value || '';
    discharge.ignitionTemperature = this.form.get('ignitionTemperature')?.value || 0;
    discharge.ignitionTemperatureUnit = this.form.get('ignitionTemperatureUnit')?.value || '';

    const request$ = this.id
      ? this.vesselDischargeService.putDischarge(discharge)
      : this.vesselDischargeService.postDischarge(discharge);

    request$.subscribe({
      next: () => {
        this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
        this.router.navigate(['/operation/vessel-discharge-list']);
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  clearDangerousFields(event: boolean) {
    if (!event) {
      this.form.patchValue({
        dangerousCode: '',
        classification: '',
        ignitionTemperature: 0,
        ignitionTemperatureUnit: ''
      });
    }
  }

  showApiError(error: any) {
    const errors = error?.error?.Errors;
    const detail = errors ? Object.values(errors).flat().join(' | ') : error?.message || '';
    this.messageService.add({ severity: 'error', summary: error?.error?.Message || 'Operation failed', detail });
  }

}
