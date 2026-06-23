import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { StoreTypes, storeTypesDropdown } from '../../../../shared/constants/store-types';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { getEnumOptions } from '../../../../shared/utils/get-enum-options';
import { Store } from '../../models/store.model';
import { StoreType } from '../../models/store-type.model';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss'
})
export class StoreComponent {
  id?: any;
  storeTypes: StoreType[] = [];

  form = new FormGroup({    
    storeType: new FormControl<StoreType | undefined>(undefined),
    storeName: new FormControl<string>(''),
    //capacity: new FormControl<number | undefined>(0),
    //area: new FormControl<number | undefined>(0),
    //isOwner: new FormControl<boolean | undefined>(true),
  });

  constructor(
    private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.loadStoreTypes();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Stores', this.id).subscribe((res: any) => {
          this.form.setValue({
            storeType: new StoreType(res.data.storeTypeName, res.data.storeTypeId),
            //contact: new DropdownOption(res.data.contact.id, res.data.contact.name),
            storeName: res.data.name,
            //capacity: res.data.capacity,
            //area: res.data.area,
            //isOwner: res.data.isOwner,
          });
        });
      }

    });
  }

  loadStoreTypes() {
    this.basicInformationService.getAll('StoreTypes').subscribe({
      next: (res: any) => {
        this.storeTypes = res.data.items.map((item: any) => new StoreType(item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    let storeType: any = this.form.get('storeType')?.value!;

    const store: Store = new Store(
      this.form.get('storeType')?.value!.id!,
      this.form.get('storeName')?.value!,
      // this.form.get('capacity')?.value!,
      // this.form.get('area')?.value!,
      // this.form.get('isOwner')?.value!,
      // this.form.get('contact')?.value!.id!,
      this.id
    );

    const storeAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Stores', store)
      : this.basicInformationService.postBasicInformation('Stores', store);

    storeAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/store-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
