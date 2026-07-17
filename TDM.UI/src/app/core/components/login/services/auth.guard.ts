import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private authService: AuthService, 
    private router: Router,
  private localStorageService: LocalStorageService) {}

  canActivate(): boolean {
    if (this.authService.isAuthenticated()) {
      return true; 
    } else {
      this.localStorageService.removeItem('token');
      this.localStorageService.removeItem('terminalId');
      this.localStorageService.removeItem('terminalCode');
      this.localStorageService.removeItem('portCode');
      this.router.navigate(['/login']); 
      return false;
    }
  }
}