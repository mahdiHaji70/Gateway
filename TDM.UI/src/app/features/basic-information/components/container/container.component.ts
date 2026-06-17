import { Component } from '@angular/core';
import { ContainerType } from '../../models/container-type.model';
import { ContainerSize } from '../../models/container-size.model';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Container } from '../../models/container.model';
import { ContainerTypeAndSize } from '../../models/container-type-and-size.model';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrl: './container.component.scss'
})
export class ContainerComponent {
  id?: any;
  containerTypesAndSizes: ContainerTypeAndSize[] = [];

  form = new FormGroup({
    containerNumber: new FormControl<string>(''),
    containerTypeAndSize: new FormControl<ContainerTypeAndSize | undefined>(undefined),
  });
  /**
   *
   */
  constructor(
    private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.loadContainerTypesAndSizes();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Containers', this.id).subscribe((res: any) => {
          //this.form.patchValue(res.data);
          this.form.setValue({
            containerNumber: res.data.no,
            containerTypeAndSize: new ContainerTypeAndSize(res.data.containerTypeAndSizeCode, res.data.containerTypeAndSize, res.data.containerTypeAndSizeId)
          });
        });
      }

    });

  }

  loadContainerTypesAndSizes() {
    this.basicInformationService.getAll('ContainerTypesAndSizes').subscribe({
      next: (res: any) => {
        this.containerTypesAndSizes = res.data.items.map((item: any) => new ContainerTypeAndSize(item.typeAndSizeCode, item.typeAndSize, item.id));
      },
      error: (error: any) => { }
    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const container: Container = new Container(
      this.form.get('containerNumber')?.value!,
      this.form.get('containerTypeAndSize')?.value!.id!,
      this.id
    );

    const containerAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Containers', container)
      : this.basicInformationService.postBasicInformation('Containers', container);
debugger
    containerAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/container-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
