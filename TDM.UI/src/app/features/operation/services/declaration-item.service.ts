import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { DeclarationItem } from '../models/declaration-item.model';
import { Observable } from 'rxjs';

@Injectable()
export class DeclarationItemService {

  constructor(private apiService: ApiService) { }

  getByDeclarationId(id: string): Observable<any> {
    let _url = ApiEndpoints.Get_Declaration_Items_By_Declaration_Id + `/${id}`;
    return this.apiService.get(_url);
  }

  getAll(): Observable<any> {
    let _url = ApiEndpoints.Declaration_Items;
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Declaration_Items + `/${id}`;
    return this.apiService.get(_url);
  }

}
