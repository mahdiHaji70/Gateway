import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { ApiService } from '../../../core/services/api.service';
import { VesselLoadingPermitConfirmation } from '../models/vessel-loading-permit-confirmation.model';

@Injectable({
  providedIn: 'root'
})
export class VesselLoadingPermitService {
  constructor(private apiService: ApiService) { }

  getVesselLoadingPermit(storeReceiptId: string): Observable<any> {
    const url = ApiEndpoints.VesselLoadingPermit + `/by-store-receipt/${storeReceiptId}`;
    return this.apiService.get(url);
  }

  confirm(confirmation: VesselLoadingPermitConfirmation): Observable<any> {
    const url = ApiEndpoints.VesselLoadingPermit + '/confirm';
    return this.apiService.post(url, confirmation);
  }
}
