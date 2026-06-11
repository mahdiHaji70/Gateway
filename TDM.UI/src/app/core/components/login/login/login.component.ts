import { Component } from '@angular/core';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  valCheck: string[] = ['remember'];

  password!: string;
  username!: string;

  /**
   *
   */
  constructor(private localStorageService: LocalStorageService, private messageService: MessageService, private router: Router) {
  }

  submit(): void {
    if ((this.username && this.username.trim().length > 0) && (this.password && this.password.trim().length > 0))
    {
      this.localStorageService.setItem('token', 'username: ' + this.username + ', password: ' + this.password);
      this.localStorageService.setItem('username', this.username);
      this.router.navigate(['/']).then().catch();
    }
    else
      this.messageService.add({ severity: 'error', summary: 'Authentication Failed', detail: 'Fill username and password' });

  }
}
