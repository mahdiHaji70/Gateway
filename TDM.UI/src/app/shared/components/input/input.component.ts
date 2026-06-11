import { Component, Input } from '@angular/core';
import { toPascalCase } from '../../utils/to-pascal-case'
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrl: './input.component.scss'
})
export class InputComponent {
  @Input() formGroup!: FormGroup;
  @Input() controlName: string = '';
  @Input() required: boolean = false;
  label?: string;
  /**
   *
   */
  constructor() {
  }

  ngOnInit(){
    this.label = toPascalCase(this.controlName!);

  }
}
