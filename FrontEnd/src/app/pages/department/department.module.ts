import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DepartmentRoutingModule } from './department-routing.module';
import { DetailComponent } from './detail/detail.component';
import { ListComponent } from './list/list.component';


@NgModule({
  declarations: [
    DetailComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    DepartmentRoutingModule
  ]
})
export class DepartmentModule { }
