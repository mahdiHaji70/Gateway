import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../../../core/services/api.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class ManifestService {
  constructor(private apiService: ApiService) { }

  getItemsLookup(search: string = ''): Observable<any> {
    const searchTerm = search.trim();
    const url = searchTerm
      ? `${ApiEndpoints.Manifest_Items_Lookup}?search=${encodeURIComponent(searchTerm)}`
      : ApiEndpoints.Manifest_Items_Lookup;
    return this.apiService.get(url);
  }

  getItemById(id: string): Observable<any> {
    return this.apiService.get(`${ApiEndpoints.Manifest_Item_By_Id}/${id}`);
  }
}
