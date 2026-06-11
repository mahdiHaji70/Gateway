import { Component, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '../../models/contact.model';
import { ContactTypes, contactTypesDropdown } from '../../../../shared/constants/contact-types';
import { getEnumOptions } from '../../../../shared/utils/get-enum-options';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {
  id?: any;
  contactTypes: { name: string; value: number }[] = [];

  form = new FormGroup({
    contactType: new FormControl<{ name: string; value: ContactTypes; } | undefined>(undefined),
    name: new FormControl<string>('', [Validators.minLength(3)]),
    nationalCode: new FormControl<string>(''),
    certificateNumber: new FormControl<string>(''),
    economicCode: new FormControl<string>(''),
    registrationDate: new FormControl<Date | undefined>(undefined),
    registrationPlace: new FormControl<string>(''),
    postalCode: new FormControl<string>('', [Validators.pattern(/^[0-9]{10}$/)]),
    mobile: new FormControl<string>('', [Validators.required, Validators.pattern(/^09\d{9}$/)]),
    phone: new FormControl<string>('', [Validators.required, Validators.pattern(/^0\d{10}$/)]),
    address: new FormControl<string>(''),
    commerceCardCode: new FormControl<string>(''),
    email: new FormControl<string>('', [Validators.email]),
  });
  /**
   *
   */
  constructor(
    private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
    this.contactTypes = getEnumOptions(ContactTypes);
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('Contact', this.id).subscribe((res: any) => {
          this.form.setValue({
            contactType: contactTypesDropdown.find(
              (type) => type.value === res.data.contactType),
            name: res.data.name,
            nationalCode: res.data.nationalCode,
            certificateNumber: res.data.certificateNumber,
            economicCode: res.data.economicCode,
            registrationDate: new Date(res.data.registrationDate),
            registrationPlace: res.data.registrationPlace,
            postalCode: res.data.postalCode,
            mobile: res.data.mobile,
            phone: res.data.phone,
            address: res.data.address,
            commerceCardCode: res.data.commerceCardCode,
            email: res.data.email
          });
        });
      }

    });

    this.form.get('contactType')?.valueChanges.subscribe((contactType) => {
      this.setValidatorsBasedOnContactType(contactType!);
    });
  }

  private setValidatorsBasedOnContactType(contactType: any | undefined): void {
    const nationalCodeControl = this.form.get('nationalCode');
    const economicCodeControl = this.form.get('economicCode');

    if (contactType.value === ContactTypes.Person) {
      nationalCodeControl?.setValidators([Validators.minLength(10), Validators.maxLength(10), Validators.pattern(/^[0-9]{10}$/)]);
    } else if (contactType.value === ContactTypes.Company) {
      nationalCodeControl?.setValidators([Validators.minLength(11), Validators.maxLength(11), Validators.pattern(/^[0-9]{11}$/)]);
      economicCodeControl?.setValidators([Validators.minLength(12), Validators.maxLength(12), Validators.pattern(/^[0-9]{12}$/)]);
    } else {
      nationalCodeControl?.clearValidators();
    }

    nationalCodeControl?.updateValueAndValidity();
  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    let contactType: any = this.form.get('contactType')?.value!;

    const contact: Contact = new Contact(
      contactType.value,
      this.form.get('name')?.value!,
      this.form.get('nationalCode')?.value!,
      this.form.get('certificateNumber')?.value!,
      this.form.get('economicCode')?.value!,
      this.form.get('registrationDate')?.value!,
      this.form.get('registrationPlace')?.value!,
      this.form.get('postalCode')?.value!,
      this.form.get('mobile')?.value!,
      this.form.get('phone')?.value!,
      this.form.get('address')?.value!,
      this.form.get('commerceCardCode')?.value!,
      this.form.get('email')?.value!,
      this.id
    );

    const contactAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Contact', contact)
      : this.basicInformationService.postBasicInformation('Contact', contact);

    contactAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/contact-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }

}
