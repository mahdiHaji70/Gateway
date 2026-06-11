import { Component } from '@angular/core';
import { OperationPlanningFull } from '../../../models/operation-planning-full.model';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { OperationPlanningService } from '../../../services/operation-planning.service';

@Component({
  selector: 'app-operation-planning-list',
  templateUrl: './operation-planning-list.component.html',
  styleUrl: './operation-planning-list.component.scss'
})
export class OperationPlanningListComponent {
discharges: OperationPlanningFull[] = [];

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private operationPlanningService: OperationPlanningService) {
  }

  ngOnInit() {
    this.loadDischarges();
  }

  loadDischarges() {
    this.operationPlanningService.getOperationPlannings().subscribe({
      next: (res: any) => {
        this.discharges = res.data.map((item: OperationPlanningFull) => new OperationPlanningFull(item.declarationId, item.declarationNumber, item.staffId, item.staffName, item.equipmentId
          , item.equipmentName, item.equipmentTypeId, item.equipmentTypeName, item.shiftId, item.shiftName, item.placeId, item.placeName, item.date, item.id
        ));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/operation/operation-planning']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/operation-planning', id]);
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
        this.operationPlanningService.deleteOperationPlanning(id).subscribe({
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
