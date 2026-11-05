import { Component } from '@angular/core';
import { StoreReceiptHead } from '../../models/store-receipt-head.model';
import { StoreReceiptService } from '../../services/store-receipt.service';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { showApiError } from '../../../../shared/services/api-error-handler.service';

@Component({
  selector: 'app-store-receipt-list',
  templateUrl: './store-receipt-list.component.html',
  styleUrl: './store-receipt-list.component.scss'
})
export class StoreReceiptListComponent {
  storeReceipts: StoreReceiptHead[] = [];
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  showFilters = false;
  consigneeOptions: DropdownOption[] = [];
  consigneeRepOptions: DropdownOption[] = [];
  trafficOptions: DropdownOption[] = [];
  cargoTypeOptions: DropdownOption[] = [];
  arrivalTypeOptions: DropdownOption[] = [new DropdownOption('0', 'Arrival Type 0'), new DropdownOption('1', 'Arrival Type 1')];
  filtersForm = new FormGroup({
    search: new FormControl<string>(''),
    dateFrom: new FormControl<Date | null>(null),
    dateTo: new FormControl<Date | null>(null),
    consignee: new FormControl<DropdownOption | null>(null),
    consigneeRep: new FormControl<DropdownOption | null>(null),
    traffic: new FormControl<DropdownOption | null>(null),
    cargoType: new FormControl<DropdownOption | null>(null),
    arrivalTypeCode: new FormControl<DropdownOption | null>(null)
  });


  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private storeReceiptService: StoreReceiptService,
    private basicInformationService: BasicInformationService) {
  }

  ngOnInit() {
    this.loadStoreReceipts();
  }

  loadStoreReceipts(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.storeReceiptService.getStoreReceipts(pageNumber, pageSize, this.getFilters()).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.storeReceipts = res.data.items || [];
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  onPageChange(event: any) {
    this.loadStoreReceipts(Math.floor(event.first / event.rows) + 1, event.rows);
  }

  toggleFilters() {
    this.showFilters = !this.showFilters;
    if (this.showFilters) {
      if (!this.consigneeOptions.length) this.loadOptions('consignee');
      if (!this.consigneeRepOptions.length) this.loadOptions('consigneeRep');
      if (!this.trafficOptions.length) this.loadOptions('traffic');
      if (!this.cargoTypeOptions.length) this.loadOptions('cargoType');
    }
  }

  loadOptions(target: 'consignee' | 'consigneeRep' | 'traffic' | 'cargoType', search: string = '') {
    const paths: Record<typeof target, string> = {
      consignee: 'Companies', consigneeRep: 'Companies', traffic: 'Traffics', cargoType: 'CargoTypes'
    };
    this.basicInformationService.getLookup(paths[target], search).subscribe({
      next: (res: any) => {
        const options = (res.data?.items || []).map((item: any) => new DropdownOption(item.id, item.name));
        if (target === 'consignee') this.consigneeOptions = options;
        else if (target === 'consigneeRep') this.consigneeRepOptions = options;
        else if (target === 'traffic') this.trafficOptions = options;
        else this.cargoTypeOptions = options;
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  applyFilters() { this.loadStoreReceipts(1, this.pageSize); }

  clearFilters() {
    this.filtersForm.reset({ search: '', dateFrom: null, dateTo: null, consignee: null, consigneeRep: null, traffic: null, cargoType: null, arrivalTypeCode: null });
    this.loadStoreReceipts(1, this.pageSize);
  }

  private getFilters() {
    const value = this.filtersForm.getRawValue();
    return {
      search: value.search || undefined,
      dateFrom: value.dateFrom,
      dateTo: value.dateTo,
      consigneeId: value.consignee?.id,
      consigneeRepId: value.consigneeRep?.id,
      trafficId: value.traffic?.id,
      cargoTypeId: value.cargoType?.id,
      arrivalTypeCode: value.arrivalTypeCode?.id
    };
  }

  onIssueLandSide() {
    this.router.navigate(['/document/land-store-receipt-issue']);
  }

  onIssueMarineSide() {
    this.router.navigate(['/document/marine-store-receipt-issue']);
  }

  onWarehouseAllocation(id: string, srNo: string) {
    this.router.navigate(['/document/warehouse-allocation', id, srNo]);
  }

  onLoadingPermit(storeReceipt: StoreReceiptHead) {
    const route = String(storeReceipt.arrivalTypeCode) === '0'
      ? '/operation/vessel-loading-permit'
      : '/operation/loading-permit';
    this.router.navigate([route, storeReceipt.ipasStoreReceiptId, storeReceipt.ipasStoreReceiptNo]);
  }
}
