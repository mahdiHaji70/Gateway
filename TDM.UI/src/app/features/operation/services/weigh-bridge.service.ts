import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { WeightBridge } from '../models/weight-bridge.model';

@Injectable()
export class WeighBridgeService {

  constructor(private apiService: ApiService) { }

  getWeighBridges(): Observable<any> {
    let _url = ApiEndpoints.Weight_Bridge + '/GetAll';
    return this.apiService.get(_url);
  }

  getVehiclesByType(vehicleType: number){
    let _url = ApiEndpoints.Get_Vehicles_By_Type + `?vehicleType=${vehicleType}`;
        return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Weight_Bridge + `/${id}`;
    return this.apiService.get(_url);
  }

  postWeighBridge(weighBridge: WeightBridge): Observable<any> {
    let _url = ApiEndpoints.Weight_Bridge;
    return this.apiService.post(_url, weighBridge);
  }

  putWeighBridge(weighBridge: WeightBridge): Observable<any> {
    let _url = ApiEndpoints.Weight_Bridge;
    return this.apiService.put(_url, weighBridge);
  }

  deleteWeightBridge(id: string): Observable<any> {
    let _url = ApiEndpoints.Weight_Bridge + `/${id}`;
    return this.apiService.delete(_url);
  }
}
