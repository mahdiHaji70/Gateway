import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { StoreReceiptHead } from '../models/store-receipt-head.model';

@Injectable()
export class StoreReceiptService {

  constructor(private apiService: ApiService) { }

  getStoreReceipts(pageNumber: number = 1, pageSize: number = 10, filters?: any){
    const params: any = { pageNumber, pageSize };
    if (filters?.search) params.search = filters.search;
    if (filters?.dateFrom) params.dateFrom = this.formatDate(filters.dateFrom);
    if (filters?.dateTo) params.dateTo = this.formatDate(filters.dateTo);
    if (filters?.consigneeId) params.consigneeId = filters.consigneeId;
    if (filters?.consigneeRepId) params.consigneeRepId = filters.consigneeRepId;
    if (filters?.trafficId) params.trafficId = filters.trafficId;
    if (filters?.cargoTypeId) params.cargoTypeId = filters.cargoTypeId;
    if (filters?.arrivalTypeCode) params.arrivalTypeCode = filters.arrivalTypeCode;
    return this.apiService.get(`${ApiEndpoints.Store_Receipt}/storeReceipts`, params);
  }

  private formatDate(date: Date): string {
    return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
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
