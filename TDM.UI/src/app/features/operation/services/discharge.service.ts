import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { Discharge } from '../models/discharge.model';

@Injectable()
export class DischargeService {

  constructor(private apiService: ApiService) { }

  getDischarges(pageNumber: number = 1, pageSize: number = 10, filters?: any): Observable<any> {
    const params: any = { pageNumber, pageSize };
    if (filters?.search) params.search = filters.search;
    if (filters?.dateFrom) params.dateFrom = this.formatDate(filters.dateFrom);
    if (filters?.dateTo) params.dateTo = this.formatDate(filters.dateTo);
    if (filters?.declarationItemId) params.declarationItemId = filters.declarationItemId;
    if (filters?.storeId) params.storeId = filters.storeId;
    return this.apiService.get(ApiEndpoints.Terminal_Discharges, params);
  }

  private formatDate(date: Date): string {
    return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges + `/${id}`;
    return this.apiService.get(_url);
  }

  getGoodwayBillsByDeclarationNo(declarationNo: string): Observable<any> {
    let _url = ApiEndpoints.Terminal_Discharges + `/request-goodwayBill-by-ipasDeclarationNo/${declarationNo}`;
    return this.apiService.get(_url);
  }

  getDischargesForSend(id: string) {
    let _url = ApiEndpoints.Terminal_Discharges + `/request-terminaldischarge-id`
    return this.apiService.get(_url, { declarationId: id });
  }

  sendDischarges(declarationId: string): Observable<any>{
    let _url = ApiEndpoints.Terminal_Discharges + `/send-to-ipas-terminaldischarge-by-id/${declarationId}`;
    return this.apiService.post(_url, {});
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
