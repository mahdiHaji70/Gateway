import { Component, Input } from '@angular/core';
import { toPascalCase } from '../../utils/to-pascal-case';
import { FormControl, FormGroup } from '@angular/forms';
import { LanguageService } from '../../../core/services/language.service';

@Component({
  selector: 'app-calender',
  templateUrl: './en-calender.component.html',
  styleUrl: './en-calender.component.scss'
})
export class EnCalenderComponent {
  constructor(readonly languageService: LanguageService) { }

  @Input() formGroup!: FormGroup;
  @Input() controlName: string = '';
  @Input() required: boolean = false;
  @Input() showTime: boolean = false;
  @Input() labelKey?: string;
  label?: string;

  get control(): FormControl {
    return this.formGroup.get(this.controlName) as FormControl;
  }

  ngOnInit(){
    this.label = toPascalCase(this.controlName!);

  }
}
