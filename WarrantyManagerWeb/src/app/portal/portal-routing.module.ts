import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { PortalDashboardComponent } from './components/portal-dashboard/portal-dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: PortalDashboardComponent,
    children: [
      {
        path: '',
        component: CustomerListComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PortalRoutingModule { }
