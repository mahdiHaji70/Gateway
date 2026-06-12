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

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/${id}`;
    return this.apiService.get(_url);
  }

  getByNumber(number: string): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/GetByDeclarationNumber/${number}`;
    return this.apiService.get(_url);
  }

  postDeclaration(declaration: Declaration): Observable<any> {
    let _url = ApiEndpoints.Declarations;
    return this.apiService.post(_url, declaration);
  }

  putDeclaration(declaration: Declaration): Observable<any> {
    let _url = ApiEndpoints.Declarations;
    return this.apiService.put(_url, declaration);
  }

  requestIpasDeclarationId(declarationId: string): Observable<any> {
    let _url = ApiEndpoints.Request_Ipas_Declaration_Id + `/${declarationId}`;
    return this.apiService.post(_url, {});
  }
}
