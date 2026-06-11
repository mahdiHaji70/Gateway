import { Injectable } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../core/constants/api-endpoints';
import { SplitAggregation } from '../models/split-aggregation.model';
import { ExitFromInventory } from '../models/exit-from-inventory.model';

@Injectable()
export class OperationAggregationService {

  constructor(private apiService: ApiService) { }

  getDeclarationsWithLastTransfer(): Observable<any> {
    let _url = ApiEndpoints.Operation_Aggregation + '/GetDeclarationsWithLastTransfer';
    return this.apiService.get(_url);
  }

  aggregateDeclaration(declarationId: string, operationTypeId: string) {
    let _url = ApiEndpoints.Operation_Aggregation + '/TransferAggregatedData' + `?declarationId=${declarationId}&OperationTypeId=${operationTypeId}`;
    return this.apiService.post(_url, null);
  }

  getFinalInventoryForDeclaration(declarationId: string){
    let _url = ApiEndpoints.Operation_Aggregation + '/GetFinalInventoryForDeclaration' + `?declarationId=${declarationId}`;
    return this.apiService.get(_url); 
  }

  getContainerInventoryForConsignee(consigneeId: string){
    let _url = ApiEndpoints.Operation_Aggregation + '/GetContainerInventoryForConsignee' + `?consigneeId=${consigneeId}`;
    return this.apiService.get(_url); 
  }

  saveChangePackage(splitAggregation: SplitAggregation, aggregationId: string){
    let _url = ApiEndpoints.Operation_Aggregation + '/SplitAggregation' + `?aggregationId=${aggregationId}`;
    return this.apiService.post(_url, splitAggregation);
  }

    saveExitFromStore(exitFromInventory: ExitFromInventory, aggregationId: string){
    let _url = ApiEndpoints.Operation_Aggregation + '/ExitFromInventoryForDeclaration' + `?aggregationId=${aggregationId}`;
    return this.apiService.post(_url, exitFromInventory);
  }
}
