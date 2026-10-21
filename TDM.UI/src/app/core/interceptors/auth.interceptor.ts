import {
  HttpErrorResponse,
  HttpInterceptorFn,
  HttpRequest
} from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize, map, shareReplay, switchMap } from 'rxjs/operators';
import { AuthService } from '../components/login/services/auth.service';

let refreshRequest$: Observable<string> | null = null;

function isAuthenticationRequest(url: string): boolean {
  return url.includes('/Auth/login')
    || url.includes('/Auth/refresh')
    || url.includes('/Auth/logout');
}

function withAccessToken(request: HttpRequest<unknown>, token: string) {
  return request.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });
}

export const authInterceptor: HttpInterceptorFn = (request, next) => {
  debugger
  const authService = inject(AuthService);
  const router = inject(Router);
  const accessToken = authService.getAccessToken();
  const authenticatedRequest = accessToken
    ? withAccessToken(request, accessToken)
    : request;

  return next(authenticatedRequest).pipe(
    catchError((error: HttpErrorResponse) => {
      debugger;
      if (error.status !== 401 || isAuthenticationRequest(request.url)) {
        return throwError(() => error);
      }

      if (!authService.getRefreshToken()) {
        authService.clearSession();
        router.navigate(['/login']);
        return throwError(() => error);
      }

      if (!refreshRequest$) {
        refreshRequest$ = authService.refreshToken().pipe(
          map(tokens => {
            authService.storeTokens(tokens);
            return tokens.accessToken;
          }),
          finalize(() => refreshRequest$ = null),
          shareReplay(1)
        );
      }

      return refreshRequest$.pipe(
        switchMap(token => next(withAccessToken(request, token))),
        catchError(refreshError => {
          authService.clearSession();
          router.navigate(['/login']);
          return throwError(() => refreshError);
        })
      );
    })
  );
};
