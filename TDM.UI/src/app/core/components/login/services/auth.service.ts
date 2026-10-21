import { Injectable } from '@angular/core';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { ApiService } from '../../../services/api.service';
import { ApiEndpoints } from '../../../constants/api-endpoints';
import { MessageService } from 'primeng/api';
import { Observable, of } from 'rxjs';
import { finalize } from 'rxjs/operators';

export interface TokenResponse {
  accessToken: string;
  refreshToken: string;
  accessTokenExpiresAt: string;
  refreshTokenExpiresAt: string;
}

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
      return !!this.getRefreshToken();
    }

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const exp = payload.exp;

      if (!exp) {
        return false;
      }

      const nowInSeconds = Math.floor(Date.now() / 1000);
      return exp > nowInSeconds || !!this.getRefreshToken();
    } catch (error) {
      return !!this.getRefreshToken();
    }
  }


  login(nationalid: string, password: string): Observable<any> {
    let _url = ApiEndpoints.BASE_AUTH_URL + '/login';
    return this.apiService.post(_url, { nationalId: nationalid, password: password });
  }

  refreshToken(): Observable<TokenResponse> {
    const url = ApiEndpoints.BASE_AUTH_URL + '/refresh';
    return this.apiService.post<TokenResponse>(url, {
      refreshToken: this.getRefreshToken()
    });
  }

  storeTokens(tokens: TokenResponse): void {
    this.localStorageService.setItem('token', tokens.accessToken);
    this.localStorageService.setItem('refreshToken', tokens.refreshToken);
  }

  getAccessToken(): string | null {
    return this.localStorageService.getItem('token');
  }

  getRefreshToken(): string | null {
    return this.localStorageService.getItem('refreshToken');
  }

  clearSession(): void {
    this.localStorageService.removeItem('token');
    this.localStorageService.removeItem('refreshToken');
    this.localStorageService.removeItem('terminalId');
    this.localStorageService.removeItem('terminalCode');
    this.localStorageService.removeItem('portCode');
  }

  getCurrentTerminal() {
    let _url = ApiEndpoints.BASE_URL + '/UsersTerminal/GetCurrentUserTerminal';
    return this.apiService.get(_url);
  }

  logout(): Observable<void> {
    const refreshToken = this.getRefreshToken();
    if (!refreshToken) {
      this.clearSession();
      return of(void 0);
    }

    const url = ApiEndpoints.BASE_AUTH_URL + '/logout';
    return this.apiService.post<void>(url, { refreshToken }).pipe(
      finalize(() => this.clearSession())
    );
  }
}
