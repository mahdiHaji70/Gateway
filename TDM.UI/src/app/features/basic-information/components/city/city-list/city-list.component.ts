import { Component, inject } from '@angular/core';

import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { TranslateService } from '@ngx-translate/core';
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
  private readonly translate = inject(TranslateService);
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  search = '';
  cities: CityDto[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadCities(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('cities', pageNumber, pageSize, this.search).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.cities = res.data.items.map((item: any) => new CityDto(item.code, item.name, item.countryCode, item.countryName, item.countryId, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadCities(pageNumber, event.rows);
  }

  onSearch() {
    this.loadCities(1, this.pageSize);
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
        this.basicInformationService.removeBasicInformation('cities', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: this.translate.instant('common.confirmed') as string, detail: this.translate.instant('common.recordDeleted') as string });
            this.loadCities();
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
