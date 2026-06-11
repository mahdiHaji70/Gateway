import { Component } from '@angular/core';
import { Vessel } from '../../../models/vessel.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vessel-list',
  templateUrl: './vessel-list.component.html',
  styleUrl: './vessel-list.component.scss'
})
export class VesselListComponent {
  vessels: Vessel[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadVessels();
  }

  loadVessels() {
    this.basicInformationService.getAll('Vessel').subscribe({
      next: (res: any) => {
        this.vessels = res.data.map((item: any) => new Vessel(item.name, item.imoNumber, item.storeCount, item.grt, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/vessel']);
  }

  onEdit(id: any) {
    this.router.navigate(['/vessel', id]);
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
        this.basicInformationService.removeBasicInformation('Vessel', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadVessels();
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
