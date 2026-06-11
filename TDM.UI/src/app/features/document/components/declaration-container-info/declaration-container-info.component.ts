import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { DeclarationContainerInfoFull } from '../../models/declaration-container-info-full.model';
import { DeclarationContainerInfoService } from '../../services/declaration-container-info.service';
import { DeclarationContainerInfo } from '../../models/declaration-container-info.model';
import { ConfirmationService, MessageService } from 'primeng/api';
import { debug } from 'console';

@Component({
  selector: 'app-declaration-container-info',
  templateUrl: './declaration-container-info.component.html',
  styleUrl: './declaration-container-info.component.scss'
})
export class DeclarationContainerInfoComponent {
  id?: any;
  declarationContainerId?: any;
  declarationContainerInfos: DeclarationContainerInfoFull[] = [];
  commodities: DropdownOption[] = [];
  packages: DropdownOption[] = [];

  form = new FormGroup({
    commodity: new FormControl<DropdownOption | undefined>(undefined),
    package: new FormControl<DropdownOption | undefined>(undefined),
    packNumber: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
  });

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private declarationContainerInfoService: DeclarationContainerInfoService,
    private confirmationService: ConfirmationService
  ) {

  }

  ngOnInit() {
    this.loadCommodities();
    this.loadPackages();
  }

  loadCommodities() {
    this.basicInformationService.getAll('Commodity').subscribe({
      next: (res: any) => {
        this.commodities = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadPackages() {
    this.basicInformationService.getAll('Package').subscribe({
      next: (res: any) => {
        this.packages = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadForm(declarationContainerId: string) {
    this.declarationContainerId = declarationContainerId;
    this.loadDeclarationContainerInfos();
  }

  onInfoEdit(declarationContainerInfo: DeclarationContainerInfoFull) {
    this.form.setValue({
      commodity: new DropdownOption(declarationContainerInfo.commodityId, declarationContainerInfo.commodityName),
      package: new DropdownOption(declarationContainerInfo.packageId, declarationContainerInfo.packageName),
      packNumber: declarationContainerInfo.packNumber,
      weight: declarationContainerInfo.weight,
    });
    this.id = declarationContainerInfo.id;
  }

  resetForm() {
    this.form.reset({
      commodity: undefined,
      package: undefined,
      packNumber: 0,
      weight: 0,
    });
    this.id = undefined;
  }

  loadDeclarationContainerInfos() {
    this.declarationContainerInfoService.getByDeclarationContainerId(this.declarationContainerId!).subscribe({
      next: (res: any) => {
        this.declarationContainerInfos = res.data.map((item: any) => new DeclarationContainerInfoFull(item.declarationContainerId, item.commodityId, item.commodityName,
          item.packageId, item.packageName, item.packNumber, item.weight, item.id));
      },
      error: (error: any) => { }
    });
  }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    const declarationContainerInfo: DeclarationContainerInfo = new DeclarationContainerInfo(
      this.declarationContainerId!,
      this.form.get('commodity')?.value!.id!,
      this.form.get('package')?.value!.id!,
      this.form.get('packNumber')?.value!,
      this.form.get('weight')?.value!,
      this.id);

    const declarationContainerAction$ = this.id
      ? this.declarationContainerInfoService.putDeclarationContainerInfo(declarationContainerInfo)
      : this.declarationContainerInfoService.postDeclarationContainerInfo(declarationContainerInfo);

    declarationContainerAction$.subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.resetForm();
        this.loadDeclarationContainerInfos();
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }

  onInfoDelete(event: any, id: any) {
    this.declarationContainerInfoService.deleteDeclarationContainerInfo(id).subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.loadDeclarationContainerInfos();
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }
}

