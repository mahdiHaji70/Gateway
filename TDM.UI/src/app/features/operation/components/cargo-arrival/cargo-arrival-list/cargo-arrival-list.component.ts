import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { CargoArrivalService } from '../../../services/cargo-arrival.service';
import { CargoArrivalFull } from '../../../models/cargo-arrival-full.model';
import { arrivalDeclarationTypesDropdown } from '../../../../../shared/constants/arrival-declaration-types';

@Component({
  selector: 'app-cargo-arrival-list',
  templateUrl: './cargo-arrival-list.component.html',
  styleUrl: './cargo-arrival-list.component.scss'
})
export class CargoArrivalListComponent {
cargoArrivals: CargoArrivalFull[] = [];

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private cargoArrivalService: CargoArrivalService) {
  }

  ngOnInit() {
    this.loadCargoArrivals();
  }

  loadCargoArrivals() {
    this.cargoArrivalService.getCargoArrivals().subscribe({
      next: (res: any) => {
        this.cargoArrivals = res.data.map((item: any) => new CargoArrivalFull(item.declarationId, item.declarationNumber, item.vehicleId,
          item.vehicleName, item.transportDate, item.weight,item.packageCount, arrivalDeclarationTypesDropdown.find(
                    (type) => type.value === item.arrivalDeclarationType)!.name!, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/operation/cargo-arrival']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/cargo-arrival', id]);
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
        this.cargoArrivalService.deleteCargoArrival(id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadCargoArrivals();
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
