import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { StoreReceiptRequest } from '../models/store-receipt-request.model';

@Injectable()
export class StoreReceiptRequestService {

  constructor(private apiService: ApiService) { }

  getFinalInventoryForDeclaration(declarationId: string) {
    let _url = ApiEndpoints.Store_Receipt_Request + '/GetFinalInventoryForDeclarationGroupDto' + `?declarationId=${declarationId}`;
    return this.apiService.get(_url);
  }

  saveStoreReceiptRequest(storeReceiptRequest: StoreReceiptRequest) {
    let _url = ApiEndpoints.Store_Receipt_Request;
    return this.apiService.post(_url, storeReceiptRequest);
  }
}
