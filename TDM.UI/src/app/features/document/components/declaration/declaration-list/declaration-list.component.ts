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

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private declarationService: DeclarationService) {
  }

  ngOnInit() {
    this.loadDeclarations();
  }

  loadDeclarations() {
    this.declarationService.getDeclarations().subscribe({
      next: (res: any) => {
        this.declarations = res.data.items.map((item: any) => 
          new DeclarationFull(item.id!, item.number, item.date, item.startDate, item.endDate, item.trafficId,
            item.trafficName, item.consigneeId, item.consigneeName, item.description, item.ipasDeclarationId,
            item.consigneeRepId, item.consigneeRepName));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/document/declaration']);
  }

  onEdit(id: any) {
    this.router.navigate(['/document/declaration', id]);
  }
}
