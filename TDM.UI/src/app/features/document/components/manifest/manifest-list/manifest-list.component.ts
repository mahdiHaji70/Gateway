import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ManifestService } from '../../../services/manifest.service';
import { ManifestFull } from '../../../models/manifest-full.model';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';

@Component({
  selector: 'app-manifest-list',
  templateUrl: './manifest-list.component.html',
  styleUrl: './manifest-list.component.scss'
})
export class ManifestListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  manifests: ManifestFull[] = [];
  showFilters = false;
  trafficOptions: DropdownOption[] = [];
  consigneeOptions: DropdownOption[] = [];
  cargoTypeOptions: DropdownOption[] = [];
  commodityOptions: DropdownOption[] = [];
  packageOptions: DropdownOption[] = [];
  filtersForm = new FormGroup({
    search: new FormControl<string>(''),
    dateFrom: new FormControl<Date | null>(null),
    dateTo: new FormControl<Date | null>(null),
    traffic: new FormControl<DropdownOption | null>(null),
    consignee: new FormControl<DropdownOption | null>(null),
    cargoType: new FormControl<DropdownOption | null>(null),
    commodity: new FormControl<DropdownOption | null>(null),
    package: new FormControl<DropdownOption | null>(null)
  });

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private manifestService: ManifestService,
    private basicInformationService: BasicInformationService) {
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadManifests(pageNumber, event.rows);
  }
  onFetchingManifests() {
    this.router.navigate(['/document/manifest']);
  }

  loadManifests(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.manifestService.getManifests(pageNumber, pageSize, this.getFilters()).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.manifests = res.data.items.map((item: any) =>
          new ManifestFull(item.id!, item.manifestRegistrationNumber, item.voyageNo, item.noticeNo, item.shipAgent,
            item.vesselName, item.imo, item.manifestNo, item.trafficName, item.consigneeName, item.cargoTypeName, item.hsCode, item.commodityName, item.packageName
            , item.packNb, item.grossWeight, item.container));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  toggleFilters() {
    this.showFilters = !this.showFilters;
    if (this.showFilters) {
      if (!this.trafficOptions.length) this.loadOptions('traffic');
      if (!this.consigneeOptions.length) this.loadOptions('consignee');
      if (!this.cargoTypeOptions.length) this.loadOptions('cargoType');
      if (!this.commodityOptions.length) this.loadOptions('commodity');
      if (!this.packageOptions.length) this.loadOptions('package');
    }
  }

  loadOptions(target: 'traffic' | 'consignee' | 'cargoType' | 'commodity' | 'package', search: string = '') {
    const paths: Record<typeof target, string> = {
      traffic: 'Traffics', consignee: 'Companies', cargoType: 'CargoTypes', commodity: 'Commodities', package: 'Packages'
    };
    this.basicInformationService.getLookup(paths[target], search).subscribe({
      next: (res: any) => {
        const options = (res.data?.items || []).map((item: any) => new DropdownOption(item.id, item.name));
        if (target === 'traffic') this.trafficOptions = options;
        else if (target === 'consignee') this.consigneeOptions = options;
        else if (target === 'cargoType') this.cargoTypeOptions = options;
        else if (target === 'commodity') this.commodityOptions = options;
        else this.packageOptions = options;
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  applyFilters() { this.loadManifests(1, this.pageSize); }

  clearFilters() {
    this.filtersForm.reset({ search: '', dateFrom: null, dateTo: null, traffic: null, consignee: null, cargoType: null, commodity: null, package: null });
    this.loadManifests(1, this.pageSize);
  }

  private getFilters() {
    const value = this.filtersForm.getRawValue();
    return {
      search: value.search || undefined,
      dateFrom: value.dateFrom,
      dateTo: value.dateTo,
      trafficId: value.traffic?.id,
      consigneeId: value.consignee?.id,
      cargoTypeId: value.cargoType?.id,
      commodityId: value.commodity?.id,
      packageId: value.package?.id
    };
  }
}
