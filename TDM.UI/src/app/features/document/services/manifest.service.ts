import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { LocalStorageService } from '../../../shared/services/local-storage.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { ManifestDto } from '../models/manifest.model';
import { Observable } from 'rxjs';

@Injectable()
export class ManifestService {

  constructor(private apiService: ApiService,
    private localStorageService: LocalStorageService
  ) { }

  getManifests(pageNumber: number = 1, pageSize: number = 10, filters?: any): Observable<any> {
    const params: any = { pageNumber, pageSize };
    if (filters?.search) params.search = filters.search;
    if (filters?.dateFrom) params.dateFrom = this.formatDate(filters.dateFrom);
    if (filters?.dateTo) params.dateTo = this.formatDate(filters.dateTo);
    if (filters?.trafficId) params.trafficId = filters.trafficId;
    if (filters?.consigneeId) params.consigneeId = filters.consigneeId;
    if (filters?.cargoTypeId) params.cargoTypeId = filters.cargoTypeId;
    if (filters?.commodityId) params.commodityId = filters.commodityId;
    if (filters?.packageId) params.packageId = filters.packageId;
    return this.apiService.get(ApiEndpoints.Manifests, params);
  }

  private formatDate(date: Date): string {
    return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
  }

  getVoyages(search: string = '') {
    let terminalCode = this.localStorageService.getItem('terminalCode');
    var _url = ApiEndpoints.Manifests + '/request-manifest-voyage-numbers' + `/${terminalCode}`;
    const searchTerm = search.trim();
    if (searchTerm) {
      _url += `?search=${encodeURIComponent(searchTerm)}`;
    }
    return this.apiService.get(_url);
  }

  getItemsLookup(search: string = ''): Observable<any> {
    const searchTerm = search.trim();
    const url = searchTerm
      ? `${ApiEndpoints.Manifest_Items_Lookup}?search=${encodeURIComponent(searchTerm)}`
      : ApiEndpoints.Manifest_Items_Lookup;
    return this.apiService.get(url);
  }

  getManifestById(id: string) {
    var _url = ApiEndpoints.Manifests + '/request-manifest' + `/${id}`
    return this.apiService.get(_url);
  }

  saveManifest(manifest: ManifestDto) {
    var _url = ApiEndpoints.Manifests + '/create-manifest'
    return this.apiService.post(_url, manifest);
  }
}
