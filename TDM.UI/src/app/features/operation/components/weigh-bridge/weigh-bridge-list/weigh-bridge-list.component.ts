import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { WeightBridgeFull } from '../../../models/weight-bridge-full.model';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { WeighBridgeService } from '../../../services/weigh-bridge.service';

@Component({
  selector: 'app-weigh-bridge-list',
  templateUrl: './weigh-bridge-list.component.html',
  styleUrl: './weigh-bridge-list.component.scss'
})
export class WeighBridgeListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  weighBridges: WeightBridgeFull[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private weighBridgeService: WeighBridgeService) {
  }
  loadWeighBridges(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.weighBridgeService.getWeighBridges(pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.weighBridges = res.data.map((item: WeightBridgeFull) => new WeightBridgeFull(item.declarationId, item.declarationNumber, item.gateEventId,
          item.vehicleId, item.vehicleName, item.grossWeight, item.tareWeight, item.startDate, item.endDate, item.id));
      },
      error: (error: any) => { }
    });
  }


  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadWeighBridges(pageNumber, event.rows);
  }
  onAdd() {
    this.router.navigate(['/operation/weigh-bridge']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/weigh-bridge', id]);
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
        this.weighBridgeService.deleteWeightBridge(id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadWeighBridges();
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