import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class UserService {

  constructor(private apiService: ApiService) { }

    getAllUsers(search: string = ''): Observable<any>{
      let _url = ApiEndpoints.BASE_AUTH_URL + '/get_all_users';
      const searchTerm = search.trim();
      if (searchTerm) {
        _url += `?search=${encodeURIComponent(searchTerm)}`;
      }
      return this.apiService.get(_url);
    }
    
}
