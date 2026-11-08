import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { animate, style, transition, trigger } from '@angular/animations';
import { LocalStorageService } from '../../../../shared/services/local-storage.service';
import { MenuItems, MenuLabelKeys } from '../../../constants/menu-items';
import { LayoutService } from '../../../services/layout.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrl: './side-bar.component.scss',
  animations: [
    trigger('expandCollapse', [
      transition(':enter', [
        style({ height: '0', opacity: 0, visibility: 'hidden' }),
        animate('180ms ease-out', style({ height: '*', opacity: 1, visibility: 'visible' }))
      ]),
      transition(':leave', [
        style({ height: '*', opacity: 1, visibility: 'visible' }),
        animate('150ms ease-in', style({ height: '0', opacity: 0, visibility: 'hidden' }))
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
  constructor(
    private router: Router,
    private localStorageService: LocalStorageService,
    private layoutService: LayoutService
  ) {
    this.parentStates = [];
    this.menuItems = MenuItems;
  }

  parentStates: boolean[] = [];



  toggleParent(index: number): void {
    this.parentStates[index] = !this.parentStates[index];
  }

  isParentOpen(index: number): boolean {
    return this.parentStates[index] ?? false;
  }

  menuLabelKey(label?: string): string {
    return label ? MenuLabelKeys[label] ?? label : '';
  }

  ngOnInit(): void {
    this.username = this.localStorageService.getItem('username');
  }

  closeMenu(): void {
    this.layoutService.closeMobileMenu();
  }

  onItemClick(path?: string): void {
    if (!path) {
      return;
    }

    void this.router.navigate([path]).catch(() => undefined);
    this.closeMenu();
  }

  isRouteActive(path?: string): boolean {
    if (!path) {
      return false;
    }

    const currentPath = this.router.url.split(/[?#]/, 1)[0];
    const targetPath = `/${path}`;
    return currentPath === targetPath || currentPath.startsWith(`${targetPath}/`);
  }

  goToDashboard(): void {
    void this.router.navigate(['/']).catch(() => undefined);
    this.closeMenu();
  }
}
