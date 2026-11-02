import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { Traffic } from '../models/traffic.model';
import { Observable } from 'rxjs';

@Injectable()
export class BasicInformationService {

  constructor(private apiService: ApiService) { }

  getAll(path: string, pageNumber: number = 1, pageSize: number = 10, search: string = ''): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}?pageNumber=${pageNumber}&pageSize=${pageSize}&search=${encodeURIComponent(search)}`;
    return this.apiService.get(_url);
  }

  getLookup(path: string, search: string = '', pageNumber: number = 1, pageSize: number = 20): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}/lookup?pageNumber=${pageNumber}&pageSize=${pageSize}&search=${encodeURIComponent(search)}`;
    return this.apiService.get(_url);
  }

  getById(path: string, id: any): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}/${id}`;
    return this.apiService.get(_url);
  }

  postBasicInformation<T>(path: string, model: T): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}`;
    return this.apiService.post(_url, model);
  }

  putBasicInformation<T>(path: string, model: T): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}`;
    return this.apiService.put(_url, model);
  }

  removeBasicInformation(path: string, id: any): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}/${id}`;
    return this.apiService.delete(_url);
  }
}
