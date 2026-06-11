import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {    
  }

  get<T>(url: string, params?: any, headers?: any): Observable<T> {
    const options = this.buildOptions(params, headers);
    return this.http.get<T>(url, options);
  }

  post<T>(url: string, body: any, headers?: any): Observable<T> {
    const options = this.buildOptions(undefined, headers);
    return this.http.post<T>(url, body, options);
  }

  put<T>(url: string, body: any, headers?: any): Observable<T> {
    const options = this.buildOptions(undefined, headers);
    return this.http.put<T>(url, body, options);
  }

  delete<T>(url: string, params?: any, headers?: any): Observable<T> {
    const options = this.buildOptions(params, headers);
    return this.http.delete<T>(url, options);
  }

  private buildOptions(params?: any, headers?: any) {
    const httpHeaders = headers ? new HttpHeaders(headers) : new HttpHeaders();
    const httpParams = params ? new HttpParams({ fromObject: params }) : new HttpParams();

    return {
      headers: httpHeaders,
      params: httpParams
    };
  }
}
