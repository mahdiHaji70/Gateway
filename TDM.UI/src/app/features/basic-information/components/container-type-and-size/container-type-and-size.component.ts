import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { ContainerTypeAndSize } from '../../models/container-type-and-size.model';

@Component({
  selector: 'app-container-type-and-size',
  templateUrl: './container-type-and-size.component.html',
  styleUrl: './container-type-and-size.component.scss'
})
export class ContainerTypeAndSizeComponent {
  id?: any;

  form = new FormGroup({
    typeAndSizeCode: new FormControl<string>(''),
    typeAndSize: new FormControl<string>('')
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
        this.basicInformationService.getById('ContainerTypesAndSizes', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });
  }

    onSubmit(): void {
      if (!this.form.valid) {
        return;
      }
  
      const containerType: ContainerTypeAndSize = new ContainerTypeAndSize(
        this.form.get('typeAndSizeCode')?.value!,
        this.form.get('typeAndSize')?.value!,
        this.id
      );
  
      const containerTypeAction$ = this.id
        ? this.basicInformationService.putBasicInformation('ContainerTypesAndSizes', containerType)
        : this.basicInformationService.postBasicInformation('ContainerTypesAndSizes', containerType);
  
        containerTypeAction$
        .subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
            this.router.navigate(['/container-type-and-size-list'])
          },
          error: (error: any) => {
            this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
          }
        }
        );
    }
}
