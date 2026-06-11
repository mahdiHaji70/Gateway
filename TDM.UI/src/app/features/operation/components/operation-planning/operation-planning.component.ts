import { Component } from '@angular/core';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { DeclarationService } from '../../services/declaration.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { BasicInformationService } from '../../../basic-information/services/basic-information.service';
import { OperationPlanningService } from '../../services/operation-planning.service';
import { OperationPlanning } from '../../models/operation-planning.model';

@Component({
  selector: 'app-operation-planning',
  templateUrl: './operation-planning.component.html',
  styleUrl: './operation-planning.component.scss'
})
export class OperationPlanningComponent {
  id?: string;
  declarations: DropdownOption[] = [];
  staffs: DropdownOption[] = [];
  equipments: DropdownOption[] = [];
  shifts: DropdownOption[] = [];
  places: DropdownOption[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
    staff: new FormControl<DropdownOption | undefined>(undefined),
    equipment: new FormControl<DropdownOption | undefined>(undefined),
    shift: new FormControl<DropdownOption | undefined>(undefined),
    place: new FormControl<DropdownOption | undefined>(undefined),
    date: new FormControl<Date | undefined>(undefined),
  });

  /**
    *
    */
  constructor(private operationPlanningService: OperationPlanningService,
    private declarationService: DeclarationService,
    private messageService: MessageService,
    private router: Router,
    private route: ActivatedRoute,
    private basicInformationService: BasicInformationService) {
  }

  ngOnInit() {
    this.loadDeclarations();
    this.loadStaffs();
    this.loadEquipments();
    this.loadShifts();
    this.loadPlaces();

    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.operationPlanningService.getById(this.id!).subscribe((res: any) => {
          this.form.setValue({
            declaration: new DropdownOption(res.data.declarationId, res.data.declarationNumber),
            staff: new DropdownOption(res.data.staffId, res.data.staffName),
            equipment: new DropdownOption(res.data.equipmentId, res.data.equipmentName),
            shift: new DropdownOption(res.data.shiftId, res.data.shiftName),
            place: new DropdownOption(res.data.placeId, res.data.placeName),
            date: new Date(res.data.date),
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

  loadStaffs() {
    this.basicInformationService.getAll('Staff').subscribe({
      next: (res: any) => {
        this.staffs = res.data.map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => { }
    });
  }

  loadEquipments() {
    this.basicInformationService.getAll('Equipment').subscribe({
      next: (res: any) => {
        this.equipments = res.data.map((item: any) => new DropdownOption(item.id, item.equipmentName));
      },
      error: (error: any) => { }
    });
  }

  loadShifts() {
    this.basicInformationService.getAll('ShiftWork').subscribe({
      next: (res: any) => {
        this.shifts = res.data.map((item: any) => new DropdownOption(item.id, item.name));
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
  
      const operationPlanning: OperationPlanning = new OperationPlanning(
        this.form.get('declaration')?.value!.id!,
        this.form.get('staff')?.value!.id!,
        this.form.get('equipment')?.value!.id!,
        this.form.get('shift')?.value!.id!,
        this.form.get('place')?.value!.id!,            
        this.form.get('date')?.value!,                
        this.id
      );
  
      const operationPlanningAction$ = this.id
        ? this.operationPlanningService.putOperationPlanning(operationPlanning)
        : this.operationPlanningService.postOperationPlanning(operationPlanning);
          
        operationPlanningAction$
        .subscribe({
          next: (res: any) => {
            this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
            this.router.navigate(['/operation/operation-planning-list'])
          },
          error: (error: any) => {
            this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
          }
        });
  
  }
}
