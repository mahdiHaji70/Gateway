import { Location } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Subscription, filter } from 'rxjs';
import { MenuItems, MenuLabelKeys } from '../../../constants/menu-items';
import { RouteItems } from '../../../constants/route-items';
import { LanguageService } from '../../../services/language.service';

interface TitleRoute {
  label?: string;
  path?: string;
  items?: TitleRoute[];
}

@Component({
  selector: 'app-title-bar',
  templateUrl: './title-bar.component.html',
  styleUrl: './title-bar.component.scss'
})
export class TitleBarComponent implements OnInit, OnDestroy {
  title?: string;
  titleTranslationKey?: string;
  private routerSub?: Subscription;

  constructor(
    private router: Router,
    private location: Location,
    readonly languageService: LanguageService
  ) {}

  ngOnInit(): void {
    this.updateTitle(this.router.url);
    this.routerSub = this.router.events
      .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe(event => this.updateTitle(event.urlAfterRedirects));
  }

  ngOnDestroy(): void {
    this.routerSub?.unsubscribe();
  }

  goBack(): void {
    this.location.back();
  }

  private updateTitle(url: string): void {
    const path = normalizePath(url);
    this.title = path ? findTitle(path) : 'Dashboard';
    this.titleTranslationKey = this.title ? MenuLabelKeys[this.title] : undefined;
  }
}

function findTitle(targetPath: string): string {
  const routes = flattenMenuItems(MenuItems as TitleRoute[]).concat(RouteItems as TitleRoute[]);

  const directMatch = routes.find(route => route.path && pathsMatch(route.path, targetPath));
  if (directMatch?.label) {
    return directMatch.label;
  }

  // List menu paths also identify their related create and edit screens.
  const formMatch = routes.find(route => {
    if (!route.path?.endsWith('-list')) {
      return false;
    }

    const formPath = route.path.slice(0, -'-list'.length);
    return pathsMatch(formPath, targetPath);
  });

  return formMatch?.label ?? titleFromPath(targetPath);
}

function flattenMenuItems(items: TitleRoute[]): TitleRoute[] {
  return items.flatMap(item => [item, ...flattenMenuItems(item.items ?? [])]);
}

function pathsMatch(routePath: string, targetPath: string): boolean {
  const routeSegments = normalizePath(routePath).split('/').filter(Boolean);
  const targetSegments = normalizePath(targetPath).split('/').filter(Boolean);

  if (routeSegments.length > targetSegments.length) {
    return false;
  }

  return routeSegments.every((segment, index) =>
    segment.startsWith(':') || segment === targetSegments[index]
  );
}

function normalizePath(url: string): string {
  return url.split(/[?#]/, 1)[0].replace(/^\/+|\/+$/g, '');
}

function titleFromPath(path: string): string {
  const lastSegment = path.split('/').filter(Boolean).at(-1) ?? '';
  const readableSegment = lastSegment.replace(/-list$/, '').replace(/-/g, ' ');

  return readableSegment.replace(/\b\w/g, character => character.toUpperCase());
}
