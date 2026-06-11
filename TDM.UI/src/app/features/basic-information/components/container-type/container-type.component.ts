import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { ContainerType } from '../../models/container-type.model';

@Component({
  selector: 'app-container-type',
  templateUrl: './container-type.component.html',
  styleUrl: './container-type.component.scss'
})
export class ContainerTypeComponent {
  id?: any;

  form = new FormGroup({
    code: new FormControl<string>(''),
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
        this.basicInformationService.getById('ContainerType', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const containerType: ContainerType = new ContainerType(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const containerTypeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('ContainerType', containerType)
      : this.basicInformationService.postBasicInformation('ContainerType', containerType);

      containerTypeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/container-type-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
