import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { LocalStorageService } from '../../../shared/services/local-storage.service';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { ManifestDto } from '../models/manifest.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManifestService {

  constructor(private apiService: ApiService,
    private localStorageService: LocalStorageService
  ) { }

  getManifests(): Observable<any> {
    let _url = ApiEndpoints.Manifests;
    return this.apiService.get(_url);
  }

  getVoyages() {
    let terminalCode = this.localStorageService.getItem('terminalCode');
    var _url = ApiEndpoints.Manifests + '/request-manifest-voyage-numbers' + `/${terminalCode}`
    return this.apiService.get(_url);
  }

  getManifestById(id: string) {
    var _url = ApiEndpoints.Manifests + '/request-manifest' + `/${id}`
    return this.apiService.get(_url);
  }

  saveManifest(manifest: ManifestDto){
    var _url = ApiEndpoints.Manifests + '/create-manifest'
    return this.apiService.post(_url, manifest);
  }
}
