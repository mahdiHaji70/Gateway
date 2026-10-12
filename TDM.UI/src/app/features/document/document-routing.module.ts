import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeclarationListComponent } from './components/declaration/declaration-list/declaration-list.component';
import { DeclarationComponent } from './components/declaration/declaration.component';
import { StoreReceiptIssueComponent } from './components/store-receipt-issue/store-receipt-issue.component';
import { StoreReceiptIssueRequestComponent } from './components/store-receipt-issue-request/store-receipt-issue-request.component';
import { ManifestComponent } from './components/manifest/manifest.component';
import { ManifestListComponent } from './components/manifest/manifest-list/manifest-list.component';
import { LandStoreReceiptIssueComponent } from './components/land-store-receipt-issue/land-store-receipt-issue.component';
import { MarineStoreReceiptIssueComponent } from './components/marine-store-receipt-issue/marine-store-receipt-issue.component';
import { StoreReceiptListComponent } from './components/store-receipt-list/store-receipt-list.component';

const routes: Routes = [
    { path: 'declaration-list', component: DeclarationListComponent},
    { path: 'declaration', component: DeclarationComponent},
    { path: 'declaration/:id', component: DeclarationComponent},
    { path: 'manifest-list', component: ManifestListComponent},
    { path: 'manifest', component: ManifestComponent},
    { path: 'store-receipt-issue-request', component: StoreReceiptIssueRequestComponent},
    { path: 'store-receipts', component: StoreReceiptListComponent},
    { path: 'land-store-receipt-issue', component: LandStoreReceiptIssueComponent},
    { path: 'marine-store-receipt-issue', component: MarineStoreReceiptIssueComponent},
    { path: 'warehouse-allocation/:id/:srNo', component: MarineStoreReceiptIssueComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DocumentRoutingModule { }
