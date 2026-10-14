import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { showApiError } from '../../../../shared/services/api-error-handler.service';
import { BasicInformationService } from '../../services/basic-information.service';
import { Service } from '../../models/service.model';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrl: './service.component.scss'
})
export class ServiceComponent {
  id?: string;
  form = new FormGroup({
    code: new FormControl<string>(''),
    name: new FormControl<string>('')
  });

  constructor(
    private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Services', this.id).subscribe({
          next: (res: any) => this.form.patchValue(res.data),
          error: (error: any) => showApiError(this.messageService, error)
        });
      }
    });
  }

  onSubmit(): void {
    if (!this.form.valid) return;

    const service = new Service(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id);
    const action$ = this.id
      ? this.basicInformationService.putBasicInformation('Services', service)
      : this.basicInformationService.postBasicInformation('Services', service);

    action$.subscribe({
      next: () => {
        this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
        this.router.navigate(['/service-list']);
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }
}
