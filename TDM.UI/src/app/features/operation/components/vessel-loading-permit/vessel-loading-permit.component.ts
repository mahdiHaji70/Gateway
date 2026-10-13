import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { VesselLoadingPermit } from '../../models/vessel-loading-permit.model';
import { VesselLoadingPermitConfirmation } from '../../models/vessel-loading-permit-confirmation.model';
import { VesselLoadingPermitService } from '../../services/vessel-loading-permit.service';
import { showApiError } from '../../../../shared/services/api-error-handler.service';

@Component({
  selector: 'app-vessel-loading-permit',
  templateUrl: './vessel-loading-permit.component.html',
  styleUrl: './vessel-loading-permit.component.scss'
})
export class VesselLoadingPermitComponent {
  storeReceiptId!: string;
  storeReceiptNo!: string;
  loadingPermit?: VesselLoadingPermit;
  isConfirming = false;

  form = new FormGroup({
    description: new FormControl<string | undefined>(undefined),
    isApproved: new FormControl<boolean | undefined>(undefined)
  });

  constructor(
    private route: ActivatedRoute,
    private vesselLoadingPermitService: VesselLoadingPermitService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.storeReceiptId = this.route.snapshot.paramMap.get('id')!;
    this.storeReceiptNo = this.route.snapshot.paramMap.get('srNo')!;
    this.loadVesselLoadingPermit();
  }

  loadVesselLoadingPermit() {
    this.vesselLoadingPermitService.getVesselLoadingPermit(this.storeReceiptId).subscribe({
      next: (res: any) => {
        const item = res.data;
        this.loadingPermit = new VesselLoadingPermit(
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

  confirmVesselLoadingPermit() {
    if (!this.loadingPermit || this.form.get('isApproved')?.value === undefined) {
      return;
    }

    const confirmation = new VesselLoadingPermitConfirmation({
      id: this.loadingPermit.id,
      terminalCode: this.loadingPermit.terminalCode,
      isApproved: this.form.get('isApproved')?.value ?? false,
      remark: this.form.get('description')?.value ?? ''
    });

    this.isConfirming = true;
    this.vesselLoadingPermitService.confirm(confirmation).subscribe({
      next: () => {
        this.isConfirming = false;
        this.form.reset();
        this.messageService.add({
          severity: 'success',
          summary: 'Vessel loading permit confirmed successfully.'
        });
        this.loadVesselLoadingPermit();
      },
      error: (error: any) => {
        this.isConfirming = false;
        showApiError(this.messageService, error);
      }
    });
  }
}
