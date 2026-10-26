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
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  services: Service[] = [];

  constructor(
    private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) { }
  loadServices(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('Services', pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.services = res.data.items.map((item: any) => new Service(item.code, item.name, item.id));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadServices(pageNumber, event.rows);
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
