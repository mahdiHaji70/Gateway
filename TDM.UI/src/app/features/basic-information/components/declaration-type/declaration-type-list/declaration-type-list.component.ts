import { Component } from '@angular/core';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DeclarationType } from '../../../models/declaration-type.model';

@Component({
  selector: 'app-declaration-type-list',
  templateUrl: './declaration-type-list.component.html',
  styleUrl: './declaration-type-list.component.scss'
})
export class DeclarationTypeListComponent {
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  declarationTypes: DeclarationType[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadDeclarationTypes(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('DeclarationType', pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.declarationTypes = res.data.map((item: any) => new DeclarationType(item.code, item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadDeclarationTypes(pageNumber, event.rows);
  }

  onAdd(){
    this.router.navigate(['/declaration-type']);
  }

  onEdit(id: any) {
    this.router.navigate(['/declaration-type', id]);
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
        this.basicInformationService.removeBasicInformation('', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadDeclarationTypes();
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