import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmationService, MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { DataService } from 'src/app/Services/data.service';
import { CompanyDetailComponent } from '../company-detail/company-detail.component';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {

  Uri:string="api/CongTy";

  displayedColumns: string[] = ['maCty', 'tenCty','diaChi', 'ghiChu', 'action'];
  dataSource !: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(private dialog: MatDialog,
      private dataService : DataService,
      private messageService: MessageService,
      private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.getAllCompanies();
  }

  public AddCompany(){
    const dialogRef = this.dialog.open(CompanyDetailComponent, {width:'40%'});

      dialogRef.afterClosed().subscribe(result => {
        if(result==='add')
        this.getAllCompanies();
      });
  }

  public editCompany(row : any){
    this.dialog.open(CompanyDetailComponent,{
          width:'40%', data:row})
      .afterClosed().subscribe(val=>{
        if(val==='update'){
          this.getAllCompanies();
        }
      })
  }

  public deleteCompany(id: string){
    this.confirmationService.confirm({
      message: MessageContstants.CONFIRM_DELETE_MSG,
      header: 'Xác nhận',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.dataService.delete(this.Uri, id).subscribe({
          next:(res)=>{
            this.messageService.add({severity:'success', summary: 'Successful', detail: MessageContstants.DELETED_OK_MSG, life: 3000});
            this.getAllCompanies();
          }, error:(err)=>{
            alert(err);
          }
        });
      }
  });

  }

  public getAllCompanies(){
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

  public deleteSelectedCompanies(){

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}

