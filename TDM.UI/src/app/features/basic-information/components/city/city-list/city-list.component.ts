import { Component } from '@angular/core';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { City, CityDto } from '../../../models/city.model';

@Component({
  selector: 'app-city-list',
  templateUrl: './city-list.component.html',
  styleUrl: './city-list.component.scss'
})
export class CityListComponent {
  cities: CityDto[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadCities();
  }

  loadCities() {
    this.basicInformationService.getAll('City').subscribe({
      next: (res: any) => {
        this.cities = res.data.map((item: any) => new CityDto(item.code, item.name, item.countryCode, item.countryName, item.countryId, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/city']);
  }

  onEdit(id: any) {
    this.router.navigate(['/city', id]);
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
        this.basicInformationService.removeBasicInformation('City', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadCities();
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
