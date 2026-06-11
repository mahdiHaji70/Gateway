import { Component } from '@angular/core';
import { Place } from '../../../models/place.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { placeTypesDropdown } from '../../../../../shared/constants/place-types';
import { PlaceFull } from '../../../models/place-full.model';

@Component({
  selector: 'app-place-list',
  templateUrl: './place-list.component.html',
  styleUrl: './place-list.component.scss'
})
export class PlaceListComponent {
places: PlaceFull[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadPlaces();
  }

  loadPlaces(){
    this.basicInformationService.getAll('Place').subscribe({
      next: (res: any) => {
        this.places = res.data.map((item: any) => new PlaceFull(placeTypesDropdown.find(
          (type) => type.value === item.placeType)!.name!, item.placeName!,item.capacity, item.area, item.isOwner, item.contact.id, item.contact.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd(){
    this.router.navigate(['/place']);
  }

  onEdit(id: any) {
    this.router.navigate(['/place', id]);
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
        this.basicInformationService.removeBasicInformation('Place', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadPlaces();
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
