import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { toPascalCase } from '../../utils/to-pascal-case';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.scss'
})
export class CheckboxComponent {
  @Input() formGroup!: FormGroup;
  @Input() controlName: string = '';
  @Input() required: boolean = false;
  @Output() change = new EventEmitter<boolean>();
  label?: string;
  /**
   *
   */
  constructor() {
  }

  ngOnInit() {
    this.label = toPascalCase(this.controlName!);
  }

  onChange(event: any) {
    const value = event?.checked ?? event?.target?.checked;
    this.change.emit(value);
  }
}
