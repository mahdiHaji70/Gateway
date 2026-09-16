import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { VesselDischargeService } from '../../../services/vessel-discharge.service';
import { VesselDischargeFull } from '../../../models/vessel-discharge-full.model';

@Component({
  selector: 'app-vessel-discharge-list',
  templateUrl: './vessel-discharge-list.component.html',
  styleUrl: './vessel-discharge-list.component.scss'
})
export class VesselDischargeListComponent {
  vesselDischarges: VesselDischargeFull[] = [];

  constructor(
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private vesselDischargeService: VesselDischargeService) { }

  ngOnInit() {
    this.loadVesselDischarges();
  }

  loadVesselDischarges() {
    this.vesselDischargeService.getVesselDischarges().subscribe({
      next: (res: any) => {
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
      error: (error: any) => this.showApiError(error)
    });
  }

  onAdd() {
    this.router.navigate(['/operation/vessel-discharge']);
  }

  onEdit(id: string) {
    this.router.navigate(['/operation/vessel-discharge', id]);
  }

  onDelete(event: any, id: string) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      accept: () => {
        this.vesselDischargeService.deleteDischarge(id).subscribe({
          next: () => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadVesselDischarges();
          },
          error: (error: any) => this.showApiError(error)
        });
      }
    });
  }

  private showApiError(error: any) {
    this.messageService.add({
      severity: 'error',
      summary: error?.error?.Message || 'Operation failed',
      detail: error?.message || ''
    });
  }

}
