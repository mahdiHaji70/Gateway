import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { Wagon } from '../../../models/wagon.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-wagon-list',
  templateUrl: './wagon-list.component.html',
  styleUrl: './wagon-list.component.scss'
})
export class WagonListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  wagons: Wagon[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadWagons(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('Wagon', pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.wagons = res.data.map((item: any) => new Wagon(item.code, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadWagons(pageNumber, event.rows);
  }

  onAdd() {
    this.router.navigate(['/wagon']);
  }

  onEdit(id: any) {
    this.router.navigate(['/wagon', id]);
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
        this.basicInformationService.removeBasicInformation('Wagon', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadWagons();
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