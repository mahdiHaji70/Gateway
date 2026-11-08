import { Component, inject } from '@angular/core';

import { showApiError } from '../../../../../shared/services/api-error-handler.service';
import { TranslateService } from '@ngx-translate/core';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Terminal } from '../../../models/terminal.model';

@Component({
  selector: 'app-terminal-list',
  templateUrl: './terminal-list.component.html',
  styleUrl: './terminal-list.component.scss'
})
export class TerminalListComponent {
  private readonly translate = inject(TranslateService);
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  search = '';
  terminals: Terminal[] = [];
  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }
  loadTerminals(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;
    this.basicInformationService.getAll('Terminals', pageNumber, pageSize, this.search).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.terminals = res.data.items.map((item: any) => new Terminal(item.code, item.name, item.portCode, item.username, item.password, item.isActive, item.id));
      },
      error: (error: any) => { }
    });
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadTerminals(pageNumber, event.rows);
  }

  onSearch() {
    this.loadTerminals(1, this.pageSize);
  }

  onAdd() {
    this.router.navigate(['/terminal']);
  }

  onEdit(id: any) {
    this.router.navigate(['/terminal', id]);
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
        this.basicInformationService.removeBasicInformation('Terminals', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: this.translate.instant('common.confirmed') as string, detail: this.translate.instant('common.recordDeleted') as string });
            this.loadTerminals();
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
