import { Component, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { DischargeFull } from '../../../models/discharge-full.model';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DischargeService } from '../../../services/discharge.service';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { DeclarationItemService } from '../../../services/declaration-item.service';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';

@Component({
  selector: 'app-discharge-list',
  templateUrl: './discharge-list.component.html',
  styleUrl: './discharge-list.component.scss'
})
export class DischargeListComponent {
  private readonly translate = inject(TranslateService);
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  discharges: DischargeFull[] = [];
  showFilters = false;
  declarationItems: DropdownOption[] = [];
  stores: DropdownOption[] = [];
  filtersForm = new FormGroup({
    search: new FormControl<string>(''),
    dateFrom: new FormControl<Date | null>(null),
    dateTo: new FormControl<Date | null>(null),
    declarationItem: new FormControl<DropdownOption | null>(null),
    store: new FormControl<DropdownOption | null>(null)
  });

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private dischargeService: DischargeService,
    private declarationItemService: DeclarationItemService,
    private basicInformationService: BasicInformationService) {
  }
  loadDischarges(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.dischargeService.getDischarges(pageNumber, pageSize, this.getFilters()).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.discharges = res.data.items.map((item: any) => new DischargeFull(item.declarationId, item.ipasDeclarationNo, item.dischargeDate, item.vehicleNumber,
          item.wayBillNo, item.storeId, item.storeName, item.packNB, item.weight, item.volume, item.id));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  toggleFilters() {
    this.showFilters = !this.showFilters;
    if (this.showFilters) {
      if (!this.declarationItems.length) this.loadDeclarationItems();
      if (!this.stores.length) this.loadStores();
    }
  }

  loadDeclarationItems(search: string = '') {
    this.declarationItemService.getLookup(search).subscribe({
      next: (res: any) => this.declarationItems = (res.data?.items || []).map((x: any) => new DropdownOption(x.id, x.ipasDeclarationNo)),
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  loadStores(search: string = '') {
    this.basicInformationService.getLookup('Stores', search).subscribe({
      next: (res: any) => this.stores = (res.data?.items || []).map((x: any) => new DropdownOption(x.id, x.name)),
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  applyFilters() { this.loadDischarges(1, this.pageSize); }

  clearFilters() {
    this.filtersForm.reset({ search: '', dateFrom: null, dateTo: null, declarationItem: null, store: null });
    this.loadDischarges(1, this.pageSize);
  }

  private getFilters() {
    const value = this.filtersForm.getRawValue();
    return {
      search: value.search || undefined,
      dateFrom: value.dateFrom,
      dateTo: value.dateTo,
      declarationItemId: value.declarationItem?.id,
      storeId: value.store?.id
    };
  }


  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadDischarges(pageNumber, event.rows);
  }
  onAdd() {
    this.router.navigate(['/operation/discharge']);
  }

  onSend() {
    this.router.navigate(['/operation/send-discharge']);
  }

  // onEdit(id: any) {
  //   this.router.navigate(['/operation/discharge', id]);
  // }

  onDelete(event: any, id: any) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: this.translate.instant('common.deleteConfirm') as string,
      header: this.translate.instant('common.deleteConfirmation') as string,
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptLabel: this.translate.instant('common.yes') as string,
      rejectLabel: this.translate.instant('common.no') as string,
      acceptIcon: "none",
      rejectIcon: "none",

      accept: () => {
        this.dischargeService.deleteDischarge(id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: this.translate.instant('common.confirmed') as string, detail: this.translate.instant('common.recordDeleted') as string });
            this.loadDischarges();
          },
          error: (error: any) => {
            showApiError(this.messageService, error);

          }
        });
      },
      reject: () => {
        this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      }
    });
  }
}
