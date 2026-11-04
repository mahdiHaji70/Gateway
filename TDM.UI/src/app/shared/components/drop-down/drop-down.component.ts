import { Component, EventEmitter, input, Input, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { toPascalCase } from '../../utils/to-pascal-case';

@Component({
  selector: 'app-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrl: './drop-down.component.scss'
})
export class DropDownComponent {
  @Input() formGroup!: FormGroup;
  @Input() controlName: string = '';
  @Input() options?: any[];
  @Input() required: boolean = false;
  @Input() optionLabel: string = 'name';
  @Output() selectionChange = new EventEmitter<any>();
  @Output() filterChange = new EventEmitter<string>();

  label?: string;
  selectedOption: any;
  filterValue: string = '';
  /**
   *
   */
  constructor() {
  }

  ngOnInit() {
    this.label = toPascalCase(this.controlName!);
  }

  selectOption(item: any) {
  }

  onChange(event: any) { 
    const value = event?.value ?? event?.target?.value;
    this.selectionChange.emit(value);
  }

  customFilterFunction(event: Event, options: any) {
    this.filterValue = (event.target as HTMLInputElement).value;
    options?.filter?.(event);
    this.filterChange.emit(this.filterValue);
  }
  resetFunction(options: any) {
    this.filterValue = '';
    options?.reset?.();
    this.filterChange.emit('');
  }
}
