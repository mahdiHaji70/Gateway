import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DeclarationService } from '../../../services/declaration.service';
import { DeclarationFull } from '../../../models/declaration-full.model';

@Component({
  selector: 'app-declaration-list',
  templateUrl: './declaration-list.component.html',
  styleUrl: './declaration-list.component.scss'
})
export class DeclarationListComponent {
  declarations: DeclarationFull[] = [];
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private declarationService: DeclarationService) {
  }

  ngOnInit() {
  }

  loadDeclarations(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;

    this.declarationService.getDeclarations(pageNumber, pageSize).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.declarations = res.data.items.map((item: any) => 
          new DeclarationFull(item.id!, item.number, item.date, item.startDate, item.endDate, item.trafficId,
            item.trafficName, item.consigneeId, item.consigneeName, item.description, item.ipasDeclarationNo,
            item.consigneeRepId, item.consigneeRepName));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadDeclarations(pageNumber, event.rows);
  }

  onAdd() {
    this.router.navigate(['/document/declaration']);
  }

  onEdit(id: any) {
    this.router.navigate(['/document/declaration', id]);
  }
}
