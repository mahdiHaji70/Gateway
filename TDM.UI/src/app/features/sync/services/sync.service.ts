import { Injectable } from '@angular/core';
import { LocalStorageService } from '../../../shared/services/local-storage.service';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class SyncService {

  constructor(private localStorageService: LocalStorageService,
    private apiService: ApiService
  ) { }

  getGoodwayBills() {
    var terminalcode = this.localStorageService.getItem('terminalCode');
    var portcode = this.localStorageService.getItem('portCode');
    let _url = ApiEndpoints.Goodway_Bill;
    return this.apiService.get(_url, { TerminalCode: terminalcode, PortCode: portcode });
  }

  getDischargePermits() {
    var terminalcode = this.localStorageService.getItem('terminalCode');
    var portcode = this.localStorageService.getItem('portCode');
    let _url = ApiEndpoints.Discharge_Permit;
    return this.apiService.get(_url, { TerminalCode: terminalcode, PortCode: portcode });
  }

  getIssueRequests() {
    var terminalcode = this.localStorageService.getItem('terminalCode');
    var portcode = this.localStorageService.getItem('portCode');
    let _url = ApiEndpoints.Issue_Request;
    return this.apiService.get(_url, { TerminalCode: terminalcode, PortCode: portcode });
  }

  getVoyages() {
    var terminalcode = this.localStorageService.getItem('terminalCode');
    var portcode = this.localStorageService.getItem('portCode');
    let _url = ApiEndpoints.Voyages;
    return this.apiService.get(_url, { TerminalCode: terminalcode, PortCode: portcode, PageIndex: 0, PageSize: 100 });
  }

  getStoreReceipts() {
    var terminalcode = this.localStorageService.getItem('terminalCode');
    var portcode = this.localStorageService.getItem('portCode');
    let _url = ApiEndpoints.Store_Receipt;
    return this.apiService.get(_url, { TerminalCode: terminalcode, PortCode: portcode, PageIndex: 0, PageSize: 100 });
  }
}
