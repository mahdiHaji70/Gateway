import { Component } from '@angular/core';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { GateService } from '../../../services/gate.service';
import { GateFull } from '../../../models/gate-full.model';

@Component({
  selector: 'app-gate-out-list',
  templateUrl: './gate-out-list.component.html',
  styleUrl: './gate-out-list.component.scss'
})
export class GateOutListComponent {
gates: GateFull[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
  private gateService: GateService) {
  }

  ngOnInit() {
    this.loadGates();
  }

  loadGates(){
    this.gateService.getGates().subscribe({
      next: (res: any) => {
        this.gates = res.data.map((item: GateFull) => new GateFull(item.declarationId, item.declarationNumber,
        item.vehicleId, item.vehicleName, item.enterDate, item.exitDate, item.containerId, item.containerNumber, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd(){
    this.router.navigate(['/operation/gate-out']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/gate-out', id]);
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
