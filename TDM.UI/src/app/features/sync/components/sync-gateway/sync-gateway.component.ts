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
  lastDate?: string;
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
    private messageService: MessageService
  ) { }

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
        if (res.status == 1)
          this.syncButtons[0].lastDate = 'Last date: ' +  new Date(res.data).toDateString();
        else
          this.syncButtons[0].lastDate = 'Not synced yet for your current terminal';
      },
      error: (error: any) => { }
    });
  }

  getGoodwayBillsLastDate() {
    this.syncService.getGoodwayBillsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1)
          this.syncButtons[1].lastDate = new Date(res.data).toDateString();
        else
          this.syncButtons[1].lastDate = 'Not synced yet for your current terminal';
      },
      error: (error: any) => { }
    });
  }

  getIssueRequestsLastDate() {
    this.syncService.getIssueRequestsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1)
          this.syncButtons[2].lastDate = new Date(res.data).toDateString();
        else
          this.syncButtons[2].lastDate = 'Not synced yet for your current terminal';
      },
      error: (error: any) => { }
    });
  }

  getVoyagesLastDate() {
    this.syncService.getVoyagesLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1)
          this.syncButtons[3].lastDate = new Date(res.data).toDateString();
        else
          this.syncButtons[3].lastDate = 'Not synced yet';
      },
      error: (error: any) => { }
    });
  }

  getStoreReceiptsLastDate() {
    this.syncService.getStoreReceiptsLastDate().subscribe({
      next: (res: any) => {
        if (res.status == 1)
          this.syncButtons[4].lastDate = new Date(res.data).toDateString();
        else
          this.syncButtons[4].lastDate = 'Not synced yet for your current terminal';
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
