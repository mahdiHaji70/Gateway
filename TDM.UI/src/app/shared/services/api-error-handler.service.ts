import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({ providedIn: 'root' })
export class ApiErrorHandlerService {
  show(messageService: MessageService, error: any): void {
    showApiError(messageService, error);
  }
}

export function showApiError(messageService: MessageService, error: any): void {
  const response = error?.error ?? error;
  const fieldErrors = response?.Errors || response?.errors;

  if (fieldErrors && typeof fieldErrors === 'object') {
    const details = Object.entries(fieldErrors)
      .flatMap(([field, messages]: [string, any]) =>
        (Array.isArray(messages) ? messages : [messages])
          .map(message => field ? `${field}: ${message}` : String(message)))
      .join(' | ');

    messageService.add({
      severity: 'error',
      summary: response?.Message || response?.title || 'Validation Error',
      detail: details || 'Validation failed.'
    });
    return;
  }

  messageService.add({
    severity: 'error',
    summary: response?.Message || response?.title || 'Operation failed',
    detail: response?.Message || response?.message || response?.title || error?.message || 'An unexpected error occurred.'
  });
}
