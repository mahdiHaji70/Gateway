import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { OperationAggregationService } from '../../services/operation-aggregation.service';

@Component({
  selector: 'app-exit-from-store-list',
  templateUrl: './exit-from-store-list.component.html',
  styleUrl: './exit-from-store-list.component.scss'
})
export class ExitFromStoreListComponent {
  exitFromStores: any[] = [];

  /**
   *
   */
  constructor(    private router: Router,
      private messageService: MessageService,
      private confirmationService: ConfirmationService,
      private operationAggregationService: OperationAggregationService) { 

  }

   ngOnInit() {
      this.loadExitFromStores();
    }
  
    loadExitFromStores() {
      
    }

      onAdd() {
    this.router.navigate(['/operation/exit-from-store']);
  }

  onEdit(id: any) {
    this.router.navigate(['/operation/exit-from-store', id]);
  }

  onDelete(event: any, id: any) {
    
  }
}
