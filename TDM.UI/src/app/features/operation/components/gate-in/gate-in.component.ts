import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { DeclarationService } from '../../services/declaration.service';
import { GateService } from '../../services/gate.service';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { MessageService } from 'primeng/api';
import { Gate } from '../../models/gate.model';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-gate-in',
  templateUrl: './gate-in.component.html',
  styleUrl: './gate-in.component.scss'
})
export class GateInComponent {
id?: string;
  declarations: DropdownOption[] = [];
  vehicles: DropdownOption[] = [];
  containers: DropdownOption[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
    vehicle: new FormControl<DropdownOption | undefined>(undefined),
    container: new FormControl<DropdownOption | undefined>(undefined),
    enterDate: new FormControl<Date | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private gateService: GateService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
    private basicInformationService: BasicInformationService
  ) {
  }

  ngOnInit() {
    this.loadDeclarations();
    this.loadVehicles();
    this.loadContainers();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.gateService.getById(this.id!).subscribe((res: any) => {
          //this.form.patchValue(res.data);
          this.form.setValue({
            declaration: new DropdownOption(res.data.declarationId, res.data.declarationNumber),
            vehicle: new DropdownOption(res.data.vehicleId, res.data.vehicleName),
            container: new DropdownOption(res.data.containerId, res.data.containerNumber),
            enterDate: new Date(res.data.enterDate),
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
    this.gateService.getVehiclesByType(3).subscribe({
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

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    const gate: Gate = new Gate(
      this.form.get('declaration')?.value!.id!,
      this.form.get('vehicle')?.value!.id!,
      this.form.get('enterDate')?.value!,
      this.form.get('container')?.value! == null ? undefined : this.form.get('container')?.value!.id!,
      this.id
    );

    const gateAction$ = this.id
      ? this.gateService.putGate(gate)
      : this.gateService.postGate(gate);

    gateAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/operation/gate-in-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      });

  }
}
