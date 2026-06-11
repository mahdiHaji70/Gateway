import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PlaceTypes, placeTypesDropdown } from '../../../../shared/constants/place-types';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { getEnumOptions } from '../../../../shared/utils/get-enum-options';
import { Place } from '../../models/place.model';

@Component({
  selector: 'app-place',
  templateUrl: './place.component.html',
  styleUrl: './place.component.scss'
})
export class PlaceComponent {
  id?: any;
  placeTypes: { name: string; value: number }[] = [];
  contacts: DropdownOption[] = [];


  form = new FormGroup({
    placeType: new FormControl<{ name: string; value: PlaceTypes; } | undefined>(undefined),
    contact: new FormControl<DropdownOption | undefined>(undefined),
    placeName: new FormControl<string>(''),
    capacity: new FormControl<number | undefined>(0),
    area: new FormControl<number | undefined>(0),
    isOwner: new FormControl<boolean | undefined>(true),
  });

  constructor(
    private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
    this.placeTypes = getEnumOptions(PlaceTypes);
  }

  ngOnInit() {
    this.loadContacts();
    
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Place', this.id).subscribe((res: any) => {
          this.form.setValue({
            placeType: placeTypesDropdown.find(
              (type) => type.value === res.data.placeType),
            contact: new DropdownOption(res.data.contact.id, res.data.contact.name),
            placeName: res.data.placeName,
            capacity: res.data.capacity,
            area: res.data.area,
            isOwner: res.data.isOwner,
          });
        });
      }

    });
  }

  loadContacts() {
    this.basicInformationService.getAll('Contact').subscribe({
      next: (res: any) => {
        this.contacts = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  onSubmit(): void {
      if (!this.form.valid) {
        return;
      }
  
      let placeType: any = this.form.get('placeType')?.value!;
  
      const place: Place = new Place(
        placeType.value,
        this.form.get('placeName')?.value!,
        this.form.get('capacity')?.value!,
        this.form.get('area')?.value!,
        this.form.get('isOwner')?.value!,
        this.form.get('contact')?.value!.id!,
        this.id
      );
  
      const placeAction$ = this.id
        ? this.basicInformationService.putBasicInformation('Place', place)
        : this.basicInformationService.postBasicInformation('Place', place);
  
        placeAction$
        .subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
            this.router.navigate(['/place-list'])
          },
          error: (error: any) => {
            this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
          }
        }
        );
    }
}
