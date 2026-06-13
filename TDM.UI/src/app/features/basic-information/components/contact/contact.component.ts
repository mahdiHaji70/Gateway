import { Component, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '../../models/contact.model';
import { ContactTypes, contactTypesDropdown } from '../../../../shared/constants/contact-types';
import { getEnumOptions } from '../../../../shared/utils/get-enum-options';
import { formatUTCDate } from '../../../../shared/utils/format-date';

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
    nationalId: new FormControl<string>(''),
    registerDate: new FormControl<Date | undefined>(undefined),
    address: new FormControl<string>(''),
    postCode: new FormControl<string>('', [Validators.pattern(/^[0-9]{10}$/)]),
    mobile: new FormControl<string>('', [Validators.required, Validators.pattern(/^09\d{9}$/)]),
    economicCode: new FormControl<string>(''),
    registerNumber: new FormControl<string>(''),
    registerPlace: new FormControl<string>(''),
    phone: new FormControl<string>('', [Validators.pattern(/^0\d{10}$/)]),
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
        this.basicInformationService.getById('companies', this.id).subscribe((res: any) => {
          this.form.setValue({
            contactType: contactTypesDropdown.find(
              (type) => type.value === res.data.companyType),
            name: res.data.name,
            nationalId: res.data.nationalId,
            registerDate: new Date(res.data.registerDate),
            address: res.data.address,
            postCode: res.data.postCode,
            mobile: res.data.mobile,
            economicCode: res.data.economicCode,
            registerNumber: res.data.registerNumber,
            registerPlace: res.data.registerPlace,
            phone: res.data.phone,
          });
        });
      }

    });

    this.form.get('contactType')?.valueChanges.subscribe((contactType) => {
      this.setValidatorsBasedOnContactType(contactType!);
    });
  }

  private setValidatorsBasedOnContactType(contactType: any | undefined): void {
    const nationalCodeControl = this.form.get('nationalId');
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
      this.form.get('nationalId')?.value!,
      formatUTCDate(this.form.get('registerDate')?.value as Date),
      this.form.get('address')?.value!,
      this.form.get('postCode')?.value!,
      this.form.get('mobile')?.value!,
      this.form.get('economicCode')?.value!,
      this.form.get('registerNumber')?.value!,
      this.form.get('registerPlace')?.value!,
      this.form.get('phone')?.value!,
      this.id
    );

    const contactAction$ = this.id
      ? this.basicInformationService.putBasicInformation('companies', contact)
      : this.basicInformationService.postBasicInformation('companies', contact);

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
