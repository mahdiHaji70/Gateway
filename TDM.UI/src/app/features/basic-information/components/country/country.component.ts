import { Component } from '@angular/core';
import { BasicInformationService } from '../../services/basic-information.service';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from '../../models/country.model';
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrl: './country.component.scss'
})
export class CountryComponent {
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
        this.basicInformationService.getById('Country', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const country: Country = new Country(
      this.form.get('code')?.value!,
      this.form.get('name')?.value!,
      this.id
    );

    const countryAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Country', country)
      : this.basicInformationService.postBasicInformation('Country', country);

    countryAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/country-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
