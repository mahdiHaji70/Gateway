import { Component, Input } from '@angular/core';
import { toPascalCase } from '../../utils/to-pascal-case';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-en-calender',
  templateUrl: './en-calender.component.html',
  styleUrl: './en-calender.component.scss'
})
export class EnCalenderComponent {
  @Input() formGroup!: FormGroup;
  @Input() controlName: string = '';
  @Input() required: boolean = false;
  @Input() showTime: boolean = false;
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
