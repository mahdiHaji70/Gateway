import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { OperationDetailService } from '../../services/operation-detail.service';
import { DeclarationService } from '../../services/declaration.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { OperationDetail } from '../../models/operation-detail.model';

@Component({
  selector: 'app-discharge',
  templateUrl: './discharge.component.html',
  styleUrl: './discharge.component.scss'
})
export class DischargeComponent {
  id?: string;
  declarations: DropdownOption[] = [];
  vehicles: DropdownOption[] = [];
  containers: DropdownOption[] = [];
  places: DropdownOption[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
    vehicle: new FormControl<DropdownOption | undefined>(undefined),
    place: new FormControl<DropdownOption | undefined>(undefined),
    packNumber: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
    volume: new FormControl<number | undefined>(0),
    container: new FormControl<DropdownOption | undefined>(undefined),
    operationDate: new FormControl<Date | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private operationDetailService: OperationDetailService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
    private basicInformationService: BasicInformationService) {
  }
  ngOnInit() {
    this.loadDeclarations();
    this.loadVehicles();
    this.loadContainers();
    this.loadPlaces();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.operationDetailService.getById(this.id!).subscribe((res: any) => {
          this.form.setValue({
            declaration: new DropdownOption(res.data.declarationId, res.data.declarationNumber),
            vehicle: new DropdownOption(res.data.vehicleId, res.data.vehicleName),
            place: new DropdownOption(res.data.placeId, res.data.placeName),
            packNumber: res.data.packNumber,
            weight: res.data.weight,
            volume: res.data.volume,
            container: new DropdownOption(res.data.containerId, res.data.containerNumber),
            operationDate: new Date(res.data.operationDate),
          });
        });
      }

    });
  }

  loadDeclarations() {
    this.declarationService.getDeclarations().subscribe({
      next: (res: any) => {
        this.declarations = res.data.map((item: any) => new DropdownOption(item.id, item.number));
      },
      error: (error: any) => { }
    });
  }

  loadVehicles() {
    this.operationDetailService.getVehiclesByType(3).subscribe({
      next: (res: any) => {
        this.vehicles = res.data.map((item: any) => new DropdownOption(item.id, item.vehicleName));
      },
      error: (error: any) => { }
    });
  }

  loadContainers() {
    this.basicInformationService.getAll('Container').subscribe({
      next: (res: any) => {
        this.containers = res.data.map((item: any) => new DropdownOption(item.id, item.containerNumber));
      },
      error: (error: any) => { }
    });
  }

  loadPlaces() {
    this.basicInformationService.getAll('Place').subscribe({
      next: (res: any) => {
        this.places = res.data.map((item: any) => new DropdownOption(item.id, item.placeName));
      },
      error: (error: any) => { }
    });
  }


  onSubmit() {
      if (!this.form.valid) {
        return;
      }
  
      const operationDetail: OperationDetail = new OperationDetail(
        this.form.get('declaration')?.value!.id!,
        this.form.get('vehicle')?.value!.id!,
        this.form.get('place')?.value!.id!,
        this.form.get('packNumber')?.value!,
        this.form.get('weight')?.value!,
        this.form.get('operationDate')?.value!,
        //todo change operation type id to dynamic mode
        'e5b47b62-b3f4-4205-a666-8855f1a75781',
        this.form.get('volume')?.value!,    
        this.form.get('container')?.value! == null ? undefined : this.form.get('container')?.value!.id!,
        undefined,
        undefined,
        this.id
      );
  
      const operationDetailAction$ = this.id
        ? this.operationDetailService.putOperationDetail(operationDetail)
        : this.operationDetailService.postOperationDetail(operationDetail);
          
        operationDetailAction$
        .subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
            this.router.navigate(['/operation/discharge-list'])
          },
          error: (error: any) => {
            this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
          }
        });
  
    }
}
