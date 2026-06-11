import { Component } from '@angular/core';
import { AuthService } from './core/components/login/services/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'CargoTech';

  /**
   *
   */
  constructor(private authService: AuthService) {        
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }
}
