import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Vessel } from '../../models/vessel.model';

@Component({
  selector: 'app-vessel',
  templateUrl: './vessel.component.html',
  styleUrl: './vessel.component.scss'
})
export class VesselComponent {
id?: any;

  form = new FormGroup({
    name: new FormControl<string>(''),
    imoNumber: new FormControl<string>(''),
    storeCount: new FormControl<number | undefined>(undefined),
    grt: new FormControl<number | undefined>(undefined)
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
        this.basicInformationService.getById('Vessel', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const vessel: Vessel = new Vessel(
      this.form.get('name')?.value!,
      this.form.get('imoNumber')?.value!,
      this.form.get('storeCount')?.value!,
      this.form.get('grt')?.value!,
      this.id
    );

    const vesselAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Vessel', vessel)
      : this.basicInformationService.postBasicInformation('Vessel', vessel);

    vesselAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/vessel-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
