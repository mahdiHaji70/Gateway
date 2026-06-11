import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopBarComponent } from './top-bar/top-bar.component';
import { FooterComponent } from './footer/footer.component';
import { BaseLayoutComponent } from './base-layout/base-layout.component';
import { RouterModule } from '@angular/router';
import { LayoutService } from '../../services/layout.service';
import {PanelMenuModule} from 'primeng/panelmenu';
import { SideBarComponent } from './side-bar/side-bar.component';
import { LocalStorageService } from '../../../shared/services/local-storage.service';
import { ButtonModule } from 'primeng/button';
import { TitleBarComponent } from './title-bar/title-bar.component';


@NgModule({
  declarations: [
    TopBarComponent,
    FooterComponent,
    BaseLayoutComponent,
    SideBarComponent,
    TitleBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    PanelMenuModule,
    ButtonModule
  ],
  exports: [
    FooterComponent,
    TopBarComponent
  ],
  providers: [
    LayoutService
  ]
})
export class LayoutModule { }
