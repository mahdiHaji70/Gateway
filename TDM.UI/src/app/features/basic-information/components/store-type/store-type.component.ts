import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreType } from '../../models/store-type.model';

@Component({
  selector: 'app-store-type',
  templateUrl: './store-type.component.html',
  styleUrl: './store-type.component.scss'
})
export class StoreTypeComponent {
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
        this.basicInformationService.getById('StoreTypes', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const storeType: StoreType = new StoreType(
      this.form.get('name')?.value!,
      this.id
    );

    const storeTypeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('StoreTypes', storeType)
      : this.basicInformationService.postBasicInformation('StoreTypes', storeType);

    storeTypeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/store-type-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
