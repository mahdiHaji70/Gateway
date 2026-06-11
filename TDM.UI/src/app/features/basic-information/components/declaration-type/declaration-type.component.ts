import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { DeclarationType } from '../../models/declaration-type.model';

@Component({
  selector: 'app-declaration-type',
  templateUrl: './declaration-type.component.html',
  styleUrl: './declaration-type.component.scss'
})
export class DeclarationTypeComponent {
  id?: any;

  form = new FormGroup({
    code: new FormControl<string>(''),
    name: new FormControl<string>('')
  });

  constructor(private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('DeclarationType', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const declarationType: DeclarationType = new DeclarationType(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const declarationTypeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('DeclarationType', declarationType)
      : this.basicInformationService.postBasicInformation('DeclarationType', declarationType);

      declarationTypeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/declaration-type-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
