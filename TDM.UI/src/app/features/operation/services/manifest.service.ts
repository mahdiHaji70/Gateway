import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class ManifestService {
  constructor(private apiService: ApiService) { }

  getItemsLookup(): Observable<any> {
    return this.apiService.get(ApiEndpoints.Manifest_Items_Lookup);
  }

  getItemById(id: string): Observable<any> {
    return this.apiService.get(`${ApiEndpoints.Manifest_Item_By_Id}/${id}`);
  }
}
