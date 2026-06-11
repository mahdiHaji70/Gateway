import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { DeclarationContainer } from '../models/declaration-container.model';

@Injectable()
export class DeclarationContainerService {

  constructor(private apiService: ApiService) { }

  getByDeclarationItemId(id: string): Observable<any> {
    let _url = ApiEndpoints.Get_Declaration_Container_By_Declaration_Item_Id + `/${id}`;
    return this.apiService.get(_url);
  }

  postDeclarationContainer(declarationContainer: DeclarationContainer): Observable<any> {
    let _url = ApiEndpoints.Declaration_Container;
    return this.apiService.post(_url, declarationContainer);
  }

  putDeclarationContainer(declarationContainer: DeclarationContainer): Observable<any> {
    let _url = ApiEndpoints.Declaration_Container;
    return this.apiService.put(_url, declarationContainer);
  }

  deleteDeclarationContainer(id: string): Observable<any> {
    let _url = ApiEndpoints.Declaration_Container + `/${id}`;
    return this.apiService.delete(_url);
  }
}
