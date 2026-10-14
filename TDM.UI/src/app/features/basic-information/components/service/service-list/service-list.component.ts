import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { Service } from '../../../models/service.model';
import { BasicInformationService } from '../../../services/basic-information.service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrl: './service-list.component.scss'
})
export class ServiceListComponent {
  services: Service[] = [];

  constructor(
    private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.loadServices();
  }

  loadServices() {
    this.basicInformationService.getAll('Services').subscribe({
      next: (res: any) => {
        this.services = res.data.items.map((item: any) => new Service(item.code, item.name, item.id));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  onAdd() { this.router.navigate(['/service']); }

  onEdit(id: string) { this.router.navigate(['/service', id]); }

  onDelete(event: any, id: string) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      accept: () => {
        this.basicInformationService.removeBasicInformation('Services', id).subscribe({
          next: () => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadServices();
          },
          error: (error: any) => showApiError(this.messageService, error)
        });
      },
      reject: () => this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' })
    });
  }
}
