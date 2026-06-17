import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrafficComponent } from './components/traffic/traffic.component';
import { TrafficListComponent } from './components/traffic/traffic-list/traffic-list.component';
import { DeclarationTypeComponent } from './components/declaration-type/declaration-type.component';
import { DeclarationTypeListComponent } from './components/declaration-type/declaration-type-list/declaration-type-list.component';
import { TerminalListComponent } from './components/terminal/terminal-list/terminal-list.component';
import { TerminalComponent } from './components/terminal/terminal.component';
import { CountryComponent } from './components/country/country.component';
import { CountryListComponent } from './components/country/country-list/country-list.component';
import { CityComponent } from './components/city/city.component';
import { CityListComponent } from './components/city/city-list/city-list.component';
import { ContactListComponent } from './components/contact/contact-list/contact-list.component';
import { ContactComponent } from './components/contact/contact.component';
import { CommodityListComponent } from './components/commodity/commodity-list/commodity-list.component';
import { CommodityComponent } from './components/commodity/commodity.component';
import { PackageListComponent } from './components/package/package-list/package-list.component';
import { PackageComponent } from './components/package/package.component';
import { ContainerTypeListComponent } from './components/container-type/container-type-list/container-type-list.component';
import { ContainerTypeComponent } from './components/container-type/container-type.component';
import { ContainerSizeListComponent } from './components/container-size/container-size-list/container-size-list.component';
import { ContainerSizeComponent } from './components/container-size/container-size.component';
import { ContainerListComponent } from './components/container/container-list/container-list.component';
import { ContainerComponent } from './components/container/container.component';
import { VesselComponent } from './components/vessel/vessel.component';
import { VesselListComponent } from './components/vessel/vessel-list/vessel-list.component';
import { WagonListComponent } from './components/wagon/wagon-list/wagon-list.component';
import { WagonComponent } from './components/wagon/wagon.component';
import { TruckListComponent } from './components/truck/truck-list/truck-list.component';
import { TruckComponent } from './components/truck/truck.component';
import { OperationTypeListComponent } from './components/operation-type/operation-type-list/operation-type-list.component';
import { OperationTypeComponent } from './components/operation-type/operation-type.component';
import { PlaceTypeListComponent } from './components/place-type/place-type-list/place-type-list.component';
import { PlaceTypeComponent } from './components/place-type/place-type.component';
import { PlaceListComponent } from './components/place/place-list/place-list.component';
import { PlaceComponent } from './components/place/place.component';
import { ContainerTypeAndSizeComponent } from './components/container-type-and-size/container-type-and-size.component';
import { ContainerTypeAndSizeListComponent } from './components/container-type-and-size/container-type-and-size-list/container-type-and-size-list.component';

const routes: Routes = [  
  { path: 'traffic-list', component: TrafficListComponent},
  { path: 'traffic', component: TrafficComponent},
  { path: 'traffic/:id', component: TrafficComponent},

  { path: 'declaration-type-list', component: DeclarationTypeListComponent},
  { path: 'declaration-type', component: DeclarationTypeComponent},
  { path: 'declaration-type/:id', component: DeclarationTypeComponent},

  { path: 'terminal-list', component: TerminalListComponent},
  { path: 'terminal', component: TerminalComponent},
  { path: 'terminal/:id', component: TerminalComponent},

  { path: 'country-list', component: CountryListComponent},
  { path: 'country', component: CountryComponent},
  { path: 'country/:id', component: CountryComponent},

  { path: 'city-list', component: CityListComponent},
  { path: 'city', component: CityComponent},
  { path: 'city/:id', component: CityComponent},

  { path: 'contact-list', component: ContactListComponent},
  { path: 'contact', component: ContactComponent},
  { path: 'contact/:id', component: ContactComponent},

  { path: 'commodity-list', component: CommodityListComponent},
  { path: 'commodity', component: CommodityComponent},
  { path: 'commodity/:id', component: CommodityComponent},

  { path: 'package-list', component: PackageListComponent},
  { path: 'package', component: PackageComponent},
  { path: 'package/:id', component: PackageComponent},

  { path: 'container-list', component: ContainerListComponent},
  { path: 'container', component: ContainerComponent},
  { path: 'container/:id', component: ContainerComponent},

  { path: 'container-type-list', component: ContainerTypeListComponent},
  { path: 'container-type', component: ContainerTypeComponent},
  { path: 'container-type/:id', component: ContainerTypeComponent},

  { path: 'container-type-and-size-list', component: ContainerTypeAndSizeListComponent},
  { path: 'container-type-and-size', component: ContainerTypeAndSizeComponent},
  { path: 'container-type-and-size/:id', component: ContainerTypeAndSizeComponent},

  { path: 'container-size-list', component: ContainerSizeListComponent},
  { path: 'container-size', component: ContainerSizeComponent},
  { path: 'container-size/:id', component: ContainerSizeComponent},

  { path: 'vessel-list', component: VesselListComponent},
  { path: 'vessel', component: VesselComponent},
  { path: 'vessel/:id', component: VesselComponent},

  { path: 'wagon-list', component: WagonListComponent},
  { path: 'wagon', component: WagonComponent},
  { path: 'wagon/:id', component: WagonComponent},

  { path: 'truck-list', component: TruckListComponent},
  { path: 'truck', component: TruckComponent},
  { path: 'truck/:id', component: TruckComponent},

  { path: 'operation-type-list', component: OperationTypeListComponent},
  { path: 'operation-type', component: OperationTypeComponent},
  { path: 'operation-type/:id', component: OperationTypeComponent},

  { path: 'place-type-list', component: PlaceTypeListComponent},
  { path: 'place-type', component: PlaceTypeComponent},
  { path: 'place-type/:id', component: PlaceTypeComponent},

  { path: 'place-list', component: PlaceListComponent},
  { path: 'place', component: PlaceComponent},
  { path: 'place/:id', component: PlaceComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BasicInformationRoutingModule { }
