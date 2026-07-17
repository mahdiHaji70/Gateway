import { Component } from '@angular/core';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { DeclarationService } from '../../../services/declaration.service';
import { FormControl, FormGroup } from '@angular/forms';
import { DischargeService } from '../../../services/discharge.service';
import { SendDischarge } from '../../../models/send-discharge.model';
import { MessageService } from 'primeng/api';
import { send } from 'process';
import { debug } from 'console';

@Component({
  selector: 'app-send-discharge',
  templateUrl: './send-discharge.component.html',
  styleUrl: './send-discharge.component.scss'
})
export class SendDischargeComponent {
  declarations: DropdownOption[] = [];
  sendDischarges: SendDischarge[] = [];

  form = new FormGroup({
    declaration: new FormControl<DropdownOption | undefined>(undefined),
  });
  /**
   *
   */
  constructor(private declarationService: DeclarationService,
    private dischargeService: DischargeService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.loadDeclarations();
  }

  loadDeclarations() {
    this.declarationService.getDeclarations().subscribe({
      next: (res: any) => {
        this.declarations = res.data.items.map((item: any) => new DropdownOption(item.id, item.ipasDeclarationNo));
      },
      error: (error: any) => { }
    });
  }

  loadDischarges(event: any) {
    this.dischargeService.getDischargesForSend(event.id).subscribe({
      next: (res: any) => {
        this.sendDischarges = res.data.items.map((item: any) => new SendDischarge(item.declarationId, item.ipasDeclarationNo,
          item.dischargeDate, item.vehicleNumber, item.wayBillNo, item.storeId, item.storeName, item.packNB, item.weight,
          item.isSend, item.volume, item.ipasTerminalDischargeId, item.id));
      },
      error: (error: any) => { }
    });
  }

 onSubmit() {
    if (!this.form.valid) return;

    const declarationId = this.form.get('declaration')?.value?.id;

    this.dischargeService.sendDischarges(declarationId!).subscribe({
        next: (responses: any) => {
            // Iterate through the local UI list
            this.sendDischarges.forEach(discharge => {
                // Find the matching response for this specific discharge
                const result = responses.data.find((r: any) => r.terminalDischargeId === discharge.id);

                if (result) {
                    // Check if a GUID is valid (not empty/null)
                    // Note: Guid.Empty in C# usually comes as "00000000-0000-0000-0000-000000000000"
                    const isValidGuid = result.ipasTerminalDischargeId && 
                                        result.ipasTerminalDischargeId !== '00000000-0000-0000-0000-000000000000';

                    if (isValidGuid) {
                        discharge.isSend = true;
                        discharge.sendError = undefined; // Clear any previous errors
                    } else {
                        discharge.isSend = false;
                        discharge.sendError = result.errorMessage || 'Unknown Error';
                    }
                }
            });

            this.messageService.add({ severity: 'success', summary: 'Process Completed' });
        },
        error: (error: any) => {
            this.messageService.add({ 
                severity: 'error', 
                summary: 'Request Failed', 
                detail: error?.error?.message || error.message 
            });
        }
    });
}

}
