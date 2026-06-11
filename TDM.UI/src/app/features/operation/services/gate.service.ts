import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { Gate } from '../models/gate.model';
import { Observable } from 'rxjs';
import { ExitGate } from '../models/gate-exit.model';

@Injectable()
export class GateService {

  constructor(private apiService: ApiService) { }

  getGates(): Observable<any> {
    let _url = ApiEndpoints.Gate + '/GetAll';
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Gate + `/${id}`;
    return this.apiService.get(_url);
  }

  getVehiclesByType(vehicleType: number){
    let _url = ApiEndpoints.Get_Vehicles_By_Type + `?vehicleType=${vehicleType}`;
        return this.apiService.get(_url);
  }

    postGate(gate: Gate): Observable<any> {
      let _url = ApiEndpoints.Gate;
      return this.apiService.post(_url, gate);
    }
  
    putGate(gate: Gate): Observable<any> {
      let _url = ApiEndpoints.Gate;
      return this.apiService.put(_url, gate);
    }

    putExitGate(gate: ExitGate): Observable<any> {
      let _url = ApiEndpoints.Gate + '/update-exit-date';
      return this.apiService.put(_url, gate);
    }

    deleteGate(id: string): Observable<any> {
      let _url = ApiEndpoints.Gate + `/${id}`;
      return this.apiService.delete(_url);
    }
}
