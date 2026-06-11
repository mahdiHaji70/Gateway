import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { StuffAggregation } from '../models/stuff-aggregation.model';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class StuffService {

  constructor(private apiService: ApiService) { }

  create(stuffAggregation: StuffAggregation) {
    let _url = ApiEndpoints.Stuff;
    return this.apiService.post(_url, stuffAggregation);
  }
}
