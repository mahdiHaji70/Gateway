import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { DeclarationContainerInfo } from '../models/declaration-container-info.model';

@Injectable()
export class DeclarationContainerInfoService {

  constructor(private apiService: ApiService) { }

  getByDeclarationContainerId(id: string): Observable<any> {
      let _url = ApiEndpoints.Get_Declaration_Container_Info_By_Declaration_Container_Id + `/${id}`;
      return this.apiService.get(_url);
    }

      postDeclarationContainerInfo(declarationContainerInfo: DeclarationContainerInfo): Observable<any> {
        let _url = ApiEndpoints.Declaration_Container_Info;
        return this.apiService.post(_url, declarationContainerInfo);
      }
    
      putDeclarationContainerInfo(DeclarationContainerInfo: DeclarationContainerInfo): Observable<any> {
        let _url = ApiEndpoints.Declaration_Container_Info;
        return this.apiService.put(_url, DeclarationContainerInfo);
      }
    
      deleteDeclarationContainerInfo(id: string): Observable<any> {
        let _url = ApiEndpoints.Declaration_Container_Info + `/${id}`;
        return this.apiService.delete(_url);
      }
}
