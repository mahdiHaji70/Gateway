import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class UserService {

  constructor(private apiService: ApiService) { }

    getAllUsers(): Observable<any>{
      let _url = ApiEndpoints.BASE_AUTH_URL + '/get_all_users';
      return this.apiService.get(_url);
    }
    
}
