import { Component } from '@angular/core';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Commodity } from '../../../models/commodity.model';

@Component({
  selector: 'app-commodity-list',
  templateUrl: './commodity-list.component.html',
  styleUrl: './commodity-list.component.scss'
})
export class CommodityListComponent {
  commodities: Commodity[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadCommodities();
  }

  loadCommodities(){
    this.basicInformationService.getAll('commodities').subscribe({
      next: (res: any) => {
        this.commodities = res.data.items.map((item: any) => new Commodity(item.name, item.hsCode, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd(){
    this.router.navigate(['/commodity']);
  }

  onEdit(id: any) {
    this.router.navigate(['/commodity', id]);
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
        this.basicInformationService.removeBasicInformation('commodities', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadCommodities();
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
