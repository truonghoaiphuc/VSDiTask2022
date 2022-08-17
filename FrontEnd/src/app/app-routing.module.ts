import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListComponent } from './Components/Company/company-list/company-list.component';
import { DepartmentListComponent } from './Components/Departments/department-list/department-list.component';
import { LoginComponent } from './Components/login/login.component';
import { UsergroupListComponent } from './Components/UserGroup/usergroup-list/usergroup-list.component';
import { UserListComponent } from './Components/Users/user-list/user-list.component';
import { AuthGuard } from './Guard/auth.guard';
import { AuthorizedComponent } from './layout/authorized/authorized.component';

const routes: Routes = [
  {path:"", component: AuthorizedComponent,
    // canActivate
    children:[{
      path:"",
      redirectTo:"dashboard",
      pathMatch:'full'
    },{
      path:"dashboard",
      loadChildren:()=> import('src/app/pages/dashboard/dashboard.module').then(m=>m.DashboardModule),
    },{
      path:"company",
      loadChildren:()=>import('src/app/pages/company/company.module').then(m=>m.CompanyModule),
    },{
      path:"department",
      loadChildren:()=>import('src/app/pages/department/department.module').then(m=>m.DepartmentModule),
    }]
},
{
  path:'login',
  loadChildren:()=>import('src/app/layout/unauthorized/unauthorized.module').then(m=>m.UnauthorizedModule),
}
  // {path:'', redirectTo:'/', pathMatch:'full'},
  // {path:'login', component:LoginComponent},
  // {path:'congty', component:CompanyListComponent, canActivate:[AuthGuard]},
  // {path:'phongban', component:DepartmentListComponent, canActivate:[AuthGuard]},
  // {path:'usergroup', component:UsergroupListComponent},
  // {path:'users', component:UserListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
