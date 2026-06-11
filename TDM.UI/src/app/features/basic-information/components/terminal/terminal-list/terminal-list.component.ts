import { Component } from '@angular/core';
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
  terminals: Terminal[] = [];
  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {    
  }

  ngOnInit() {
    this.loadTerminals();
  }

  loadTerminals(){
    this.basicInformationService.getAll('Terminal').subscribe({
      next: (res: any) => {
        this.terminals = res.data.map((item: any) => new Terminal(item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd(){
    this.router.navigate(['/terminal']);
  }

  onEdit(id: any) {
    this.router.navigate(['/terminal', id]);
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
        this.basicInformationService.removeBasicInformation('Terminal', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadTerminals();
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
