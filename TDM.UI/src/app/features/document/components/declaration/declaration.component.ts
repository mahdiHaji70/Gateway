import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DeclarationType } from '../../../basic-information/models/declaration-type.model';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { Contact } from '../../../basic-information/models/contact.model';
import { City } from '../../../basic-information/models/city.model';
import { DeclarationService } from '../../services/declaration.service';
import { Declaration } from '../../models/declaration.model';
import { MessageService } from 'primeng/api';
import { DeclarationItemService } from '../../services/declaration-item.service';
import { DeclarationItemFull } from '../../models/declaration-item-full.model';
import { cargoTypesDropdown } from '../../../../shared/constants/cargo-types';
import { ActivatedRoute } from '@angular/router';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { DeclarationItemComponent } from '../declaration-item/declaration-item.component';
import { DeclarationContainerComponent } from '../declaration-container/declaration-container.component';
import { DeclarationContainerInfoComponent } from '../declaration-container-info/declaration-container-info.component';

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrl: './declaration.component.scss'
})
export class DeclarationComponent {
  @ViewChild('declaration_item', { static: false }) declarationItem!: DeclarationItemComponent;
  @ViewChild('declaration_container', { static: false }) declarationContainer!: DeclarationContainerComponent;
  @ViewChild('declaration_container_info', { static: false }) declarationContainerInfo!: DeclarationContainerInfoComponent;
  
  id?: any;
  declarationTypes: DropdownOption[] = [];
  contacts: DropdownOption[] = [];
  cities: DropdownOption[] = [];
  declarationItems: DeclarationItemFull[] = [];
  itemsPopupVisibility: boolean = false;
  containerPopupVisibility: boolean = false;
  containerInfoPopupVisibility: boolean = false;
  containerInfoHeader: string = "";

  form = new FormGroup({
    declarationType: new FormControl<DropdownOption | undefined>(undefined),
    number: new FormControl<string>(''),
    //declarationDate: new FormControl<Date | undefined>(undefined),
    contact: new FormControl<DropdownOption | undefined>(undefined),
    contactAgent: new FormControl<DropdownOption | undefined>(undefined),
    bookingNumber: new FormControl<string>(''),
    originCity: new FormControl<DropdownOption | undefined>(undefined),
    destinationCity: new FormControl<DropdownOption | undefined>(undefined),
    carrierContact: new FormControl<DropdownOption | undefined>(undefined),
    serial: new FormControl<string>(''),
  });

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private declarationService: DeclarationService,
    private declarationItemService: DeclarationItemService,
    private route: ActivatedRoute,
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.declarationService.getById(this.id).subscribe((res: any) => {
          var data = res.data;
          this.form.setValue({
            declarationType: new DropdownOption(data.declarationTypeId, data.declarationTypeName),
            number: data.number,
            contact: new DropdownOption(data.contactId, data.contactName),
            contactAgent: new DropdownOption(data.contactAgentId, data.contactAgentName),
            bookingNumber: data.bookingNumber,
            originCity: new DropdownOption(data.originCityId, data.originCityName),
            destinationCity: new DropdownOption(data.destinationCityId, data.destinationCityName),
            carrierContact: new DropdownOption(data.carrierContactId, data.carrierContactName),
            serial: data.serial
          });
        });
        this.loadDeclarationItems();
      }

    });
    this.loadDeclarationTypes();
    this.loadContacts();
    this.loadCities();
  }

  loadDeclarationTypes() {
    this.basicInformationService.getAll('DeclarationType').subscribe({
      next: (res: any) => {
        this.declarationTypes = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
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

  loadCities() {
    this.basicInformationService.getAll('City').subscribe({
      next: (res: any) => {
        this.cities = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadDeclarationItems() {
    this.declarationItemService.getByDeclarationId(this.id).subscribe({
      next: (res: any) => {
        this.declarationItems = res.data.map((item: any) => new DeclarationItemFull(item.declarationId, item.cargoType,
          cargoTypesDropdown.find((type) => type.value === item.cargoTypeId)!.name!, item.commodityId, item.commodityName, item.packNumber,
          item.weight, item.volume, item.packageId, item.packageName, item.trafficId, item.trafficName, item.shipMark, item.id));
          this.declarationItem.resetForm();
      },
      error: (error: any) => { }
    });
  }

  showItemsPopup() {
    this.itemsPopupVisibility = true;
  }

  showContainersPopup() {
    this.containerPopupVisibility = true;
  }

  declarationItemAddedEvent($event: boolean) {
    this.itemsPopupVisibility = false;
  } 

  onEditItem(declarationItemId: string){
    this.declarationItem.loadForm(declarationItemId);
    this.showItemsPopup();
  }

  onDeleteItem(declarationItemId: string){
    this.declarationItemService.deleteDeclarationItem(declarationItemId).subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.loadDeclarationItems();
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }

  onAddContainer(declarationItemId: string){
    this.declarationContainer.loadForm(declarationItemId);
    this.showContainersPopup();
  }

  showContainerInfoPopup(event: any){
    this.declarationContainerInfo.loadForm(event.id);
    this.containerInfoHeader = event.container;
    this.containerInfoPopupVisibility = true;
  }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    let declarationType: any = this.form.get('declarationType')?.value!;

    const declaration: Declaration = new Declaration(
      declarationType.id,
      this.form.get('number')?.value!,
      this.form.get('contact')?.value!.id!,
      this.form.get('bookingNumber')?.value!,
      //todo change terminal id to dynamic mode
      '3780B827-A2BC-4331-B474-576100D3104B',
      this.form.get('originCity')?.value!.id!,
      this.form.get('destinationCity')?.value!.id!,
      true,
      this.form.get('contactAgent')?.value!.id!,
      this.form.get('carrierContact')?.value!.id!,
      this.id,
      this.form.get('serial')?.value!,);

    const declarationAction$ = this.id
      ? this.declarationService.putDeclaration(declaration)
      : this.declarationService.postDeclaration(declaration);

    declarationAction$.subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.id = res.data
        this.loadDeclarationItems();
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }
}
