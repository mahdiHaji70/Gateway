import { Component, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
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
  private readonly translate = inject(TranslateService);
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  search = '';

  services: Service[] = [];

  constructor(
    private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) { }
  loadServices(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('Services', pageNumber, pageSize, this.search).subscribe({
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

  onSearch() {
    this.loadServices(1, this.pageSize);
  }

  onAdd() { this.router.navigate(['/service']); }

  onEdit(id: string) { this.router.navigate(['/service', id]); }

  onDelete(event: any, id: string) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: this.translate.instant('common.deleteConfirm') as string,
      header: this.translate.instant('common.deleteConfirmation') as string,
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: 'p-button-danger p-button-text',
      rejectButtonStyleClass: 'p-button-text p-button-text',
      acceptIcon: 'none',
      rejectIcon: 'none',
      accept: () => {
        this.basicInformationService.removeBasicInformation('Services', id).subscribe({
          next: () => {
            this.messageService.add({ severity: 'info', summary: this.translate.instant('common.confirmed') as string, detail: this.translate.instant('common.recordDeleted') as string });
            this.loadServices();
          },
          error: (error: any) => showApiError(this.messageService, error)
        });
      },
      reject: () => this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' })
    });
  }
}
