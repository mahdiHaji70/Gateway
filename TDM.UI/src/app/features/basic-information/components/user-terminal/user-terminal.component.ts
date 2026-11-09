import { Component } from '@angular/core';

import { showApiError } from '../../../../shared/services/api-error-handler.service';
import { User } from '../../models/user.model';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { UserTerminal } from '../../models/user-terminal.model';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';

@Component({
  selector: 'app-user-terminal',
  templateUrl: './user-terminal.component.html',
  styleUrl: './user-terminal.component.scss'
})
export class UserTerminalComponent {
  id?: any;
  users: User[] = [];
  terminals: DropdownOption[] = [];

  form = new FormGroup({
    user: new FormControl<User | undefined>(undefined),
    terminal: new FormControl<DropdownOption | undefined>(undefined)
  });
  /**
   *
   */
  constructor(
    private basicInformationService: BasicInformationService,
    private userService: UserService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('UsersTerminal', this.id).subscribe((res: any) => {
          const terminal = new DropdownOption(res.data.terminalId, res.data.terminalName + `-  ${res.data.terminalCode}`);
          this.userService.getAllUsers(res.data.userNationalId).subscribe((usersRes: any) => {
            const user = (usersRes.mappedUsers || [])
              .map((item: any) => new User(item.name, item.nationalId, item.id))
              .find((item: User) => item.nationalId === res.data.userNationalId);

            this.form.setValue({ user, terminal });
            this.users = user ? [user] : [];
            this.terminals = [terminal];
          });
        });
      } else {
        this.loadUsers();
        this.loadTerminals();
      }
    });
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe({
      next: (res: any) => {
        this.users = res.mappedUsers.map((item: any) => new User(item.name, item.nationalId, item.id));
      },
      error: (error: any) => { }
    });
  }

  onUserFilterChanged(search: string) {
    this.userService.getAllUsers(search).subscribe({
      next: (res: any) => {
        this.users = res.mappedUsers.map((item: any) => new User(item.name, item.nationalId, item.id));
      },
      error: (error: any) => { }
    });
  }

  loadTerminals() {
    this.basicInformationService.getAll('Terminals').subscribe({
      next: (res: any) => {
        this.terminals = res.data.items.map((item: any) => new DropdownOption(item.id, item.name + `-  ${item.code}`,));
      },
      error: (error: any) => { }
    });
  }

  onTerminalFilterChanged(search: string) {
    this.basicInformationService.getLookup('Terminals', search).subscribe({
      next: (res: any) => {
        this.terminals = res.data.items.map((item: any) => new DropdownOption(item.id, item.name + `-  ${item.code}`,));
      },
      error: (error: any) => { }
    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const terminal: UserTerminal = new UserTerminal(
      this.form.get('user')?.value!.nationalId!,
      this.form.get('terminal')?.value!.id!,
      this.id
    );

    const cityAction$ = this.id
      ? this.basicInformationService.putBasicInformation('UsersTerminal', terminal)
      : this.basicInformationService.postBasicInformation('UsersTerminal', terminal);

    cityAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/user-terminal-list'])
        },
        error: (failRes: any) => {
          showApiError(this.messageService, failRes);
        }
      }
      );
  }
}
