import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { Discharge } from '../models/discharge.model';

@Injectable()
export class DischargeService {

  constructor(private apiService: ApiService) { }

  getDischarges(): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges + '/GetAll';
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges + `/${id}`;
    return this.apiService.get(_url);
  }

  getGoodwayBillsByDeclarationNo(declarationNo: string): Observable<any>{
    let _url = ApiEndpoints.Terminal_Discharges + `/get_terminal_discharge_by_declaratio_no/${declarationNo}`;
    return this.apiService.get(_url);
  }

  postDischarge(discharge: Discharge): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges;
    return this.apiService.post(_url, discharge);
  }

  putDischarge(discharge: Discharge): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges;
    return this.apiService.put(_url, discharge);
  }

  deleteDischarge(id: string): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges + `/${id}`;
    return this.apiService.delete(_url);
  }
}
