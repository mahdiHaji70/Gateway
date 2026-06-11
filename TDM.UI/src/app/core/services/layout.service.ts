import { Injectable, effect, signal } from '@angular/core';
import { AppConfig } from '../constants/app-config';
import { Subject } from 'rxjs';
import { LayoutState } from '../constants/layout-state';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {
  _config: AppConfig = {
    ripple: false,
    inputStyle: 'outlined',
    menuMode: 'static',
    colorScheme: 'light',
    theme: 'lara-light-indigo',
    scale: 14,
  };

  config = signal<AppConfig>(this._config);

  state: LayoutState = {
    staticMenuDesktopInactive: false,
    overlayMenuActive: false,
    profileSidebarVisible: false,
    configSidebarVisible: false,
    staticMenuMobileActive: false,
    menuHoverActive: false,
  };

  private overlayOpen = new Subject<any>();

  constructor() {
    effect(() => {
      const config = this.config();
    });
  }


  onMenuToggle() {
    if (this.isOverlay()) {
      this.state.overlayMenuActive = !this.state.overlayMenuActive;
      if (this.state.overlayMenuActive) {
        this.overlayOpen.next(null);
      }
    }
    if (this.isDesktop()) {
      this.state.staticMenuDesktopInactive =
        !this.state.staticMenuDesktopInactive;
    } else {
      this.state.staticMenuMobileActive =
        !this.state.staticMenuMobileActive;

      if (this.state.staticMenuMobileActive) {
        this.overlayOpen.next(null);
      }
    }
  }


  showProfileSidebar() {
    this.state.profileSidebarVisible = !this.state.profileSidebarVisible;
    if (this.state.profileSidebarVisible) {
      this.overlayOpen.next(null);
    }
  }

  isDesktop() {
    return window.innerWidth > 991;
  }
  isOverlay() {
    return this.config().menuMode === 'overlay';
  }
}
