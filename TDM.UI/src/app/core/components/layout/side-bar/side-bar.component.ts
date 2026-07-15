import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Router } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { MenuItems } from '../../../constants/menu-items';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrl: './side-bar.component.scss',
  animations: [
    trigger('expandCollapse', [
      transition(':enter', [
        style({ height: '0', opacity: 0, visibility: 'hidden' }),
        animate('500ms ease-out', style({ height: '*', opacity: 1, visibility: 'visible' }))
      ]),
      transition(':leave', [
        style({ height: '*', opacity: 1, visibility: 'visible' }),
        animate('500ms ease-in', style({ height: '0', opacity: 0, visibility: 'hidden' }))
      ])
    ])
  ]
})
export class SideBarComponent {
  menuItems?: MenuItem[];
  username: string | null = '';
  /**
   *
   */
  constructor(public router: Router,
    private localStorageService: LocalStorageService
  ) {
    this.parentStates = [];
    this.menuItems = MenuItems;
  }

  parentStates: boolean[] = [];



  toggleParent(index: number) {
    this.parentStates[index] = !this.parentStates[index];
  }

  isParentOpen(index: number): boolean {
    return this.parentStates[index];
  }

  ngOnInit() {
    this.username = this.localStorageService.getItem('username');



  }

  onItemClick(path: string) {
    debugger
    this.router.navigate([path]).then().catch();
  }
}
