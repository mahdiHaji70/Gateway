import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { toPascalCase } from '../../utils/to-pascal-case';

@Component({
  selector: 'app-input-number',
  templateUrl: './input-number.component.html',
  styleUrl: './input-number.component.scss'
})
export class InputNumberComponent {
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
