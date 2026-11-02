import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { CargoType } from '../../../models/cargo-type.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-cargo-type-list',
  templateUrl: './cargo-type-list.component.html',
  styleUrl: './cargo-type-list.component.scss'
})
export class CargoTypeListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  search = '';
  cargoTypes: CargoType[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadCargoTypes(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('CargoTypes', pageNumber, pageSize, this.search).subscribe({      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.cargoTypes = res.data.items.map((item: any) => new CargoType(item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadCargoTypes(pageNumber, event.rows);
  }
  onSearch() {    this.loadCargoTypes(1, this.pageSize);  }
  onAdd() {
    this.router.navigate(['/cargo-type']);
  }

  onEdit(id: any) {
    this.router.navigate(['/cargo-type', id]);
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
        this.basicInformationService.removeBasicInformation('CargoTypes', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadCargoTypes();
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