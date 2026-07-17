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
    const token = this.localStorageService.getItem('token');

    if (!token) {
      return false;
    }

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const exp = payload.exp;

      if (!exp) {
        return false;
      }

      const nowInSeconds = Math.floor(Date.now() / 1000);
      return exp > nowInSeconds;
    } catch (error) {
      return false;
    }
  }


  login(nationalid: string, password: string): Observable<any> {
    let _url = ApiEndpoints.BASE_AUTH_URL + '/login';
    return this.apiService.post(_url, { nationalId: nationalid, password: password });
  }

  getCurrentTerminal() {
    let _url = ApiEndpoints.BASE_URL + '/UsersTerminal/GetCurrentUserTerminal';
    return this.apiService.get(_url);
  }

  logout(): void {
    localStorage.removeItem('token');
  }
}
