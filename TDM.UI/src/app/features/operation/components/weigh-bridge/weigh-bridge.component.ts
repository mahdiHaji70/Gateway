import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { DeclarationService } from '../../services/declaration.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { WeighBridgeService } from '../../services/weigh-bridge.service';
import { WeightBridge } from '../../models/weight-bridge.model';

@Component({
  selector: 'app-weigh-bridge',
  templateUrl: './weigh-bridge.component.html',
  styleUrl: './weigh-bridge.component.scss'
})
export class WeighBridgeComponent {
  id?: string;
  declarations: DropdownOption[] = [];
  vehicles: DropdownOption[] = [];
  
  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
    vehicle: new FormControl<DropdownOption | undefined>(undefined),
    grossWeight: new FormControl<number | undefined>(0),
    tareWeight: new FormControl<number | undefined>(0),    
    startDate: new FormControl<Date | undefined>(undefined),
    endDate: new FormControl<Date | undefined>(undefined),
  });

    /**
     *
     */
    constructor(private declarationService: DeclarationService,
      private weighBridgeService: WeighBridgeService,
      private messageService: MessageService,
      private router: Router,
      private route: ActivatedRoute,
    ) {
    }

    ngOnInit() {
      this.loadDeclarations();
      this.loadVehicles();
  
      this.route.params.subscribe((params: any) => {
        if (params.id) {
          this.id = params.id;
          this.weighBridgeService.getById(this.id!).subscribe((res: any) => {
            this.form.setValue({
              declaration: new DropdownOption(res.data.declarationId, res.data.declarationNumber),
              vehicle: new DropdownOption(res.data.vehicleId, res.data.vehicleName),
              grossWeight: res.data.grossWeight,
              tareWeight: res.data.tareWeight,
              startDate: new Date(res.data.startDate),
              endDate: new Date(res.data.endDate),
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
      this.weighBridgeService.getVehiclesByType(3).subscribe({
        next: (res: any) => {
          this.vehicles = res.data.map((item: any) => new DropdownOption(item.id, item.vehicleName));
        },
        error: (error: any) => { }
      });
    }

      onSubmit() {
        if (!this.form.valid) {
          return;
        }
    
        const weightBridge: WeightBridge = new WeightBridge(
          this.form.get('declaration')?.value!.id!,
          '5F8394D1-594B-43F6-91B0-12FEB9888070',
          this.form.get('vehicle')?.value!.id!,          
          this.form.get('grossWeight')?.value!,
          this.form.get('tareWeight')?.value!,
          this.form.get('startDate')?.value!,
          this.form.get('endDate')?.value!,
          this.id
        );
    
        const weightBridgeAction$ = this.id
          ? this.weighBridgeService.putWeighBridge(weightBridge)
          : this.weighBridgeService.postWeighBridge(weightBridge);
    
          weightBridgeAction$
          .subscribe({
            next: (res: any) => {
              this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
              this.router.navigate(['/operation/weigh-bridge-list'])
            },
            error: (error: any) => {
              this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
            }
          });
    
      }
}
