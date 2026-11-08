import { Component, ElementRef, ViewChild } from '@angular/core';
import { LayoutService } from '../../../services/layout.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AuthService } from '../../login/services/auth.service';
import { LanguageService } from '../../../services/language.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrl: './top-bar.component.scss'
})
export class TopBarComponent {


  @ViewChild('menubutton') menuButton!: ElementRef;

  @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

  @ViewChild('topbarmenu') menu!: ElementRef;
  /**
   *
   */
  constructor(public layoutService: LayoutService,
      private router: Router,
      private location: Location,
      private authService: AuthService,
      public languageService: LanguageService) {
  }

  signOut(): void {
    this.authService.logout().subscribe({
      next: () => this.router.navigate(['/login']).then().catch(),
      error: () => this.router.navigate(['/login']).then().catch()
    });
  }

  toggleLanguage(): void {
    this.languageService.toggleLanguage();
    this.layoutService.state.profileSidebarVisible = false;
  }

  goBack(): void{
    this.location.back();
  }
}
