import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { filter } from 'rxjs';
import { MenuItems } from '../../../constants/menu-items';
import { RouteItems } from '../../../constants/route-items';
import { Subscription } from 'rxjs';
import { Location } from '@angular/common';

@Component({
  selector: 'app-title-bar',
  templateUrl: './title-bar.component.html',
  styleUrl: './title-bar.component.scss'
})
export class TitleBarComponent {
  title?: string;
  private routerSub?: Subscription;
  /**
   *
   */
  constructor(private router: Router, private location: Location) {

  }

  ngOnInit() {

    debugger;
    this.routerSub = this.router.events.subscribe((event: any) => {
      if (event.routerEvent instanceof NavigationEnd) {
        const url = event.routerEvent.urlAfterRedirects || event.routerEvent.url;
        // e.g. '/store-request'
        const mainPath = url.startsWith('/') ? url.replace(/^\/+([^\/]+\/[^\/]+).*/, '$1') : url;
        if (mainPath === '')
          this.title = 'Dashboard';
        else
          this.title = findLabelByPath(MenuItems, RouteItems, mainPath);
      }
    });
  }

  goBack() {
    this.location.back();
  }
}

function findLabelByPath(menuItems: any[], routeItems: any[], targetPath: string): string | undefined {
  var founded = false;
  for (const menu of menuItems) {
    if (menu.items) {
      const found = menu.items.find((item: any) => item.path.startsWith(targetPath));
      if (found) {
        founded = true;
        return found.label;
      }
    }
  }

  if (!founded) {
    const found = routeItems.find((item: any) => item.path.startsWith(targetPath));
    if (found) {
      return found.label;
    }
  }
  return undefined;
}