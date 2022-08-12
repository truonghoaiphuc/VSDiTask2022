import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-company-detail',
  templateUrl: './company-detail.component.html',
  styleUrls: ['./company-detail.component.css']
})
export class CompanyDetailComponent implements OnInit {

  Uri: string="api/CongTy";
  inputForm !: FormGroup;
  actionBtn : string="Lưu lại";

  constructor(private formbuilder: FormBuilder, private dataService: DataService,
    @Inject(MAT_DIALOG_DATA) public company: any,
    private dialogRef : MatDialogRef<CompanyDetailComponent>,
    private messageService: MessageService) { }

  ngOnInit(): void {
    this.inputForm = this.formbuilder.group({
      MaCty: ['',Validators.required],
      TenCty: ['',Validators.required],
      DiaChi: [''],
      GhiChu: [''],
    });

    if(this.company){
      this.actionBtn="Cập nhật";
      this.inputForm.controls['MaCty'].setValue(this.company.maCty);
      this.inputForm.controls['TenCty'].setValue(this.company.tenCty);
      this.inputForm.controls['DiaChi'].setValue(this.company.diaChi);
      this.inputForm.controls['GhiChu'].setValue(this.company.ghiChu);
    }
  }
public addCompany(){
  if(!this.company){
    if(this.inputForm.valid){
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
    this.updateCompany(this.inputForm.value,this.company.maCty);
  }
}

public updateCompany(data : any, id: string){
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
