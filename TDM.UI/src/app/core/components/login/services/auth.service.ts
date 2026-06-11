import { Injectable } from '@angular/core';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private localStorageService: LocalStorageService) { }

  
  isAuthenticated(): boolean {
    return !!this.localStorageService.getItem('token');
  }
  
  login(token: string): void {    
    localStorage.setItem('token', token);
  }

  logout(): void {    
    localStorage.removeItem('token');
  }
}