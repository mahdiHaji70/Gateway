import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class StoreReceiptService {

  constructor(private apiService: ApiService) { }

  getRequestsByDeclarationId(declarationId: string): Observable<any> {
    let _url = ApiEndpoints.Store_Receipt_Request + `/GetByDeclarationId/${declarationId}`;
    return this.apiService.get(_url);
  }

  createStoreReceiptByRequestId(requestId: string) {
    let _url = ApiEndpoints.Store_Receipt + `/CreateByRequestId/${requestId}`;
    return this.apiService.post(_url, null);
  }
}
