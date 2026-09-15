import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ManifestService } from '../../../services/manifest.service';
import { ManifestFull } from '../../../models/manifest-full.model';

@Component({
  selector: 'app-manifest-list',
  templateUrl: './manifest-list.component.html',
  styleUrl: './manifest-list.component.scss'
})
export class ManifestListComponent {
  manifests: ManifestFull[] = [];

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private manifestService: ManifestService) {
  }

  ngOnInit(){
    this.loadManifests();
  }


  onFetchingManifests() {
    this.router.navigate(['/document/manifest']);
  }

  loadManifests() {
    this.manifestService.getManifests().subscribe({
      next: (res: any) => {
        this.manifests = res.data.items.map((item: any) =>
          new ManifestFull(item.id!, item.manifestRegistrationNumber, item.voyageNo, item.noticeNo, item.shipAgent,
            item.vesselName, item.imo, item.manifestNo, item.trafficName, item.consigneeName, item.cargoTypeName, item.hsCode, item.commodityName, item.packageName
            , item.packNb, item.grossWeight, item.container));
      },
      error: (error: any) => { }
    });
  }
}
