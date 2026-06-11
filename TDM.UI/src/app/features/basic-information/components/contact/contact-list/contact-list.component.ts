import { Component } from '@angular/core';
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
  contacts: Contact[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadContacts();
  }

  loadContacts(){
    this.basicInformationService.getAll('companies').subscribe({
      next: (res: any) => {
        this.contacts = res.data.items.map((item: Contact) => new ContactList(contactTypesDropdown.find(
          (type) => type.value === item.companyType
        )!.name!, item.name!, item. nationalId!, item.registerDate!,
          item.address!, item.postCode!, item.mobile!, item.economicCode!, item.registerNumber!,
           item.registerPlace!, item.phone!, item.id));
      },
      error: (error: any) => { }
    });
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
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptIcon: "none",
      rejectIcon: "none",

      accept: () => {
        this.basicInformationService.removeBasicInformation('companies', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadContacts();
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
