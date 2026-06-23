import { Injectable } from '@angular/core';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { ApiService } from '../../../services/api.service';
import { ApiEndpoints } from '../../../constants/api-endpoints';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private localStorageService: LocalStorageService,    
    private apiService: ApiService
  ) { }


  isAuthenticated(): boolean {
    return !!this.localStorageService.getItem('token');
  }

  login(nationalid: string, password: string): Observable<any> {
    let _url = ApiEndpoints.BASE_AUTH_URL + '/login';
    return this.apiService.post(_url, { nationalId: nationalid, password: password });
  }

  getCurrentTerminal(){
    let _url = ApiEndpoints.BASE_URL + '/UsersTerminal/GetCurrentUserTerminal';
    return this.apiService.get(_url);
  }

  logout(): void {
    localStorage.removeItem('token');
  }
}
