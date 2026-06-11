import { Component } from '@angular/core';
import { BasicInformationService } from '../../services/basic-information.service';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Terminal } from '../../models/terminal.model';

@Component({
  selector: 'app-terminal',
  templateUrl: './terminal.component.html',
  styleUrl: './terminal.component.scss'
})
export class TerminalComponent {
  id?: any;

  form = new FormGroup({
    name: new FormControl<string>('')
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
        this.basicInformationService.getById('Terminal', this.id).subscribe((res: any) => {
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
      this.form.get('name')?.value!,
      this.id
    );

    const terminalAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Terminal', terminal)
      : this.basicInformationService.postBasicInformation('Terminal', terminal);

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
