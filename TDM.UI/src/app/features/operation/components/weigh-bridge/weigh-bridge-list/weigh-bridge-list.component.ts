import { Component } from '@angular/core';
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

  ngOnInit() {
    this.loadWeighBridges();
  }

  loadWeighBridges() {
    this.weighBridgeService.getWeighBridges().subscribe({
      next: (res: any) => {
        this.weighBridges = res.data.map((item: WeightBridgeFull) => new WeightBridgeFull(item.declarationId, item.declarationNumber, item.gateEventId,
          item.vehicleId, item.vehicleName, item.grossWeight, item.tareWeight, item.startDate, item.endDate, item.id));
      },
      error: (error: any) => { }
    });
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
