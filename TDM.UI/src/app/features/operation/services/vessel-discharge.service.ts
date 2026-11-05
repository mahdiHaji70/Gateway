import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { VesselDischarge } from '../models/vessel-discharge.model';

@Injectable({
  providedIn: 'root'
})
export class VesselDischargeService {

  constructor(private apiService: ApiService) { }

  getVesselDischarges(pageNumber: number = 1, pageSize: number = 10, filters?: any): Observable<any> {
    const params: any = { pageNumber, pageSize };
    if (filters?.search) params.search = filters.search;
    if (filters?.dateFrom) params.dateFrom = this.formatDate(filters.dateFrom);
    if (filters?.dateTo) params.dateTo = this.formatDate(filters.dateTo);
    if (filters?.manifestItemId) params.manifestItemId = filters.manifestItemId;
    if (filters?.storeId) params.storeId = filters.storeId;
    if (filters?.containerId) params.containerId = filters.containerId;
    return this.apiService.get(ApiEndpoints.Vessel_Discharges, params);
  }

  private formatDate(date: Date): string {
    return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
  }

  getById(id: string): Observable<any> {
    return this.apiService.get(`${ApiEndpoints.Vessel_Discharges}/${id}`);
  }

  getByManifestItemId(manifestItemId: string): Observable<any> {
    return this.apiService.get(`${ApiEndpoints.Vessel_Discharges_By_Manifest_Item}/${manifestItemId}`);
  }

  sendToIpas(manifestItemId: string): Observable<any> {
    return this.apiService.post(`${ApiEndpoints.Vessel_Discharges}/send-Vesseldischarges-to-ipas/${manifestItemId}`, {});
  }

  postDischarge(discharge: VesselDischarge): Observable<any> {
    return this.apiService.post(ApiEndpoints.Vessel_Discharges, discharge);
  }

  putDischarge(discharge: VesselDischarge): Observable<any> {
    return this.apiService.put(ApiEndpoints.Vessel_Discharges, discharge);
  }

  deleteDischarge(id: string): Observable<any> {
    return this.apiService.delete(`${ApiEndpoints.Vessel_Discharges}/${id}`);
  }
}
