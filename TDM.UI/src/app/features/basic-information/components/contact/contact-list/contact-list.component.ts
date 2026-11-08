import { Component, inject } from '@angular/core';

import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { TranslateService } from '@ngx-translate/core';
import { Contact } from '../../../models/contact.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ContactList } from '../../../models/contact-list.model';
import { contactTypesDropdown } from '../../../../../shared/constants/contact-types';
@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.scss'
})
export class ContactListComponent {
  private readonly translate = inject(TranslateService);
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  search = '';

  contacts: Contact[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadContacts(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('companies', pageNumber, pageSize, this.search).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.contacts = res.data.items.map((item: Contact) => new ContactList(contactTypesDropdown.find(
          (type) => type.value === item.companyType
        )!.name!, item.name!, item. nationalId!, new Date(item.registerDate!).toDateString(),
          item.address!, item.postCode!, item.mobile!, item.economicCode!, item.registerNumber!,
           item.registerPlace!, item.phone!, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadContacts(pageNumber, event.rows);
  }

  onSearch() {
    this.loadContacts(1, this.pageSize);
  }

  onAdd(){
    this.router.navigate(['/contact']);
  }

  onEdit(id: any) {
    this.router.navigate(['/contact', id]);
  }

  onDelete(event: any, id: any) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: this.translate.instant('common.deleteConfirm') as string,
      header: this.translate.instant('common.deleteConfirmation') as string,
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptLabel: this.translate.instant('common.yes') as string,
      rejectLabel: this.translate.instant('common.no') as string,
      acceptIcon: "none",
      rejectIcon: "none",

      accept: () => {
        this.basicInformationService.removeBasicInformation('companies', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: this.translate.instant('common.confirmed') as string, detail: this.translate.instant('common.recordDeleted') as string });
            this.loadContacts();
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
