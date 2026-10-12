import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { StoreReceiptHead } from '../models/store-receipt-head.model';

@Injectable()
export class StoreReceiptService {

  constructor(private apiService: ApiService) { }

  getStoreReceipts(){
    let _url = ApiEndpoints.Store_Receipt + `/storeReceipts`;
    return this.apiService.get(_url);
  }

  getStoreReceiptsByDeclarationNo(declarationNo: string): Observable<any> {
    let _url = ApiEndpoints.Store_Receipt + `/storeReceipt-by-ipasDeclarationNo/${declarationNo}`;
    return this.apiService.get(_url);
  }
  
  getStoreReceiptsByIpasManifestItemId(ipasManifestItemId: string): Observable<any> {
    let _url = ApiEndpoints.Store_Receipt + `/store-receipt-by-bill-of-lading-id/${ipasManifestItemId}`;
    return this.apiService.get(_url);
  }

  getWarehouses(storeReceiptId: string): Observable<any> {
    return this.apiService.get(`${ApiEndpoints.Store_Receipt}/${storeReceiptId}/warehouses`);
  }

  sendIpasStoreAllocation(storeReceiptId: string): Observable<any> {
    return this.apiService.post(`${ApiEndpoints.Store_Receipt}/send-ipas-store-allocation/${storeReceiptId}`, {});
  }

  createStoreReceipt(storeReceipt: StoreReceiptHead) {
    let _url = ApiEndpoints.Store_Receipt + `/create-storeReceipt`;
    return this.apiService.post(_url, storeReceipt);
  }
}
