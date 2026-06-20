import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { CargoType } from '../../models/cargo-type.model';

@Component({
  selector: 'app-cargo-type',
  templateUrl: './cargo-type.component.html',
  styleUrl: './cargo-type.component.scss'
})
export class CargoTypeComponent {
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
        this.basicInformationService.getById('CargoTypes', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const cargoType: CargoType = new CargoType(
      this.form.get('name')?.value!,
      this.id
    );

    const cargoTypeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('CargoTypes', cargoType)
      : this.basicInformationService.postBasicInformation('CargoTypes', cargoType);

    cargoTypeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/cargo-type-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
