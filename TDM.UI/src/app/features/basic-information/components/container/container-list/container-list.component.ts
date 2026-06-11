import { Component } from '@angular/core';
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
containers: ContainerDto[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadContainers();
  }

  loadContainers() {
    this.basicInformationService.getAll('Container').subscribe({
      next: (res: any) => {
        this.containers = res.data.map((item: any) => new ContainerDto(item.containerNumber, item.containerTypeId, item.containerTypeCode,item.containerTypeName, item.containerSizeId,
          item.containerSizeCode, item.containerSizeName,item.weight, item.id));
      },
      error: (error: any) => { }
    });
  }

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
        this.basicInformationService.removeBasicInformation('Container', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadContainers();
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
