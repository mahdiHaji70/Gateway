import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { OperationPlanning } from '../models/operation-planning.model';

@Injectable()
export class OperationPlanningService {

  constructor(private apiService: ApiService) { }

  getOperationPlannings(): Observable<any> {
    let _url = ApiEndpoints.Operation_Planning + '/GetAll';
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Operation_Planning + `/${id}`;
    return this.apiService.get(_url);
  }

  postOperationPlanning(operationPlanning: OperationPlanning): Observable<any> {
    let _url = ApiEndpoints.Operation_Planning;
    return this.apiService.post(_url, operationPlanning);
  }

  putOperationPlanning(operationPlanning: OperationPlanning): Observable<any> {
    let _url = ApiEndpoints.Operation_Planning;
    return this.apiService.put(_url, operationPlanning);
  }

  deleteOperationPlanning(id: string): Observable<any> {
    let _url = ApiEndpoints.Operation_Planning + `/${id}`;
    return this.apiService.delete(_url);
  }
}
