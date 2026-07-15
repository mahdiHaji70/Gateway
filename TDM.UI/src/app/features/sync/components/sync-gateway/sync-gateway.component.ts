import { Component } from '@angular/core';
import { SyncService } from '../../services/sync.service';
import { MessageService } from 'primeng/api';
import { finalize } from 'rxjs';

type TagSeverity = 'success' | 'secondary' | 'info' | 'warning' | 'danger' | 'contrast';

interface SyncButton {
  name: string;
  styleClass: string;
  api: string;
  loading: boolean;
  severity: TagSeverity;
}

@Component({
  selector: 'app-sync-gateway',
  templateUrl: './sync-gateway.component.html',
  styleUrl: './sync-gateway.component.scss'
})

export class SyncGatewayComponent {

  readonly syncButtons: SyncButton[] =
    [
      {
        name: 'DischargePermit',
        severity: 'success',
        styleClass: '',
        loading: false,
        api: 'DischargePermit'
      },
      {
        name: 'Goodway Bill',
        severity: 'success',
        styleClass: '',
        loading: false,
        api: 'GoodwayBill'
      },
      {
        name: 'Issue Request',
        severity: 'success',
        styleClass: '',
        loading: false,
        api: 'IssueRequest'
      },
      {
        name: 'Voyage',
        severity: 'success',
        styleClass: '',
        loading: false,
        api: 'Voyage'
      },
      {
        name: 'Store Receipt',
        severity: 'success',
        styleClass: '',
        loading: false,
        api: 'StoreReceipt'
      }
    ]

  /**
   *
   */
  constructor(private syncService: SyncService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
  }

  onSync(syncButton: SyncButton) {
    if (syncButton.loading) {
      return;
    }

    syncButton.loading = true;

    switch (syncButton.api) {
      case 'GoodwayBill':
        this.syncGoodwayBills(syncButton);
        break;
      case 'DischargePermit':
        this.syncDischargePermits(syncButton);
        break;
      case 'IssueRequest':
        this.syncIssueRequests(syncButton);
        break;
      case 'Voyage':
        this.syncVoyages(syncButton);
        break;
      case 'StoreReceipt':
        this.syncStoreReceipts(syncButton);
        break;
    }
  }

  syncGoodwayBills(syncButton: SyncButton) {
    this.syncService.getGoodwayBills().pipe(
      finalize(() => {
        syncButton.loading = false;
      })
    )
      .subscribe({
        next: (res: any) => {
          this.handleSuccess(syncButton);
        },
        error: (error: any) => {
          this.handleError(error, syncButton);
        }
      });
  }

  syncDischargePermits(syncButton: SyncButton) {
    this.syncService.getDischargePermits().pipe(
      finalize(() => {
        syncButton.loading = false;
      })
    )
      .subscribe({
        next: (res: any) => {
          this.handleSuccess(syncButton);
        },
        error: (error: any) => {
          this.handleError(error, syncButton);
        }
      });
  }

  syncIssueRequests(syncButton: SyncButton) {
    this.syncService.getIssueRequests().pipe(
      finalize(() => {
        syncButton.loading = false;
      })
    )
      .subscribe({
        next: (res: any) => {
          this.handleSuccess(syncButton);
        },
        error: (error: any) => {
          this.handleError(error, syncButton);
        }
      });
  }

  syncVoyages(syncButton: SyncButton) {
    this.syncService.getVoyages().pipe(
      finalize(() => {
        syncButton.loading = false;
      })
    )
      .subscribe({
        next: (res: any) => {
          this.handleSuccess(syncButton);
        },
        error: (error: any) => {
          this.handleError(error, syncButton);
        }
      });
  }

  syncStoreReceipts(syncButton: SyncButton) {
    this.syncService.getStoreReceipts().pipe(
      finalize(() => {
        syncButton.loading = false;
      })
    )
      .subscribe({
        next: (res: any) => {
          this.handleSuccess(syncButton);
        },
        error: (error: any) => {
          this.handleError(error, syncButton);
        }
      });
  }

  handleSuccess(syncButton: SyncButton) {
    syncButton.severity = 'success';
    syncButton.styleClass = '';
    this.messageService.add({ severity: 'info', summary: 'Operation successfully done.', detail: 'Done' });
  }

  handleError(error: any, syncButton: SyncButton) {
    syncButton.severity = 'danger';
    syncButton.styleClass = 'p-button-danger';
    this.messageService.add({
      severity: 'error',
      summary: 'Operation failed',
      detail: error?.message || ''
    });
  }
}
