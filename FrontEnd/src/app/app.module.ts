import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './commons/navbar/navbar.component';
import{HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { CompanyListComponent } from './Components/Company/company-list/company-list.component';
import { CompanyDetailComponent } from './Components/Company/company-detail/company-detail.component';
import {ToastModule} from 'primeng/toast';
import { CommonModule } from '@angular/common';

import {ToolbarModule} from 'primeng/toolbar';
import {TableModule} from 'primeng/table';
import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {DialogService, DynamicDialogModule} from 'primeng/dynamicdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import {ConfirmPopupModule} from 'primeng/confirmpopup';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {CardModule} from 'primeng/card';
import {AvatarModule} from 'primeng/avatar';
import { DepartmentListComponent } from './Components/Departments/department-list/department-list.component';
import { DepartmentDetailComponent } from './Components/Departments/department-detail/department-detail.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { UsergroupListComponent } from './Components/UserGroup/usergroup-list/usergroup-list.component';
import { UsergroupDetailComponent } from './Components/UserGroup/usergroup-detail/usergroup-detail.component';
import { UserListComponent } from './Components/Users/user-list/user-list.component';
import { UserDetailComponent } from './Components/Users/user-detail/user-detail.component';
import {FileUploadModule} from 'primeng/fileupload';
import { LoginComponent } from './Components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CompanyListComponent,
    CompanyDetailComponent,
    DepartmentListComponent,
    DepartmentDetailComponent,
    UsergroupListComponent,
    UsergroupDetailComponent,
    UserListComponent,
    UserDetailComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    DragDropModule,
    MatDialogModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    CommonModule,
    ToolbarModule,
    TableModule,
    ButtonModule,
    InputTextModule,
    InputTextareaModule,
    DynamicDialogModule,
    ConfirmPopupModule,
    ConfirmDialogModule,
    ToastModule,
    CardModule,
    AvatarModule,
    MatProgressSpinnerModule,
    FileUploadModule
  ],
  providers: [MessageService,ConfirmationService, DialogService],
  bootstrap: [AppComponent]
})
export class AppModule { }
