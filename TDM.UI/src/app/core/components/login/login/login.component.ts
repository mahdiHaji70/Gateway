import { Component } from '@angular/core';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  valCheck: string[] = ['remember'];

  password!: string;
  nationalId!: string;

  /**
   *
   */
  constructor(private localStorageService: LocalStorageService,
    private messageService: MessageService,
    private router: Router,
    private authService: AuthService) {
  }

  submit() {
    if ((this.nationalId && (this.nationalId.trim().length == 10 || this.nationalId.trim().length == 11))
      && (this.password && this.password.trim().length > 0)) {
      this.authService.login(this.nationalId, this.password).subscribe({
        next: (res: any) => {
          this.localStorageService.setItem('token', res.accessToken);
          this.authService.getCurrentTerminal().subscribe({
            next: (currentTerminalres: any) => {
              this.localStorageService.setItem('terminalId', currentTerminalres.data.terminalId);
              this.localStorageService.setItem('terminalCode', currentTerminalres.data.terminalCode);
              this.localStorageService.setItem('portCode', currentTerminalres.data.terminalPortCode);
              this.router.navigate(['/']).then().catch();
            },
            error: (failRes: any) => {
              this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error.Message });
            }
          });

        },
        error: (failRes: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error });
        }
      });
    }
    else
      this.messageService.add({ severity: 'error', summary: 'Authentication Failed', detail: 'Fill national Id and password correctly' });
  }
}
