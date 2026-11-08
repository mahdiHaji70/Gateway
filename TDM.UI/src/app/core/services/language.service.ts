import { DOCUMENT } from '@angular/common';
import { Inject, Injectable, signal } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Observable, catchError, of, tap } from 'rxjs';

export type AppLanguage = 'en' | 'fa';

@Injectable({ providedIn: 'root' })
export class LanguageService {
  readonly currentLanguage = signal<AppLanguage>('en');
  private readonly storageKey = 'tdm.language';

  constructor(
    private translate: TranslateService,
    @Inject(DOCUMENT) private document: Document
  ) { }

  initialize(): Observable<unknown> {
    const savedLanguage = localStorage.getItem(this.storageKey);
    return this.activateLanguage(savedLanguage === 'fa' ? 'fa' : 'en');
  }

  toggleLanguage(): void {
    const nextLanguage = this.currentLanguage() === 'en' ? 'fa' : 'en';
    this.activateLanguage(nextLanguage).subscribe();
  }

  private activateLanguage(language: AppLanguage): Observable<unknown> {
    this.currentLanguage.set(language);
    localStorage.setItem(this.storageKey, language);
    this.document.documentElement.lang = language;
    this.document.documentElement.dir = language === 'fa' ? 'rtl' : 'ltr';

    return this.translate.use(language).pipe(
      tap(() => this.document.title = this.translate.instant('app.title') as string),
      catchError(() => of({}))
    );
  }
}

export function initializeLanguage(languageService: LanguageService): () => Observable<unknown> {
  return () => languageService.initialize();
}
