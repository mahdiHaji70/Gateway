import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrafficComponent } from './components/traffic/traffic.component';
import { BasicInformationService } from './services/basic-information.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { ConfirmationService, MessageService } from 'primeng/api';
import { SharedModule } from '../../shared/shared.module';
import { TrafficListComponent } from './components/traffic/traffic-list/traffic-list.component';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToolbarModule } from 'primeng/toolbar';
import { DeclarationTypeComponent } from './components/declaration-type/declaration-type.component';
import { DeclarationTypeListComponent } from './components/declaration-type/declaration-type-list/declaration-type-list.component';
import { BasicInformationRoutingModule } from './basic-information-routing.module';
import { TerminalComponent } from './components/terminal/terminal.component';
import { TerminalListComponent } from './components/terminal/terminal-list/terminal-list.component';
import { CountryComponent } from './components/country/country.component';
import { CountryListComponent } from './components/country/country-list/country-list.component';
import { CityComponent } from './components/city/city.component';
import { CityListComponent } from './components/city/city-list/city-list.component';
import { DropdownModule } from 'primeng/dropdown';
import { ContactComponent } from './components/contact/contact.component';
import { ContactListComponent } from './components/contact/contact-list/contact-list.component';
import { CommodityComponent } from './components/commodity/commodity.component';
import { CommodityListComponent } from './components/commodity/commodity-list/commodity-list.component';
import { PackageComponent } from './components/package/package.component';
import { PackageListComponent } from './components/package/package-list/package-list.component';
import { ContainerTypeComponent } from './components/container-type/container-type.component';
import { ContainerTypeListComponent } from './components/container-type/container-type-list/container-type-list.component';
import { ContainerSizeComponent } from './components/container-size/container-size.component';
import { ContainerSizeListComponent } from './components/container-size/container-size-list/container-size-list.component';
import { ContainerComponent } from './components/container/container.component';
import { ContainerListComponent } from './components/container/container-list/container-list.component';
import { VesselComponent } from './components/vessel/vessel.component';
import { VesselListComponent } from './components/vessel/vessel-list/vessel-list.component';
import { WagonComponent } from './components/wagon/wagon.component';
import { WagonListComponent } from './components/wagon/wagon-list/wagon-list.component';
import { TruckComponent } from './components/truck/truck.component';
import { TruckListComponent } from './components/truck/truck-list/truck-list.component';
import { OperationTypeComponent } from './components/operation-type/operation-type.component';
import { OperationTypeListComponent } from './components/operation-type/operation-type-list/operation-type-list.component';
import { PlaceTypeComponent } from './components/place-type/place-type.component';
import { PlaceTypeListComponent } from './components/place-type/place-type-list/place-type-list.component';
import { PlaceComponent } from './components/place/place.component';
import { PlaceListComponent } from './components/place/place-list/place-list.component';
import { ContainerTypeAndSizeComponent } from './components/container-type-and-size/container-type-and-size.component';
import { ContainerTypeAndSizeListComponent } from './components/container-type-and-size/container-type-and-size-list/container-type-and-size-list.component';



@NgModule({
  declarations: [
    TrafficComponent,
    TrafficListComponent,
    DeclarationTypeComponent,
    DeclarationTypeListComponent,
    TerminalComponent,
    TerminalListComponent,
    CountryComponent,
    CountryListComponent,
    CityComponent,
    CityListComponent,
    ContactComponent,
    ContactListComponent,
    CommodityComponent,
    CommodityListComponent,
    PackageComponent,
    PackageListComponent,
    ContainerTypeComponent,
    ContainerTypeListComponent,
    ContainerSizeComponent,
    ContainerSizeListComponent,
    ContainerComponent,
    ContainerListComponent,
    VesselComponent,
    VesselListComponent,
    WagonComponent,
    WagonListComponent,
    TruckComponent,
    TruckListComponent,
    OperationTypeComponent,
    OperationTypeListComponent,
    PlaceTypeComponent,
    PlaceTypeListComponent,
    PlaceComponent,
    PlaceListComponent,
    ContainerTypeAndSizeComponent,
    ContainerTypeAndSizeListComponent
  ],
  imports: [
    CommonModule,
    BasicInformationRoutingModule,
    ReactiveFormsModule,
    FormsModule,    
    ButtonModule,
    ToastModule,
    SharedModule,
    TableModule,
    ConfirmDialogModule,
    ToolbarModule,    
    
  ],
  providers: [BasicInformationService, MessageService, ConfirmationService]
})
export class BasicInformationModule { } 
