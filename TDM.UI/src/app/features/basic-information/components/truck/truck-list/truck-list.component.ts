import { Component } from '@angular/core';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Truck } from '../../../models/truck.model';

@Component({
  selector: 'app-truck-list',
  templateUrl: './truck-list.component.html',
  styleUrl: './truck-list.component.scss'
})
export class TruckListComponent {
trucks: Truck[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadTrucks();
  }

  loadTrucks() {
    this.basicInformationService.getAll('Truck').subscribe({
      next: (res: any) => {
        this.trucks = res.data.map((item: any) => new Truck(item.leftSide, item.charecter, item.rightSide, item.serial, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/truck']);
  }

  onEdit(id: any) {
    this.router.navigate(['/truck', id]);
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
        this.basicInformationService.removeBasicInformation('Truck', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadTrucks();
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
