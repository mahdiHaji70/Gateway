import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { ContainerSize } from '../../../models/container-size.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-container-size-list',
  templateUrl: './container-size-list.component.html',
  styleUrl: './container-size-list.component.scss'
})
export class ContainerSizeListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  containerSizes: ContainerSize[] = [];

  /**
 *
 */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadContainerSizes(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('ContainerSize', pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.containerSizes = res.data.map((item: any) => new ContainerSize(item.code, item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadContainerSizes(pageNumber, event.rows);
  }

  onAdd(){
    this.router.navigate(['/container-size']);
  }

  onEdit(id: any) {
    this.router.navigate(['/container-size', id]);
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
        this.basicInformationService.removeBasicInformation('ContainerSize', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadContainerSizes();
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