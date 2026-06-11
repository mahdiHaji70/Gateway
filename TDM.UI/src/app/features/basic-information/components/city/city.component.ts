import { Component } from '@angular/core';
import { BasicInformationService } from '../../services/basic-information.service';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from '../../models/city.model';
import { Country } from '../../models/country.model';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrl: './city.component.scss'
})
export class CityComponent {
  id?: any;
  countries: Country[] = [];

  form = new FormGroup({
    code: new FormControl<string>(''),
    name: new FormControl<string>(''),
    country: new FormControl<Country | undefined>(undefined)
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
    this.loadCountries();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('City', this.id).subscribe((res: any) => {
          //this.form.patchValue(res.data);
          this.form.setValue({
            code: res.data.code,
            name: res.data.name,
            country: new Country(res.data.countryCode, res.data.countryName, res.data.countryId)
          });
        });
      }

    });

  }

  loadCountries() {
    this.basicInformationService.getAll('Country').subscribe({
      next: (res: any) => {
        this.countries = res.data.map((item: any) => new Country(item.code, item.name, item.id));
      },
      error: (error: any) => { }
    });
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const city: City = new City(
      this.form.get('country')?.value!.id!,
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const cityAction$ = this.id
      ? this.basicInformationService.putBasicInformation('City', city)
      : this.basicInformationService.postBasicInformation('City', city);

    cityAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/city-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
