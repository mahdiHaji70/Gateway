import { Component } from '@angular/core';
import { Traffic } from '../../../models/traffic.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-traffic-list',
  templateUrl: './traffic-list.component.html',
  styleUrl: './traffic-list.component.scss'
})
export class TrafficListComponent {
  traffics: Traffic[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadTraffics();
  }

  loadTraffics(){
    this.basicInformationService.getAll('Traffic').subscribe({
      next: (res: any) => {
        this.traffics = res.data.map((item: any) => new Traffic(item.code, item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd(){
    this.router.navigate(['/traffic']);
  }

  onEdit(id: any) {
    this.router.navigate(['/traffic', id]);
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
        this.basicInformationService.removeBasicInformation('Traffic', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadTraffics();
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

