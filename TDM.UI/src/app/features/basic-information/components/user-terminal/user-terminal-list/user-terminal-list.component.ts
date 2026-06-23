import { Component } from '@angular/core';
import { UserTerminalFull } from '../../../models/user-terminal-full.model';
import { BasicInformationService } from '../../../services/basic-information.service';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-user-terminal-list',
  templateUrl: './user-terminal-list.component.html',
  styleUrl: './user-terminal-list.component.scss'
})
export class UserTerminalListComponent {
  userTerminals: UserTerminalFull[] = [];

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  }

  ngOnInit() {
    this.loadUserTerminals();
  }

  loadUserTerminals() {
    this.basicInformationService.getAll('UsersTerminal').subscribe({
      next: (res: any) => {
        this.userTerminals = res.data.items.map((item: any) => new UserTerminalFull(item.userNationalId, item.terminalId, item.terminalName, item.terminalCode, item.id));
      },
      error: (error: any) => { }
    });
  }

  onAdd() {
    this.router.navigate(['/user-terminal']);
  }

  onEdit(id: any) {
    this.router.navigate(['/user-terminal', id]);
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
        this.basicInformationService.removeBasicInformation('UsersTerminal', id).subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            this.loadUserTerminals();
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
