import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { ContainerDto } from '../../../models/container.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-container-list',
  templateUrl: './container-list.component.html',
  styleUrl: './container-list.component.scss'
})
export class ContainerListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  search = '';
containers: ContainerDto[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadContainers(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('Containers', pageNumber, pageSize, this.search).subscribe({      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.containers = res.data.items.map((item: any) => new ContainerDto(item.no, item.containerTypeAndSizeId, item.containerTypeAndSizeCode,item.containerTypeAndSize, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadContainers(pageNumber, event.rows);
  }
  onSearch() {    this.loadContainers(1, this.pageSize);  }
  onAdd() {
    this.router.navigate(['/container']);
  }

  onEdit(id: any) {
    this.router.navigate(['/container', id]);
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
        this.basicInformationService.removeBasicInformation('Containers', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadContainers();
          },
          error: (error: any) => {
            showApiError(this.messageService, error);

          }
        });
      },
      reject: () => {
        this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      }
    });
  }
}