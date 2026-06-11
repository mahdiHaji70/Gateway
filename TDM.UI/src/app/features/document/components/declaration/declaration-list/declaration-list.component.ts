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
        this.declarations = res.data.map((item: DeclarationFull) => new DeclarationFull(item.declarationTypeId, item.declarationTypeName, item.number,
          item.contactId, item.contactName, item.bookingNumber, item.terminalId, item.terminalName, item.originCityId,
          item.originCityName, item.destinationCityId, item.destinationCityName, item.requestStatus, item.serial, item.contactAgentId,
          item.contactAgentName, item.carrierContactId, item.carrierContactName, item.id));
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
