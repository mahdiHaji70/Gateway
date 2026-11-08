import { Component } from '@angular/core';

import { showApiError } from '../../../../shared/services/api-error-handler.service';
import { SyncService } from '../../services/sync.service';
import { MessageService } from 'primeng/api';
import { finalize } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

type TagSeverity = 'success' | 'secondary' | 'info' | 'warning' | 'danger' | 'contrast';

interface SyncButton {
  name: string;
  styleClass: string;
  api: string;
  loading: boolean;
  severity: TagSeverity;
  lastDate?: Date;
  lastDateStatus?: 'notSynced' | 'notSyncedForTerminal';
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
        severity: 'warning',
        styleClass: 'p-button-warning',
        loading: false,
        api: 'DischargePermit',
        lastDate: undefined
      },
      {
        name: 'Goodway Bill',
        severity: 'warning',
        styleClass: 'p-button-warning',
        loading: false,
        api: 'GoodwayBill',
        lastDate: undefined
      },
      {
        name: 'Issue Request',
        severity: 'warning',
        styleClass: 'p-button-warning',
        loading: false,
        api: 'IssueRequest',
        lastDate: undefined
      },
      {
        name: 'Voyage',
        severity: 'warning',
        styleClass: 'p-button-warning',
        loading: false,
        api: 'Voyage',
        lastDate: undefined
      },
      {
        name: 'Store Receipt',
        severity: 'warning',
        styleClass: 'p-button-warning',
        loading: false,
        api: 'StoreReceipt',
        lastDate: undefined
      }
    ]

  /**
   *
   */
  constructor(private syncService: SyncService,
    private messageService: MessageService,
    private translate: TranslateService
  ) { }

  syncLastDateLabel(syncButton: SyncButton): string {
    if (syncButton.lastDateStatus) {
      return this.translate.instant(`sync.${syncButton.lastDateStatus}`) as string;
    }

    if (!syncButton.lastDate) {
      return '';
    }

    const date = syncButton.lastDate;
    const formattedDate = [date.getFullYear(), String(date.getMonth() + 1).padStart(2, '0'), String(date.getDate()).padStart(2, '0')].join('/');
    return this.translate.instant('sync.lastDate', { date: formattedDate }) as string;
  }

  ngOnInit() {
    this.getDischargePermitLastDate();
    this.getGoodwayBillsLastDate();
    this.getIssueRequestsLastDate();
    this.getVoyagesLastDate();
    this.getStoreReceiptsLastDate();
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

  getDischargePermitLastDate() {
    this.syncService.getDischargePermitsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1) {
          this.syncButtons[0].lastDate = new Date(res.data);
          this.syncButtons[0].lastDateStatus = undefined;
        } else {
          this.syncButtons[0].lastDate = undefined;
          this.syncButtons[0].lastDateStatus = 'notSyncedForTerminal';
        }
      },
      error: (error: any) => { }
    });
  }

  getGoodwayBillsLastDate() {
    this.syncService.getGoodwayBillsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1) {
          this.syncButtons[1].lastDate = new Date(res.data);
          this.syncButtons[1].lastDateStatus = undefined;
        } else {
          this.syncButtons[1].lastDate = undefined;
          this.syncButtons[1].lastDateStatus = 'notSyncedForTerminal';
        }
      },
      error: (error: any) => { }
    });
  }

  getIssueRequestsLastDate() {
    this.syncService.getIssueRequestsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1) {
          this.syncButtons[2].lastDate = new Date(res.data);
          this.syncButtons[2].lastDateStatus = undefined;
        } else {
          this.syncButtons[2].lastDate = undefined;
          this.syncButtons[2].lastDateStatus = 'notSyncedForTerminal';
        }
      },
      error: (error: any) => { }
    });
  }

  getVoyagesLastDate() {
    this.syncService.getVoyagesLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1) {
          this.syncButtons[3].lastDate = new Date(res.data);
          this.syncButtons[3].lastDateStatus = undefined;
        } else {
          this.syncButtons[3].lastDate = undefined;
          this.syncButtons[3].lastDateStatus = 'notSynced';
        }
      },
      error: (error: any) => { }
    });
  }

  getStoreReceiptsLastDate() {
    this.syncService.getStoreReceiptsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1) {
          this.syncButtons[4].lastDate = new Date(res.data);
          this.syncButtons[4].lastDateStatus = undefined;
        } else {
          this.syncButtons[4].lastDate = undefined;
          this.syncButtons[4].lastDateStatus = 'notSyncedForTerminal';
        }
      },
      error: (error: any) => { }
    });
  }

  syncGoodwayBills(syncButton: SyncButton) {
    this.syncService.getGoodwayBills().pipe(
      finalize(() => {
        syncButton.loading = false;
        this.getGoodwayBillsLastDate();
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
        this.getDischargePermitLastDate();
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
        this.getIssueRequestsLastDate();
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
        this.getVoyagesLastDate();
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
        this.getStoreReceiptsLastDate();
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
    syncButton.styleClass = 'p-button-success';
    this.messageService.add({
      severity: 'info',
      summary: this.translate.instant('sync.operationCompleted') as string,
      detail: this.translate.instant('sync.done') as string
    });
  }

  handleError(error: any, syncButton: SyncButton) {
    syncButton.severity = 'danger';
    syncButton.styleClass = 'p-button-danger';
    showApiError(this.messageService, error);
  }
}
