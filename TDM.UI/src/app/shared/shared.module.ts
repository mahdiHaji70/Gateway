import { NgModule } from '@angular/core';
import { LocalStorageService } from './services/local-storage.service';
import { InputComponent } from './components/input/input.component';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropDownComponent } from './components/drop-down/drop-down.component';
import { DropdownModule } from 'primeng/dropdown';
import { EnCalenderComponent } from './components/en-calender/en-calender.component';
import { CalendarModule } from 'primeng/calendar';
import { TableModule } from 'primeng/table';
import { InputNumberComponent } from './components/input-number/input-number.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { CheckboxComponent } from './components/checkbox/checkbox.component';
import { CheckboxModule } from 'primeng/checkbox';
import { I18nModule } from '../core/i18n/i18n.module';
import { QeydarDatePickerModule } from '@qeydar/datepicker';
import { TableCellOverflowTooltipComponent } from './components/table-cell-overflow-tooltip/table-cell-overflow-tooltip.component';


@NgModule({
  providers: [
    LocalStorageService
  ],
  declarations: [
    InputComponent,
    DropDownComponent,
    EnCalenderComponent,
    InputNumberComponent,
    CheckboxComponent
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    InputTextModule,
    DropdownModule,
    CalendarModule,
    TableModule,
    InputNumberModule,
    CheckboxModule,
    I18nModule,
    QeydarDatePickerModule,
    TableCellOverflowTooltipComponent
  ],
  exports: [InputComponent, DropDownComponent, EnCalenderComponent, InputNumberComponent, CheckboxComponent, TableCellOverflowTooltipComponent]
})
export class SharedModule { }
