import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UnauthorizedRoutingModule } from './unauthorized-routing.module';
import { UnauthorizedComponent } from './unauthorized.component';
import { LoginComponent } from './login/login.component';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';


@NgModule({
  declarations: [
    UnauthorizedComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    UnauthorizedRoutingModule
  ]
})
export class UnauthorizedModule { }
