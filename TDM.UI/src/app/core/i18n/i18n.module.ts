import { NgModule } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';

@NgModule({
  imports: [TranslatePipe],
  exports: [TranslatePipe]
})
export class I18nModule { }
