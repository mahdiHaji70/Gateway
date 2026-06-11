import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { PlaceType } from '../../models/place-type.model';

@Component({
  selector: 'app-place-type',
  templateUrl: './place-type.component.html',
  styleUrl: './place-type.component.scss'
})
export class PlaceTypeComponent {
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
        this.basicInformationService.getById('PlaceType', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const placeType: PlaceType = new PlaceType(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const placeTypeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('PlaceType', placeType)
      : this.basicInformationService.postBasicInformation('PlaceType', placeType);

    placeTypeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/place-type-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
