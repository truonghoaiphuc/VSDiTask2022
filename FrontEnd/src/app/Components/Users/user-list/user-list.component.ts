import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmationService, MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { AuthenService } from 'src/app/Services/authen.service';
import { DataService } from 'src/app/Services/data.service';
import { UserDetailComponent } from '../user-detail/user-detail.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  Uri:string="Users";

  displayedColumns: string[] = ['UserName', 'FullName','Email','PhoneNumber','Phong','GroupID','Title','GhiChu','PhotoURL', 'action'];
  dataSource !: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(private dialog: MatDialog,
      private authenService : AuthenService,
      private dataService : DataService,
      private messageService: MessageService,
      private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  public addUser(){
    const dialogRef = this.dialog.open(UserDetailComponent, {width:'40%'});

      dialogRef.afterClosed().subscribe(result => {
        if(result==='add')
        this.getAllUsers();
      });
      // this.authenService.getLoggedInUser();
  }

  public editUser(row : any){
    this.dialog.open(UserDetailComponent,{
          width:'40%', data:row})
      .afterClosed().subscribe(val=>{
        if(val==='update'){
          this.getAllUsers();
        }
      })
  }

  public deleteUser(id: number){
    this.confirmationService.confirm({
      message: MessageContstants.CONFIRM_DELETE_MSG,
      header: 'Xác nhận',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.dataService.delete(this.Uri, id).subscribe({
          next:(res)=>{
            this.messageService.add({severity:'success', summary: 'Successful', detail: MessageContstants.DELETED_OK_MSG, life: 3000});
            this.getAllUsers();
          }, error:(err)=>{
            alert(err);
          }
        });
      }
  });

  }

  public getAllUsers(){
    this.dataService.get(this.Uri).subscribe({
      next:(data)=>{
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.paginator=this.paginator;
        this.dataSource.sort=this.sort;
      },
      error: (error)=>{
        alert(error);
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


}
