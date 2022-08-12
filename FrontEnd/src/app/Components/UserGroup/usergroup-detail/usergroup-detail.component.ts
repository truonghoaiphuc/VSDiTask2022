import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-usergroup-detail',
  templateUrl: './usergroup-detail.component.html',
  styleUrls: ['./usergroup-detail.component.css']
})
export class UsergroupDetailComponent implements OnInit {
  Uri: string="UserGroup";
  inputForm !: FormGroup;
  actionBtn : string="Lưu lại";

  constructor(private formbuilder: FormBuilder, private dataService: DataService,
    @Inject(MAT_DIALOG_DATA) public usergroup: any,
    private dialogRef : MatDialogRef<UsergroupDetailComponent>,
    private messageService: MessageService) { }

  ngOnInit(): void {
    this.inputForm = this.formbuilder.group({
      GroupID: ['',Validators.required],
      GroupName: ['',Validators.required],
      GhiChu: [''],
    });

    if(this.usergroup){
      this.actionBtn="Cập nhật";
      this.inputForm.controls['GroupID'].setValue(this.usergroup.GroupID);
      this.inputForm.controls['GroupName'].setValue(this.usergroup.GroupName);
      this.inputForm.controls['GhiChu'].setValue(this.usergroup.GhiChu);
    }
  }
public addUserGroup(){
  if(!this.usergroup){
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
    this.updateUserGroup(this.inputForm.value,this.usergroup.id);
  }
}

public updateUserGroup(data : any, id: number){
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
