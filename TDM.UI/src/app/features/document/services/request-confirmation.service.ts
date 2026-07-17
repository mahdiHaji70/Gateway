import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { RequestConfirmation } from '../models/request-confirmation.model';
import { LocalStorageService } from '../../../shared/services/local-storage.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class RequestConfirmationService {

  constructor(private apiService: ApiService, 
    private localStorageService: LocalStorageService) { }

  confirmRequest(requestId: string, isApproved: boolean,description: string = ''){
    var terminalCode = this.localStorageService.getItem('terminalCode');
    var reqeustConfirmation = new RequestConfirmation(terminalCode!, requestId, isApproved, description);
    var _url = ApiEndpoints.Store_Receipt_Issue_Request + '/issue-request-confirmation';
    return this.apiService.post(_url, reqeustConfirmation);
    
  }
}
