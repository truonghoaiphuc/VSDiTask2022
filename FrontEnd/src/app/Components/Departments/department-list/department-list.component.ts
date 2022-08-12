import { Component, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmationService, MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { DataService } from 'src/app/Services/data.service';
import { DepartmentDetailComponent } from '../department-detail/department-detail.component';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
  Uri:string="api/PhongBans";

  displayedColumns: string[] = ['maPhong', 'tenPhong','trucThuoc', 'action'];
  dataSource !: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  loading:boolean=true;

  companies : [] = [];


  constructor(private dialog: MatDialog,
      private dataService : DataService,
      private messageService: MessageService,
      private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.getAllDeps();
  }

  public AddDep(){
    const dialogRef = this.dialog.open(DepartmentDetailComponent, {width:'40%'});
      dialogRef.afterClosed().subscribe(result => {
        if(result==='add')
        this.getAllDeps();
      });
  }

  public editDep(row : any){
    this.dialog.open(DepartmentDetailComponent,{
          width:'40%', data:row})
      .afterClosed().subscribe(val=>{
        if(val==='update'){
          this.getAllDeps();
        }
      })
  }

  public deleteDep(id: string){
    this.confirmationService.confirm({
      message: MessageContstants.CONFIRM_DELETE_MSG,
      header: 'Xác nhận',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.dataService.delete(this.Uri, id).subscribe({
          next:(res)=>{
            this.messageService.add({severity:'success', summary: 'Successful', detail: MessageContstants.DELETED_OK_MSG, life: 3000});
            this.getAllDeps();
          }, error:(err)=>{
            alert(err);
          }
        });
      }
  });

  }

  public getAllDeps(){
    this.dataService.get(this.Uri).subscribe({
      next:(data)=>{
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.paginator=this.paginator;
        this.dataSource.sort=this.sort;
        this.loading=false;
      },
      error: (error)=>{
        alert(error);
      }
    });
  }
  public getAllCompanies(){
    this.dataService.get('api/CongTy').subscribe({
      next:(data)=>{
        this.companies=data;
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
