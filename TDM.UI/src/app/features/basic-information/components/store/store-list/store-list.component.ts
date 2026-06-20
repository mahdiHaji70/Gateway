import { Component } from '@angular/core';
import { StoreFull } from '../../../models/store-full.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { storeTypesDropdown } from '../../../../../shared/constants/store-types';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrl: './store-list.component.scss'
})
export class StoreListComponent {
stores: StoreFull[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadStores();
  }

    loadStores(){
      this.basicInformationService.getAll('Stores').subscribe({
        next: (res: any) => {
          this.stores = res.data.items.map((item: any) => new StoreFull(item.storeTypeName, item.name!, item.id));
        },
        error: (error: any) => { }
      });
    }
  
    onAdd(){
      this.router.navigate(['/store']);
    }
  
    onEdit(id: any) {
      this.router.navigate(['/store', id]);
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
          this.basicInformationService.removeBasicInformation('Stores', id).subscribe({
            next: (res: any) => {
              this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
              this.loadStores();
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
