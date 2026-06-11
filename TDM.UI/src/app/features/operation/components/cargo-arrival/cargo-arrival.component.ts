import { Component } from '@angular/core';
import { ArrivalDeclarationTypes, arrivalDeclarationTypesDropdown } from '../../../../shared/constants/arrival-declaration-types';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { DeclarationService } from '../../services/declaration.service';
import { CargoArrivalService } from '../../services/cargo-arrival.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { getEnumOptions } from '../../../../shared/utils/get-enum-options';
import { CargoArrival } from '../../models/cargo-arrival.model';

@Component({
  selector: 'app-cargo-arrival',
  templateUrl: './cargo-arrival.component.html',
  styleUrl: './cargo-arrival.component.scss'
})
export class CargoArrivalComponent {
  id?: string;
  declarations: DropdownOption[] = [];
  vehicles: DropdownOption[] = [];
  arrivalDeclarationTypes: { name: string; value: number }[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
    vehicle: new FormControl<DropdownOption | undefined>(undefined),
    arrivalDeclarationType: new FormControl<{ name: string; value: ArrivalDeclarationTypes; } | undefined>(undefined),
    packageCount: new FormControl<number | undefined>(0),
    weight: new FormControl<number | undefined>(0),
    transportDate: new FormControl<Date | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private cargoArrivalService: CargoArrivalService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
    private basicInformationService: BasicInformationService) {
    this.arrivalDeclarationTypes = getEnumOptions(ArrivalDeclarationTypes);

  }
  ngOnInit() {
    this.loadDeclarations();
    this.loadVehicles();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.cargoArrivalService.getById(this.id!).subscribe((res: any) => {
          this.form.setValue({
            declaration: new DropdownOption(res.data.declarationId, res.data.declarationNumber),
            vehicle: new DropdownOption(res.data.vehicleId, res.data.vehicleName),
            arrivalDeclarationType: arrivalDeclarationTypesDropdown.find(
              (type) => type.value === res.data.arrivalDeclarationType),
            packageCount: res.data.packageCount,
            weight: res.data.weight,
            transportDate: new Date(res.data.transportDate),
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
    this.cargoArrivalService.getVehiclesByType(3).subscribe({
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

    let arrivalDeclarationType: any = this.form.get('arrivalDeclarationType')?.value!;


    const cargoArrival: CargoArrival = new CargoArrival(
      this.form.get('declaration')?.value!.id!,
      this.form.get('vehicle')?.value!.id!,
      this.form.get('transportDate')?.value!,
      this.form.get('weight')?.value!,
      this.form.get('packageCount')?.value!,
      arrivalDeclarationType.value!,
      this.id
    );

    const cargoArrivalAction$ = this.id
      ? this.cargoArrivalService.putCargoArrival(cargoArrival)
      : this.cargoArrivalService.postCargoArrival(cargoArrival);

      cargoArrivalAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/operation/cargo-arrival-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      });

  }
}
