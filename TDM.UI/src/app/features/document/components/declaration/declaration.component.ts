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
import { formatUTCDate } from '../../../../shared/utils/format-date';
import { DeclarationContainerFull } from '../../models/declaration-container-full.model';
import { DeclarationContainerInfoFull } from '../../models/declaration-container-info-full.model';

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrl: './declaration.component.scss'
})
export class DeclarationComponent {
  @ViewChild('declaration_item', { static: false }) declarationItem!: DeclarationItemComponent;
  // @ViewChild('declaration_container', { static: false }) declarationContainer!: DeclarationContainerComponent;
  // @ViewChild('declaration_container_info', { static: false }) declarationContainerInfo!: DeclarationContainerInfoComponent;

  id?: any;
  contacts: DropdownOption[] = [];
  traffics: DropdownOption[] = [];
  declarationItems: DeclarationItemFull[] = [];
  itemsPopupVisibility: boolean = false;
  containerPopupVisibility: boolean = false;
  containerInfoPopupVisibility: boolean = false;
  containerInfoHeader: string = "";

  form = new FormGroup({
    //declarationType: new FormControl<DropdownOption | undefined>(undefined),
    number: new FormControl<string>(''),
    date: new FormControl<Date | undefined>(undefined),
    startDate: new FormControl<Date | undefined>(undefined),
    endDate: new FormControl<Date | undefined>(undefined),
    contact: new FormControl<DropdownOption | undefined>(undefined),
    contactRep: new FormControl<DropdownOption | undefined>(undefined),
    traffic: new FormControl<DropdownOption | undefined>(undefined),
    description: new FormControl<string>(''),
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
            number: data.number,
            date: new Date(data.date),
            startDate: new Date(data.startDate),
            endDate: new Date(data.endDate),
            traffic: new DropdownOption(data.trafficId, data.trafficName),
            contact: new DropdownOption(data.consigneeId, data.consigneeName),
            contactRep: new DropdownOption(data.consigneeRepId, data.consigneeRepName),
            description: data.description,
          });
        });
        this.loadDeclarationItems();
      }

    });
    this.loadContacts();
    this.loadTraffics();
  }

  loadContacts() {
    this.basicInformationService.getAll('companies').subscribe({
      next: (res: any) => {
        this.contacts = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadTraffics() {
    this.basicInformationService.getAll('traffics').subscribe({
      next: (res: any) => {
        this.traffics = res.data.items.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadDeclarationItems() {
    this.declarationItemService.getByDeclarationId(this.id).subscribe({
      next: (res: any) => {
        this.declarationItems = res.data.map((item: any) => {
          var declarationItem = new DeclarationItemFull(item.id, item.declarationId,
            item.declarationNumber, item.commodityId, item.commodityName, item.quantity, item.grossWeight,
            item.netWeight, item.packageId, item.packageName);

          if (item.declarationContainers != null && item.declarationContainers.length > 0) {
            declarationItem.declarationContainers = item.declarationContainers.map((container: any) => {
              var declarationContainer = new DeclarationContainerFull(container.declarationContainerId, container.declarationItemId, container.containerId, container.containerNo, container.containerTypeAndSize);

              if (container.declarationContainerGoods != null && container.declarationContainerGoods.length > 0) {
                declarationContainer.declarationContainerInfos = container.declarationContainerGoods.map((containerGood: any) =>
                  new DeclarationContainerInfoFull(containerGood.declarationContainerId, containerGood.commodityId, containerGood.commodityName,
                    containerGood.packageId, containerGood.packageName, containerGood.quantity, containerGood.weight
                  ));
              }
              return declarationContainer;
            });
          }
          return declarationItem;
        });
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

  onEditItem(declarationItemId: string) {
    this.declarationItem.loadForm(declarationItemId);
    this.showItemsPopup();
  }

  onDeleteItem(declarationItemId: string) {
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

  // onAddContainer(declarationItemId: string) {
  //   this.declarationContainer.loadForm(declarationItemId);
  //   this.showContainersPopup();
  // }

  // showContainerInfoPopup(event: any) {
  //   this.declarationContainerInfo.loadForm(event.id);
  //   this.containerInfoHeader = event.container;
  //   this.containerInfoPopupVisibility = true;
  // }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    let declarationType: any = this.form.get('declarationType')?.value!;

    const declaration: Declaration = new Declaration(
      this.form.get('number')?.value!,
      formatUTCDate(this.form.get('date')?.value! as Date),
      formatUTCDate(this.form.get('startDate')?.value! as Date),
      formatUTCDate(this.form.get('endDate')?.value! as Date),
      this.form.get('contact')?.value!.id!,
      this.form.get('traffic')?.value!.id!,
      //todo change terminal id to dynamic mode
      '088',
      this.form.get('description')?.value!,
      this.form.get('contactRep')?.value!.id!,
      this.id);

    const declarationAction$ = this.id
      ? this.declarationService.putDeclaration(declaration)
      : this.declarationService.postDeclaration(declaration);

    declarationAction$.subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.id = res.data
        this.loadDeclarationItems();
      },
      error: (failRes: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error.Message });
      }
    });
  }

  sendDeclarationToIpas(id: string) {
    console.log(id)
    this.declarationService.requestIpasDeclarationId(id).subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
      },
      error: (failRes: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error.Message });
      }
    });
  }

  getItemsFromIpas(id: string) {
    this.declarationItemService.requestIpasDeclarationItems(id).subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.loadDeclarationItems();
      },
      error: (failRes: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error.Message });
      }
    });
  }
}
