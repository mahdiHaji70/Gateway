import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { StoreReceiptHead } from '../models/store-receipt-head.model';

@Injectable()
export class StoreReceiptService {

  constructor(private apiService: ApiService) { }

  getStoreReceiptsByDeclarationNo(declarationNo: string): Observable<any> {
    let _url = ApiEndpoints.Store_Receipt + `/storeReceipt-by-ipasDeclarationNo/${declarationNo}`;
    return this.apiService.get(_url);
  }
  
  getStoreReceiptsByIpasManifestItemId(ipasManifestItemId: string): Observable<any> {
    let _url = ApiEndpoints.Store_Receipt + `/store-receipt-by-bill-of-lading-id/${ipasManifestItemId}`;
    return this.apiService.get(_url);
  }

  createStoreReceipt(storeReceipt: StoreReceiptHead) {
    let _url = ApiEndpoints.Store_Receipt + `/create-storeReceipt`;
    return this.apiService.post(_url, storeReceipt);
  }
}
