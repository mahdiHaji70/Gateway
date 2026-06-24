import { Component, ElementRef, ViewChild } from '@angular/core';
import { LayoutService } from '../../../services/layout.service';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

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
     private localStorageService: LocalStorageService,
      private router: Router,
    private location: Location) {
  }

  signOut(): void {
    this.localStorageService.removeItem('token');
    this.localStorageService.removeItem('terminalId');
    this.localStorageService.removeItem('terminalCode');
    this.router.navigate(['/login']).then().catch();
  }

  goBack(): void{
    this.location.back();
  }
}
