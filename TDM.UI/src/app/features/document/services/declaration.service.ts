import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Declaration } from '../models/declaration.model';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class DeclarationService {

  constructor(private apiService: ApiService) { }

  getDeclarations(): Observable<any> {
    let _url = ApiEndpoints.Declaration;
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Declaration + `/${id}`;
    return this.apiService.get(_url);
  }

  getByNumber(number: string): Observable<any> {
    let _url = ApiEndpoints.Declaration + `/GetByDeclarationNumber/${number}`;
    return this.apiService.get(_url);
  }

  postDeclaration(declaration: Declaration): Observable<any> {
    let _url = ApiEndpoints.Create_Declaration;
    return this.apiService.post(_url, declaration);
  }

  putDeclaration(declaration: Declaration): Observable<any> {
    let _url = ApiEndpoints.Update_Declaration;
    return this.apiService.put(_url, declaration);
  }
}
