import { Component, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { VesselDischargeService } from '../../../services/vessel-discharge.service';
import { VesselDischargeFull } from '../../../models/vessel-discharge-full.model';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { ManifestService } from '../../../services/manifest.service';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';

@Component({
  selector: 'app-vessel-discharge-list',
  templateUrl: './vessel-discharge-list.component.html',
  styleUrl: './vessel-discharge-list.component.scss'
})
export class VesselDischargeListComponent {
  private readonly translate = inject(TranslateService);
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  vesselDischarges: VesselDischargeFull[] = [];
  showFilters = false;
  manifestItems: DropdownOption[] = [];
  stores: DropdownOption[] = [];
  containers: DropdownOption[] = [];
  filtersForm = new FormGroup({
    search: new FormControl<string>(''),
    dateFrom: new FormControl<Date | null>(null),
    dateTo: new FormControl<Date | null>(null),
    manifestItem: new FormControl<DropdownOption | null>(null),
    store: new FormControl<DropdownOption | null>(null),
    container: new FormControl<DropdownOption | null>(null)
  });

  constructor(
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private vesselDischargeService: VesselDischargeService,
    private manifestService: ManifestService,
    private basicInformationService: BasicInformationService) { }
  loadVesselDischarges(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.vesselDischargeService.getVesselDischarges(pageNumber, pageSize, this.getFilters()).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.vesselDischarges = (res.data?.items || []).map((item: any) => ({
          id: item.id,
          manifestItemNo: item.manifestItemNo,
          manifestNo: item.manifestNo,
          containerNo: item.containerNo,
          storeName: item.storeName,
          dischargeDate: item.dischargeDate,
          packNB: item.packNB,
          weight: item.weight,
          isDangerous: item.isDangerous,
          isSend: item.isSend
        }));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  toggleFilters() {
    this.showFilters = !this.showFilters;
    if (this.showFilters) {
      if (!this.manifestItems.length) this.loadManifestItems();
      if (!this.stores.length) this.loadStores();
      if (!this.containers.length) this.loadContainers();
    }
  }

  loadManifestItems(search: string = '') {
    this.manifestService.getItemsLookup(search).subscribe({
      next: (res: any) => this.manifestItems = (res.data || []).map((item: any) => new DropdownOption(item.id, `${item.voyageNo} / ${item.manifestNo}`)),
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  loadStores(search: string = '') {
    this.basicInformationService.getLookup('Stores', search).subscribe({
      next: (res: any) => this.stores = (res.data?.items || []).map((item: any) => new DropdownOption(item.id, item.name)),
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  loadContainers(search: string = '') {
    this.basicInformationService.getLookup('Containers', search).subscribe({
      next: (res: any) => this.containers = (res.data?.items || []).map((item: any) => new DropdownOption(item.id, item.no)),
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  applyFilters() { this.loadVesselDischarges(1, this.pageSize); }

  clearFilters() {
    this.filtersForm.reset({ search: '', dateFrom: null, dateTo: null, manifestItem: null, store: null, container: null });
    this.loadVesselDischarges(1, this.pageSize);
  }

  private getFilters() {
    const value = this.filtersForm.getRawValue();
    return {
      search: value.search || undefined,
      dateFrom: value.dateFrom,
      dateTo: value.dateTo,
      manifestItemId: value.manifestItem?.id,
      storeId: value.store?.id,
      containerId: value.container?.id
    };
  }


  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadVesselDischarges(pageNumber, event.rows);
  }
  onAdd() {
    this.router.navigate(['/operation/vessel-discharge']);
  }

  onSend() {
    this.router.navigate(['/operation/send-vessel-discharge']);
  }

  onEdit(id: string) {
    this.router.navigate(['/operation/vessel-discharge', id]);
  }

  onDelete(event: any, id: string) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: this.translate.instant('common.deleteConfirm') as string,
      header: this.translate.instant('common.deleteConfirmation') as string,
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      accept: () => {
        this.vesselDischargeService.deleteDischarge(id).subscribe({
          next: () => {
            this.messageService.add({ severity: 'info', summary: this.translate.instant('common.confirmed') as string, detail: this.translate.instant('common.recordDeleted') as string });
            this.loadVesselDischarges();
          },
          error: (error: any) => showApiError(this.messageService, error)
        });
      }
    });
  }


}
