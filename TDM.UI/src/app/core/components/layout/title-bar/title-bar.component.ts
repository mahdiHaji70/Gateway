import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Subscription, filter } from 'rxjs';
import { MenuItems, MenuLabelKeys } from '../../../constants/menu-items';
import { RouteItems } from '../../../constants/route-items';
import { LanguageService } from '../../../services/language.service';

interface TitleRoute {
  label?: string;
  path?: string;
  translationKey?: string;
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
  private currentRoute = '/';
  private routeHistory: string[] = [];
  private navigatingBack = false;

  constructor(
    private router: Router,
    readonly languageService: LanguageService
  ) {}

  ngOnInit(): void {
    this.currentRoute = safeInAppRoute(this.router.url) ?? '/';
    this.updateTitle(this.router.url);
    this.routerSub = this.router.events
      .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe(event => {
        const nextRoute = safeInAppRoute(event.urlAfterRedirects);
        if (nextRoute && nextRoute !== this.currentRoute) {
          if (this.navigatingBack) {
            this.routeHistory.pop();
            this.navigatingBack = false;
          } else {
            this.routeHistory.push(this.currentRoute);
          }
          this.currentRoute = nextRoute;
        }
        this.updateTitle(event.urlAfterRedirects);
      });
  }

  ngOnDestroy(): void {
    this.routerSub?.unsubscribe();
  }

  goBack(): void {
    const previousRoute = this.routeHistory[this.routeHistory.length - 1];
    const targetRoute = previousRoute ?? '/';
    if (targetRoute === this.currentRoute) return;

    this.navigatingBack = true;
    void this.router.navigateByUrl(targetRoute)
      .then(navigated => {
        if (!navigated) this.navigatingBack = false;
      })
      .catch(() => {
        this.navigatingBack = false;
      });
  }

  private updateTitle(url: string): void {
    const path = normalizePath(url);
    const title = path ? findTitle(path) : { label: 'Dashboard' };
    this.title = title.label;
    this.titleTranslationKey = title.translationKey ?? (title.label ? MenuLabelKeys[title.label] : undefined);
  }
}

function safeInAppRoute(url: string): string | undefined {
  const path = url.split(/[?#]/, 1)[0];
  if (!path.startsWith('/') || path.startsWith('//')) return undefined;

  const normalizedPath = path.replace(/\/+$/, '') || '/';
  if (normalizedPath === '/login' || normalizedPath.startsWith('/login/')) return undefined;

  return normalizedPath;
}

function findTitle(targetPath: string): { label: string; translationKey?: string } {
  const routes = flattenMenuItems(MenuItems as TitleRoute[]).concat(RouteItems as TitleRoute[]);

  const directMatch = routes.find(route => route.path && pathsMatch(route.path, targetPath));
  if (directMatch?.label) {
    return { label: directMatch.label, translationKey: directMatch.translationKey };
  }

  // List menu paths also identify their related create and edit screens.
  const formMatch = routes.find(route => {
    if (!route.path?.endsWith('-list')) {
      return false;
    }

    const formPath = route.path.slice(0, -'-list'.length);
    return pathsMatch(formPath, targetPath);
  });

  if (formMatch?.label) {
    return { label: formMatch.label, translationKey: formMatch.translationKey };
  }

  return { label: titleFromPath(targetPath) };
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
