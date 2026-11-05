import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Declaration } from '../models/declaration.model';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';

@Injectable()
export class DeclarationService {

  constructor(private apiService: ApiService) { }

  getDeclarations(
    pageNumber: number = 1,
    pageSize: number = 10,
    filters?: {
      search?: string;
      trafficId?: string;
      consigneeId?: string;
      consigneeRepId?: string;
      dateFrom?: Date | null;
      dateTo?: Date | null;
    }
  ): Observable<any> {
    const params: Record<string, string | number> = { pageNumber, pageSize };
    const search = filters?.search?.trim();
    if (search) params['search'] = search;
    if (filters?.trafficId) params['trafficId'] = filters.trafficId;
    if (filters?.consigneeId) params['consigneeId'] = filters.consigneeId;
    if (filters?.consigneeRepId) params['consigneeRepId'] = filters.consigneeRepId;
    if (filters?.dateFrom) params['dateFrom'] = this.formatDate(filters.dateFrom);
    if (filters?.dateTo) params['dateTo'] = this.formatDate(filters.dateTo);
    return this.apiService.get(ApiEndpoints.Declarations, params);
  }

  private formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  getLookup(search: string = '', pageNumber: number = 1, pageSize: number = 20): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/lookup?pageNumber=${pageNumber}&pageSize=${pageSize}`;
    const searchTerm = search.trim();
    if (searchTerm) {
      _url += `&search=${encodeURIComponent(searchTerm)}`;
    }
    return this.apiService.get(_url);
  }

  getById(id: string): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/${id}`;
    return this.apiService.get(_url);
  }

  getByNumber(number: string): Observable<any> {
    let _url = ApiEndpoints.Declarations + `/GetByDeclarationNumber/${number}`;
    return this.apiService.get(_url);
  }

  postDeclaration(declaration: Declaration): Observable<any> {
    let _url = ApiEndpoints.Declarations;
    return this.apiService.post(_url, declaration);
  }

  putDeclaration(declaration: Declaration): Observable<any> {
    let _url = ApiEndpoints.Declarations;
    return this.apiService.put(_url, declaration);
  }

  requestIpasDeclarationId(declarationId: string): Observable<any> {
    let _url = ApiEndpoints.Request_Ipas_Declaration_Id + `/${declarationId}`;
    return this.apiService.post(_url, {});
  }
}
