import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { ContainerSize } from '../../models/container-size.model';

@Component({
  selector: 'app-container-size',
  templateUrl: './container-size.component.html',
  styleUrl: './container-size.component.scss'
})
export class ContainerSizeComponent {
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
        this.basicInformationService.getById('ContainerSize', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const containerSize: ContainerSize = new ContainerSize(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const containerSizeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('ContainerSize', containerSize)
      : this.basicInformationService.postBasicInformation('ContainerSize', containerSize);

      containerSizeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/container-size-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
