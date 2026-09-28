import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { ManifestService } from '../../../services/manifest.service';
import { VesselDischargeService } from '../../../services/vessel-discharge.service';
import { SendVesselDischarge } from '../../../models/send-vessel-discharge.model';

@Component({ selector: 'app-send-vessel-discharge', templateUrl: './send-vessel-discharge.component.html', styleUrl: './send-vessel-discharge.component.scss' })
export class SendVesselDischargeComponent {
  manifestItems: DropdownOption[] = [];
  discharges: SendVesselDischarge[] = [];
  form = new FormGroup({ manifestItem: new FormControl<DropdownOption | undefined>(undefined) });

  constructor(private manifestService: ManifestService, private vesselDischargeService: VesselDischargeService, private messageService: MessageService) { }

  ngOnInit() {
    this.manifestService.getItemsLookup().subscribe({
      next: (res: any) => this.manifestItems = (res.data || []).map((item: any) => new DropdownOption(item.id, `${item.voyageNo} / ${item.manifestNo}`)),
      error: (error: any) => this.showApiError(error)
    });
  }

  loadDischarges(event: any) {
    if (!event?.id) return;
    this.vesselDischargeService.getByManifestItemId(event.id).subscribe({
      next: (res: any) => this.discharges = (res.data || []).map((item: any) => ({ id: item.id, manifestItemNo: item.manifestItemNo, manifestNo: item.manifestNo, containerNo: item.containerNo, storeName: item.storeName, dischargeDate: item.dischargeDate, packNB: item.packNB, weight: item.weight, isDangerous: item.isDangerous, isSend: item.isSend })),
      error: (error: any) => this.showApiError(error)
    });
  }

  onSubmit() {
    const manifestItemId = this.form.get('manifestItem')?.value?.id;
    if (!manifestItemId) return;
    this.vesselDischargeService.sendToIpas(manifestItemId).subscribe({
      next: (res: any) => {
        (res.data || []).forEach((result: any) => {
          debugger
          const discharge = this.discharges.find(x => x.id === result.vesselDischargeId);
          if (!discharge) return;
          const success = !!result.ipasVesselDischargeId && result.ipasVesselDischargeId !== '00000000-0000-0000-0000-000000000000';
          discharge.isSend = success;
          discharge.sendError = success ? undefined : result.errorMessage || 'Unknown error';
        });
        this.messageService.add({ severity: 'success', summary: 'Process Completed' });
      },
      error: (error: any) => this.showApiError(error)
    });
  }

  private showApiError(error: any) {
    this.messageService.add({ severity: 'error', summary: error?.error?.Message || 'Operation failed', detail: error?.message || '' });
  }
}