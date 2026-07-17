import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeclarationListComponent } from './components/declaration/declaration-list/declaration-list.component';
import { DeclarationComponent } from './components/declaration/declaration.component';
import { StoreReceiptIssueComponent } from './components/store-receipt-issue/store-receipt-issue.component';
import { StoreReceiptIssueRequestComponent } from './components/store-receipt-issue-request/store-receipt-issue-request.component';

const routes: Routes = [
    { path: 'declaration-list', component: DeclarationListComponent},
    { path: 'declaration', component: DeclarationComponent},
    { path: 'declaration/:id', component: DeclarationComponent},

    { path: 'store-receipt-issue-request', component: StoreReceiptIssueRequestComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DocumentRoutingModule { }
