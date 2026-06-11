import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/components/login/services/auth.guard';
import { BaseLayoutComponent } from './core/components/layout/base-layout/base-layout.component';

const routes: Routes = [
  {
    path: '', component: BaseLayoutComponent,
    loadChildren: () => import('./features/feature.module').then(m => m.FeatureModule)
    , canActivate: [AuthGuard]
  },
  { path: 'login', loadChildren: () => import('./core/components/login/login.module').then(m => m.LoginModule) },
  //{ path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
