import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageService } from 'primeng/api';
import { delay, tap } from 'rxjs';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-department-detail',
  templateUrl: './department-detail.component.html',
  styleUrls: ['./department-detail.component.css']
})
export class DepartmentDetailComponent implements OnInit {
  Uri: string="api/phongbans";
  inputForm !: FormGroup;
  actionBtn : string="Lưu lại";

  loading : boolean = true;
  companies : any[]=[];


  constructor(private formbuilder: FormBuilder, private dataService: DataService,
    @Inject(MAT_DIALOG_DATA) public dept: any,
    private dialogRef : MatDialogRef<DepartmentDetailComponent>,
    private messageService: MessageService) {
    }

  ngOnInit(): void {
    this.inputForm = this.formbuilder.group({
      MaPhong: ['',Validators.required],
      TenPhong: ['',Validators.required],
      TrucThuoc: ['', Validators.required],
      GhiChu: [''],
    });

    if(this.dept){
      this.actionBtn="Cập nhật";
      this.inputForm.controls['MaPhong'].setValue(this.dept.maPhong);
      this.inputForm.controls['TenPhong'].setValue(this.dept.tenPhong);
      this.inputForm.controls['TrucThuoc'].setValue(this.dept.trucThuoc);
      this.inputForm.controls['GhiChu'].setValue(this.dept.ghiChu);
    }

    this.getAllCompanies();
  }

public getAllCompanies(){
  this.dataService.get('api/congty').pipe(
    tap(()=>this.loading=true)
  ).subscribe({
    next:(data)=>{
      this.companies = data;
      this.loading=false;
    },
    error: (error)=>{
      alert(error);
    }
  });
}


public addDept(){
  if(!this.dept){
    if(this.inputForm.valid){
      console.log(this.inputForm.value)
      this.dataService.add(this.Uri,this.inputForm.value)
        .subscribe({
          next:(res)=>{
            this.messageService.add({severity:'success', summary: 'Successful', detail: MessageContstants.CREATED_OK_MSG, life: 3000});
            this.inputForm.reset();
            this.dialogRef.close('add');
          },
          error: (error)=>{
            alert(error);
          }
        });
    }
  } else {
    this.updateDept(this.inputForm.value,this.dept.maPhong);
  }
}

public updateDept(data : any, id: string){
  this.dataService.update(this.Uri,data,id).subscribe({
    next:(res)=>{
      this.messageService.add({severity:'success', summary: 'Successful', detail: MessageContstants.UPDATED_OK_MSG, life: 3000});
      this.inputForm.reset();
      this.dialogRef.close('update');
    }, error:(err)=>{
      alert(err);
    }
  })
}


}
