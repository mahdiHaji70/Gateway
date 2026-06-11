import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { GateService } from '../../services/gate.service';
import { ExitGate } from '../../models/gate-exit.model';

@Component({
  selector: 'app-gate-out',
  templateUrl: './gate-out.component.html',
  styleUrl: './gate-out.component.scss'
})
export class GateOutComponent {
  id?: string;

  form = new FormGroup({
    exitDate: new FormControl<Date | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private gateService: GateService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
  }

  ngOnInit() {    
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.gateService.getById(this.id!).subscribe((res: any) => {
          //this.form.patchValue(res.data);
          this.form.setValue({
            exitDate: res.data.exitDate == null ? null : new Date(res.data.exitDate),
          });
        });
      }

    });
  }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    const gate: ExitGate = new ExitGate(
      this.form.get('exitDate')?.value!,
      this.id
    );

    
      this.gateService.putExitGate(gate).subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/gate-out-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      });

  }
}
