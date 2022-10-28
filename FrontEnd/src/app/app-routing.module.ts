import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Guard/auth.guard';
import { AuthorizedComponent } from './layout/authorized/authorized.component';

const routes: Routes = [
  {
    path: '',
    component: AuthorizedComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
      {
        path: 'dashboard',
        loadChildren: () =>
          import('src/app/pages/dashboard/dashboard.module').then(
            (m) => m.DashboardModule
          ),
      },
      {
        path: 'company',
        loadChildren: () =>
          import('src/app/pages/company/company.module').then(
            (m) => m.CompanyModule
          ),
      },
      {
        path: 'department',
        loadChildren: () =>
          import('src/app/pages/department/department.module').then(
            (m) => m.DepartmentModule
          ),
      },
    ],
  },
  {
    path: 'login',
    loadChildren: () =>
      import('src/app/layout/unauthorized/unauthorized.module').then(
        (m) => m.UnauthorizedModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
