import { Component } from '@angular/core';
import { BasicInformationService } from '../../services/basic-information.service';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Terminal } from '../../models/terminal.model';
import { userInfo } from 'os';

@Component({
  selector: 'app-terminal',
  templateUrl: './terminal.component.html',
  styleUrl: './terminal.component.scss'
})
export class TerminalComponent {
  id?: any;

  form = new FormGroup({
    code: new FormControl<string>(''),
    name: new FormControl<string>(''),
    portCode: new FormControl<string>(''),
    username: new FormControl<string>(''),
    password: new FormControl<string>(''),
    isActive: new FormControl<boolean>(false)
  });
  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Terminals', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const terminal: Terminal = new Terminal(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.form.get('portCode')?.value!,
      this.form.get('username')?.value!,
      this.form.get('password')?.value!,
      this.form.get('isActive')?.value!,
      this.id
    );
    const terminalAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Terminals', terminal)
      : this.basicInformationService.postBasicInformation('Terminals', terminal);

    terminalAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/terminal-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
