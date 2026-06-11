import { Component } from '@angular/core';
import { PlaceType } from '../../../models/place-type.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-place-type-list',
  templateUrl: './place-type-list.component.html',
  styleUrl: './place-type-list.component.scss'
})
export class PlaceTypeListComponent {
placeTypes: PlaceType[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadPlaceTypes();
  }

  loadPlaceTypes(){
    this.basicInformationService.getAll('PlaceType').subscribe({
      next: (res: any) => {
        this.placeTypes = res.data.map((item: any) => new PlaceType(item.code, item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd(){
    this.router.navigate(['/place-type']);
  }

  onEdit(id: any) {
    this.router.navigate(['/place-type', id]);
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
        this.basicInformationService.removeBasicInformation('PlaceType', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadPlaceTypes();
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
