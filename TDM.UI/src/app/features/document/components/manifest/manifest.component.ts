import { Component } from '@angular/core';
import { DropdownOption } from '../../../../shared/models/drop-down-option-model';
import { FormControl, FormGroup } from '@angular/forms';
import { ManifestService } from '../../services/manifest.service';
import { ManifestDto } from '../../models/manifest.model';
import { ManifestItemDto } from '../../models/manifest-item.model';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-manifest',
  templateUrl: './manifest.component.html',
  styleUrl: './manifest.component.scss'
})
export class ManifestComponent {
  voyages: DropdownOption[] = [];
  manifest: ManifestDto = new ManifestDto();
  expandedRowKeys: { [s: string]: boolean } = {};
  activeSubSection: { [key: string]: 'goods' | 'containers' } = {};

  form = new FormGroup({
    voyage: new FormControl<DropdownOption | undefined>(undefined),
  });

  /**
   *
   */
  constructor(private messageService: MessageService,
    private manifestService: ManifestService) {
  }

  ngOnInit() {
    this.loadVoyages();
  }

  loadVoyages() {
    this.manifestService.getVoyages().subscribe({
      next: (res: any) => {
        this.voyages = res.data.map((item: any) => new DropdownOption(item.manifestId, item.voyageNumber));
      },
      error: (error: any) => { }
    });
  }

  loadManifest(event: any) {
    this.manifestService.getManifestById(event.id).subscribe({
      next: (res: any) => {
        this.manifest = res.data;
      },
      error: (error: any) => { }
    });
  }

  SaveManifest() {
    debugger
    this.manifestService.saveManifest(this.manifest).subscribe({
      next: (res: any) => {
        this.messageService.add({ severity: 'success', summary: res.message });
      },
      error: (failRes: any) => {
        this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: failRes.error.Message });
      }
    });
  }

  toggleRowExpansion(item: ManifestItemDto, section: 'goods' | 'containers'): void {
    const key = item.manifestItemNo;
    if (!key) return;

    if (section === 'goods' && (!item.manifestGoods || item.manifestGoods.length === 0)) return;
    if (section === 'containers' && (!item.manifestContainers || item.manifestContainers.length === 0)) return;
    
    if (this.expandedRowKeys[key] && this.activeSubSection[key] === section) {
      delete this.expandedRowKeys[key];
      delete this.activeSubSection[key];
    } else {
      this.expandedRowKeys[key] = true;
      this.activeSubSection[key] = section;
    }
  }

  closeExpansion(key: string): void {
    delete this.expandedRowKeys[key];
    delete this.activeSubSection[key];
  }
}
