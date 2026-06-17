import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { MessageService } from 'primeng/api';
import { DeclarationContainerService } from '../../services/declaration-container.service';
import { DeclarationContainerFull } from '../../models/declaration-container-full.model';
import { DeclarationContainer } from '../../models/declaration-container.model';

@Component({
  selector: 'app-declaration-container',
  templateUrl: './declaration-container.component.html',
  styleUrl: './declaration-container.component.scss'
})
export class DeclarationContainerComponent {
  @Output() showConainerInfoEvent = new EventEmitter<any>();

  declarationItemId?: string;
  id?: any;
  containers: DropdownOption[] = [];
  rawContainers: any[] = [];
  declarationContainers: DeclarationContainerFull[] = [];

  form = new FormGroup({
    container: new FormControl<DropdownOption | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private declarationContainerService: DeclarationContainerService,
    private messageService: MessageService,
  ) {
    this.loadContainers();
  }

  loadForm(declarationItemId: string) {
    this.declarationItemId = declarationItemId;
    this.loadDeclarationContainers();
  }

  loadDeclarationContainers() {
    this.declarationContainerService.getByDeclarationItemId(this.declarationItemId!).subscribe({
      next: (res: any) => {
        this.declarationContainers = res.data.map((container: any) => new DeclarationContainerFull(container.declarationContainerId, container.declarationItemId, container.containerId, container.containerNo, container.containerTypeAndSize));
      },
      error: (error: any) => { }
    });
  }

  loadContainers() {
    this.basicInformationService.getAll('Container').subscribe({
      next: (res: any) => {
        this.containers = res.data.map((item: any) => new DropdownOption(item.id, item.containerNumber));
        this.rawContainers = res.data;
      },
      error: (error: any) => { }
    });
  }

  showContainerInfo(declarationContainer: DeclarationContainerFull) {
    this.showConainerInfoEvent.emit(
      {
        id: declarationContainer.declarationContainerId,
        container: declarationContainer.containerNo
      });
  }

  onDeleteContainer(declarationContainerId: string) {
    this.declarationContainerService.deleteDeclarationContainer(declarationContainerId).subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.loadDeclarationContainers();
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    var container = this.rawContainers.filter(item => item.id == this.form.get('container')?.value!.id!)[0];

    const declarationContainer: DeclarationContainer = new DeclarationContainer(
      this.declarationItemId!,
      container.id!,
      false,
      container.weight,
      this.id);

    const declarationContainerAction$ = this.id
      ? this.declarationContainerService.putDeclarationContainer(declarationContainer)
      : this.declarationContainerService.postDeclarationContainer(declarationContainer);

    declarationContainerAction$.subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
        this.loadDeclarationContainers();
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
      }
    });
  }
}
