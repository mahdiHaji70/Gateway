import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { Observable } from 'rxjs';
import { CargoArrival } from '../models/cargo-arrival.model';

@Injectable()
export class CargoArrivalService {

  constructor(private apiService: ApiService) { }


    getCargoArrivals(): Observable<any> {
      let _url = ApiEndpoints.Cargo_Arrival_Declaration + '/GetAll';
      return this.apiService.get(_url);
    }
  
    getById(id: string): Observable<any> {
      let _url = ApiEndpoints.Cargo_Arrival_Declaration + `/${id}`;
      return this.apiService.get(_url);
    }
  
    postCargoArrival(cargoArrivalDeclaration: CargoArrival): Observable<any> {
      let _url = ApiEndpoints.Cargo_Arrival_Declaration;
      return this.apiService.post(_url, cargoArrivalDeclaration);
    }
  
    putCargoArrival(cargoArrivalDeclaration: CargoArrival): Observable<any> {
      let _url = ApiEndpoints.Cargo_Arrival_Declaration;
      return this.apiService.put(_url, cargoArrivalDeclaration);
    }
  
    deleteCargoArrival(id: string): Observable<any> {
      let _url = ApiEndpoints.Cargo_Arrival_Declaration + `/${id}`;
      return this.apiService.delete(_url);
    }

    getVehiclesByType(vehicleType: number){
      let _url = ApiEndpoints.Get_Vehicles_By_Type + `?vehicleType=${vehicleType}`;
          return this.apiService.get(_url);
    }
}
