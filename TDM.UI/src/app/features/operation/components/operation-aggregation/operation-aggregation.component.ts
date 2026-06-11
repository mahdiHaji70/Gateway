import { Component } from '@angular/core';
import { OperationAggregationList } from '../../models/operation-aggregation-list.model';
import { OperationAggregationService } from '../../services/operation-aggregation.service';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-operation-aggregation',
  templateUrl: './operation-aggregation.component.html',
  styleUrl: './operation-aggregation.component.scss'
})
export class OperationAggregationComponent {
  operationAggregations: OperationAggregationList[] = [];

  /**
   *
   */
  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private operationAggregationService: OperationAggregationService) {
  }

  ngOnInit() {
    this.loadOperationAggregations();
  }

  loadOperationAggregations() {
    this.operationAggregationService.getDeclarationsWithLastTransfer().subscribe({
      next: (res: any) => {
        this.operationAggregations = res.data.map((item: OperationAggregationList) => new OperationAggregationList(item.declarationId, item.number, item.lastDate?.substring(0, 10)));
      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: error.message });

      }
    });
  }


  aggregateDeclaration(declarationId: string) {
    this.operationAggregationService.aggregateDeclaration(declarationId, 'E5B47B62-B3F4-4205-A666-8855F1A75781').subscribe({
      next: (res: any) => {
        if (res.status == 1) {
          this.loadOperationAggregations();
          this.messageService.add({ severity: 'success', summary: 'Successful operation', detail: res.message });
        }
        else
          this.messageService.add({ severity: 'error', summary: 'Error', detail: res.message });

      },
      error: (error: any) => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: error.message });
      }
    });
  }
}
