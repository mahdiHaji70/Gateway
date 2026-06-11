import { Component } from '@angular/core';
import { ContainerType } from '../../models/container-type.model';
import { ContainerSize } from '../../models/container-size.model';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Container } from '../../models/container.model';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrl: './container.component.scss'
})
export class ContainerComponent {
  id?: any;
  containerTypes: ContainerType[] = [];
  containerSizes: ContainerSize[] = [];

  form = new FormGroup({
    containerNumber: new FormControl<string>(''),
    containerType: new FormControl<ContainerType | undefined>(undefined),
    containerSize: new FormControl<ContainerSize | undefined>(undefined),
    weight: new FormControl<number | undefined>(undefined),
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
    this.loadContainerTypes();
    this.loadContainerSizes();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Container', this.id).subscribe((res: any) => {
          //this.form.patchValue(res.data);
          this.form.setValue({
            containerNumber: res.data.containerNumber,
            containerType: new ContainerType(res.data.containerTypeCode, res.data.containerTypeName, res.data.containerTypeId),
            containerSize: new ContainerSize(res.data.containerSizeCode, res.data.containerSizeName, res.data.containerSizeId),
            weight: res.data.weight,
          });
        });
      }

    });

  }

  loadContainerTypes() {
    this.basicInformationService.getAll('ContainerType').subscribe({
      next: (res: any) => {
        this.containerTypes = res.data.map((item: any) => new ContainerType(item.code, item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  loadContainerSizes() {
    this.basicInformationService.getAll('ContainerSize').subscribe({
      next: (res: any) => {
        this.containerSizes = res.data.map((item: any) => new ContainerSize(item.code, item.name, item.id));
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
      this.form.get('containerType')?.value!.id!,
      this.form.get('containerSize')?.value!.id!,
      this.form.get('weight')?.value!,
      this.id
    );

    const containerAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Container', container)
      : this.basicInformationService.postBasicInformation('Container', container);

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
