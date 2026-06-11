import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Truck } from '../../models/truck.model';

@Component({
  selector: 'app-truck',
  templateUrl: './truck.component.html',
  styleUrl: './truck.component.scss'
})
export class TruckComponent {
id?: any;

  form = new FormGroup({
    leftSide: new FormControl<string>('', [Validators.pattern(/^[0-9]{2}$/)]),
    charecter: new FormControl<string>('ع'),
    rightSide: new FormControl<string>('', [Validators.pattern(/^[0-9]{3}$/)]),
    serial: new FormControl<string>('', [Validators.pattern(/^[0-9]{2}$/)]),    
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
        this.basicInformationService.getById('Truck', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const truck: Truck = new Truck(
      this.form.get('leftSide')?.value!,
      this.form.get('charecter')?.value!,
      this.form.get('rightSide')?.value!,
      this.form.get('serial')?.value!,
      this.id
    );

    const truckAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Truck', truck)
      : this.basicInformationService.postBasicInformation('Truck', truck);

    truckAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/truck-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }

}
