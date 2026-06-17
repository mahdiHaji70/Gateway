import { Component } from '@angular/core';
import { ContainerTypeAndSize } from '../../../models/container-type-and-size.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-container-type-and-size-list',
  templateUrl: './container-type-and-size-list.component.html',
  styleUrl: './container-type-and-size-list.component.scss'
})
export class ContainerTypeAndSizeListComponent {
  containerTypes: ContainerTypeAndSize[] = [];

    /**
   *
   */
    constructor(private basicInformationService: BasicInformationService,
      private router: Router,
      private messageService: MessageService,
      private confirmationService: ConfirmationService) {
    }
  
    ngOnInit() {
      this.loadContainerTypesAndSizes();
    }
  
    loadContainerTypesAndSizes(){
      this.basicInformationService.getAll('ContainerTypesAndSizes').subscribe({
        next: (res: any) => {
          this.containerTypes = res.data.items.map((item: any) => new ContainerTypeAndSize(item.typeAndSizeCode, item.typeAndSize, item.id));
        },
        error: (error: any) => { }
      });
    }

    onAdd(){
      this.router.navigate(['/container-type-and-size']);
    }
  
    onEdit(id: any) {
      this.router.navigate(['/container-type-and-size', id]);
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
          this.basicInformationService.removeBasicInformation('ContainerTypesAndSizes', id).subscribe({
            next: (res: any) => {
              this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
              this.loadContainerTypesAndSizes();
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
