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

  getVesselDischarges(): Observable<any> {
    return this.apiService.get(ApiEndpoints.Vessel_Discharges);
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
