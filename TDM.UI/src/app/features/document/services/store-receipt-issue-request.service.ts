import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class StoreReceiptIssueRequestService {

  constructor(private apiService: ApiService) { }

  getByIpasDeclarationNo(ipasDeclarationNo: string){
    let _url = ApiEndpoints.Store_Receipt_Issue_Request +
     `/issueRequest-storeReceipt-by-ipasDeclarationNo/${ipasDeclarationNo}`;
        return this.apiService.get(_url);
  }
}
