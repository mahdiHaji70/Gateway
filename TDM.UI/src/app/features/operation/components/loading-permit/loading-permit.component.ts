import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { LoadingPermit } from '../../models/loading-permit.model';
import { LoadingPermitConfirmation } from '../../models/loading-permit-confirmation.model';
import { LoadingPermitService } from '../../services/loading-permit.service';
import { showApiError } from '../../../../shared/services/api-error-handler.service';

@Component({
  selector: 'app-loading-permit',
  templateUrl: './loading-permit.component.html',
  styleUrl: './loading-permit.component.scss'
})
export class LoadingPermitComponent {
  storeReceiptId!: string;
  storeReceiptNo!: string;
  loadingPermit?: LoadingPermit;
  isConfirming = false;

  form = new FormGroup({
    description: new FormControl<string | undefined>(undefined),
    isApproved: new FormControl<boolean | undefined>(undefined)
  });

  constructor(
    private route: ActivatedRoute,
    private loadingPermitService: LoadingPermitService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.storeReceiptId = this.route.snapshot.paramMap.get('id')!;
    this.storeReceiptNo = this.route.snapshot.paramMap.get('srNo')!;
    this.loadLoadingPermit();
  }

  loadLoadingPermit() {
    this.loadingPermitService.getLoadingPermits(this.storeReceiptId).subscribe({
      next: (res: any) => {
        const item = res.data;
        this.loadingPermit = new LoadingPermit(
          item.id,
          item.terminal,
          item.date,
          item.serialNo,
          item.ownerName,
          item.ownerRepName,
          item.expirationDate,
          item.terminalCode);
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  confirmLoadingPermit() {
    if (!this.loadingPermit || this.form.get('isApproved')?.value === undefined) {
      return;
    }

    const confirmation = new LoadingPermitConfirmation({
      permitId: this.loadingPermit.id,
      terminalCode: this.loadingPermit.terminalCode,
      isApproved: this.form.get('isApproved')?.value ?? false,
      description: this.form.get('description')?.value ?? ''
    });

    this.isConfirming = true;
    this.loadingPermitService.confirm(confirmation).subscribe({
      next: () => {
        this.isConfirming = false;
        this.form.reset();
        this.messageService.add({
          severity: 'success',
          summary: 'Loading permit confirmed successfully.'
        });
        this.loadLoadingPermit();
      },
      error: (error: any) => {
        this.isConfirming = false;
        showApiError(this.messageService, error);
      }
    });
  }
}
