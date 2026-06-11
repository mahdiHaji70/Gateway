import { Component } from '@angular/core';
import { BasicInformationService } from '../../services/basic-information.service';
import { Traffic } from '../../models/traffic.model';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-traffic',
  templateUrl: './traffic.component.html',
  styleUrl: './traffic.component.scss'
})
export class TrafficComponent {
  id?: any;

  form = new FormGroup({
    code: new FormControl<string>(''),
    name: new FormControl<string>('')
  });
  /**
   *
   */
  constructor(
    private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Traffic', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const traffic: Traffic = new Traffic(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const trafficAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Traffic', traffic)
      : this.basicInformationService.postBasicInformation('Traffic', traffic);

    trafficAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/traffic-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }

}
