import { Component } from '@angular/core';
import { showApiError } from '../../../../shared/services/api-error-handler.service';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { TranslateService } from '@ngx-translate/core';
import { LanguageService } from '../../../services/language.service';

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
    private authService: AuthService,
    private translate: TranslateService,
    public languageService: LanguageService) {
  }

  submit() {
    if ((this.nationalId && (this.nationalId.trim().length == 10 || this.nationalId.trim().length == 11))
      && (this.password && this.password.trim().length > 0)) {
      this.authService.login(this.nationalId, this.password).subscribe({
        next: (res: any) => {
          this.authService.storeTokens(res);
          this.authService.getCurrentTerminal().subscribe({
            next: (currentTerminalres: any) => {
              this.localStorageService.setItem('terminalId', currentTerminalres.data.terminalId);
              this.localStorageService.setItem('terminalCode', currentTerminalres.data.terminalCode);
              this.localStorageService.setItem('portCode', currentTerminalres.data.terminalPortCode);
              this.router.navigate(['/']).then().catch();
            },
            error: (failRes: any) => {
              showApiError(this.messageService, failRes);
            }
          });

        },
        error: (failRes: any) => {
          showApiError(this.messageService, failRes);
        }
      });
    }
    else
      this.messageService.add({
        severity: 'error',
        summary: this.translate.instant('login.authenticationFailed'),
        detail: this.translate.instant('login.fillCredentials')
      });
  }
}
