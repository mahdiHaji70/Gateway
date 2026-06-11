import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { OperationDetail } from '../models/operation-detail.model';

@Injectable()
export class OperationDetailService {

  constructor(private apiService: ApiService) { }

  getOperationDetails(): Observable<any> {
      let _url = ApiEndpoints.Operation_Detail + '/GetAll';
      return this.apiService.get(_url);
    }
  
    getVehiclesByType(vehicleType: number){
      let _url = ApiEndpoints.Get_Vehicles_By_Type + `?vehicleType=${vehicleType}`;
          return this.apiService.get(_url);
    }
  
    getById(id: string): Observable<any> {
      let _url = ApiEndpoints.Operation_Detail + `/${id}`;
      return this.apiService.get(_url);
    }
  
    postOperationDetail(operationDetail: OperationDetail): Observable<any> {
      let _url = ApiEndpoints.Operation_Detail;
      return this.apiService.post(_url, operationDetail);
    }
  
    putOperationDetail(operationDetail: OperationDetail): Observable<any> {
      let _url = ApiEndpoints.Operation_Detail;
      return this.apiService.put(_url, operationDetail);
    }
  
    deleteOperationDetail(id: string): Observable<any> {
      let _url = ApiEndpoints.Operation_Detail + `/${id}`;
      return this.apiService.delete(_url);
    }
}
