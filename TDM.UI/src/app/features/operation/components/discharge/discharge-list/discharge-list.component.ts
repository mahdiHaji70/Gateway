import { Component } from '@angular/core';
import { OperationDetailFull } from '../../../models/discharge-full.model';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DischargeService } from '../../../services/discharge.service';

@Component({
  selector: 'app-discharge-list',
  templateUrl: './discharge-list.component.html',
  styleUrl: './discharge-list.component.scss'
})
export class DischargeListComponent {
  discharges: OperationDetailFull[] = [];

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private dischargeService: DischargeService) {
  }

  ngOnInit() {
    this.loadDischarges();
  }

  loadDischarges() {
    this.dischargeService.getDischarges().subscribe({
      next: (res: any) => {
        this.discharges = res.data.map((item: OperationDetailFull) => new OperationDetailFull(item.declarationId, item.declarationNumber, item.vehicleId, item.vehicleName,
          item.placeId, item.placeName, item.packNumber, item.weight, item.operationDate, item.operationTypeId, item.operationTypeName, item.volume, item.containerId,
          item.containerNumber, item.storeReceiptId, item.storeReceiptSerial, item.travelId, item.travelNumber, item.id
        ));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/operation/discharge']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/discharge', id]);
  }

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
            this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: 'Operation failed' });

          }
        });
      },
      reject: () => {
        this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      }
    });
  }
}
