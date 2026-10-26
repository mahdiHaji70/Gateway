import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { Gate } from '../../../models/gate.model';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { GateFull } from '../../../models/gate-full.model';
import { GateService } from '../../../services/gate.service';

@Component({
  selector: 'app-gate-in-list',
  templateUrl: './gate-in-list.component.html',
  styleUrl: './gate-in-list.component.scss'
})
export class GateInListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

gates: GateFull[] = [];

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
  private gateService: GateService) {
  }
  loadGates(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.gateService.getGates(pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.gates = res.data.map((item: GateFull) => new GateFull(item.declarationId, item.declarationNumber,
        item.vehicleId, item.vehicleName, item.enterDate, item.exitDate, item.containerId, item.containerNumber, item.id));
      },
      error: (error: any) => { }
    });
  }


  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadGates(pageNumber, event.rows);
  }
  onAdd(){
    this.router.navigate(['/operation/gate-in']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/gate-in', id]);
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
        this.gateService.deleteGate(id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadGates();
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