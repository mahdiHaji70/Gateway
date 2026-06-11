import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { Traffic } from '../models/traffic.model';
import { Observable } from 'rxjs';

@Injectable()
export class BasicInformationService {

  constructor(private apiService: ApiService) { }

  getAll(path: string): Observable<any>{
    let _url = ApiEndpoints.BASE_URL + `/${path}?pageNumber=1&pageSize=10`;
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
