import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { OperationType } from '../../models/operation-type.model';

@Component({
  selector: 'app-operation-type',
  templateUrl: './operation-type.component.html',
  styleUrl: './operation-type.component.scss'
})
export class OperationTypeComponent {
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
        this.basicInformationService.getById('OperationType', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const operationType: OperationType = new OperationType(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const operationTypeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('OperationType', operationType)
      : this.basicInformationService.postBasicInformation('OperationType', operationType);

      operationTypeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/operation-type-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
