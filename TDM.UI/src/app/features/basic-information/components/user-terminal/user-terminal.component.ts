import { Component } from '@angular/core';
import { User } from '../../models/user.model';
import { Terminal } from '../../models/terminal.model';
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
  terminals: Terminal[] = [];

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
    this.loadUsers();
    this.loadTerminals();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('UsersTerminal', this.id).subscribe((res: any) => {
          //this.form.patchValue(res.data);
          this.form.setValue({
            user: this.users.filter(x => x.nationalId === res.data.userNationalId)[0],
            terminal: new DropdownOption(res.data.terminalId, res.data.terminalName + `-  ${res.data.terminalCode}`),
          });
        });
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

  loadTerminals() {
    this.basicInformationService.getAll('Terminals').subscribe({
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
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error.Message });
        }
      }
      );
  }
}
