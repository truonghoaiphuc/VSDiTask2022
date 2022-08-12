import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListComponent } from './Components/Company/company-list/company-list.component';
import { DepartmentListComponent } from './Components/Departments/department-list/department-list.component';
import { LoginComponent } from './Components/login/login.component';
import { UsergroupListComponent } from './Components/UserGroup/usergroup-list/usergroup-list.component';
import { UserListComponent } from './Components/Users/user-list/user-list.component';
import { AuthGuard } from './Guard/auth.guard';

const routes: Routes = [
  {path:'', redirectTo:'/', pathMatch:'full'},
  {path:'login', component:LoginComponent},
  {path:'congty', component:CompanyListComponent, canActivate:[AuthGuard]},
  {path:'phongban', component:DepartmentListComponent, canActivate:[AuthGuard]},
  {path:'usergroup', component:UsergroupListComponent},
  {path:'users', component:UserListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
