import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Declaration } from '../models/declaration.model';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class DeclarationService {

  constructor(private apiService: ApiService) { }

  getDeclarations(): Observable<any> {
    let _url = ApiEndpoints.Declarations;
    return this.apiService.get(_url);
  }

  getLookup(search: string = '', pageNumber: number = 1, pageSize: number = 20): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/lookup?pageNumber=${pageNumber}&pageSize=${pageSize}`;
    const searchTerm = search.trim();
    if (searchTerm) {
      _url += `&search=${encodeURIComponent(searchTerm)}`;
    }
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/${id}`;
    return this.apiService.get(_url);
  }

  getByNumber(number: string): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/GetByDeclarationNumber/${number}`;
    return this.apiService.get(_url);
  }
}
