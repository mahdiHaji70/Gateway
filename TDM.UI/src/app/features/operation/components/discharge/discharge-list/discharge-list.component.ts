import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { DischargeFull } from '../../../models/discharge-full.model';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DischargeService } from '../../../services/discharge.service';

@Component({
  selector: 'app-discharge-list',
  templateUrl: './discharge-list.component.html',
  styleUrl: './discharge-list.component.scss'
})
export class DischargeListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  discharges: DischargeFull[] = [];

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private dischargeService: DischargeService) {
  }
  loadDischarges(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.dischargeService.getDischarges(pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.discharges = res.data.items.map((item: any) => new DischargeFull(item.declarationId, item.ipasDeclarationNo, item.dischargeDate, item.vehicleNumber,
          item.wayBillNo, item.storeId, item.storeName, item.packNB, item.weight, item.volume, item.id));
      },
      error: (error: any) => { }
    });
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
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptIcon: "none",
      rejectIcon: "none",

      accept: () => {
        this.dischargeService.deleteDischarge(id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
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