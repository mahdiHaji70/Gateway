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
  @Output() change = new EventEmitter<boolean>();

  label?: string;
  selectedOption: any;
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
    this.change.emit(value);
  }
}
