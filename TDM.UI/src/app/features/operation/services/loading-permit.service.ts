import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { LoadingPermitConfirmation } from '../models/loading-permit-confirmation.model';

@Injectable({
  providedIn: 'root'
})
export class LoadingPermitService {

  constructor(private apiService: ApiService) { }

  getLoadingPermits(storeReceiptId: string): Observable<any> {
    let _url = ApiEndpoints.LoadingPermit + `/by-store-receipt/${storeReceiptId}`;
    return this.apiService.get(_url);
  }

  confirm(loadingPermitConfirmation: LoadingPermitConfirmation) {
    let _url = ApiEndpoints.LoadingPermit + `/confirm`;
    return this.apiService.post(_url, loadingPermitConfirmation);
  }
}
