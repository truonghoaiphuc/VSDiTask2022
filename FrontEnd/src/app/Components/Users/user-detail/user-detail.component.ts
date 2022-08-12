import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { IChucDanh } from 'src/app/Models/IChucDanh';
import { IPhong } from 'src/app/Models/IPhong';
import { IUser } from 'src/app/Models/IUser';
import { IUserGroup } from 'src/app/Models/IUserGroup';
import { DataService } from 'src/app/Services/data.service';

type NewType = MessageService;

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  Uri: string="api/applicationuser/register";
  inputForm !: FormGroup;
  actionBtn : string="Lưu lại";

  us :  IUser ={};

  loading : boolean = true;

  depts : IPhong[]=[];
  usergroups : IUserGroup[]=[];
  chucdanhs : IChucDanh[]=[];

  avatarUrl : string = "assets/images/phucth.jpg";

  constructor(private formbuilder: FormBuilder, private dataService: DataService,
    @Inject(MAT_DIALOG_DATA) public user: any,
    private dialogRef : MatDialogRef<UserDetailComponent>,
    private messageService: MessageService) { }

  ngOnInit(): void {
    this.inputForm = this.formbuilder.group({
      UserName: ['',Validators.required],
      FullName: ['',Validators.required],
      Password: ['', Validators.required],
      DiaChi: ['',Validators.required],
      NgaySinh: ['',Validators.required],
      PhoneNumber: [''],
      Email: ['', [Validators.required, Validators.email]],
      GioiTinh: [''],
      GroupID: ['',Validators.required],
      Title: ['',Validators.required],
      Phong: ['',Validators.required],
      GhiChu: [''],
    });

    if(this.user){
      this.actionBtn="Cập nhật";
      this.inputForm.controls['UserName'].setValue(this.user.UserName);
      this.inputForm.controls['FullName'].setValue(this.user.FullName);
      this.inputForm.controls['DiaChi'].setValue(this.user.DiaChi);
      this.inputForm.controls['NgaySinh'].setValue(this.user.NgaySinh);
      this.inputForm.controls['PhoneNumber'].setValue(this.user.PhoneNumber);
      this.inputForm.controls['Email'].setValue(this.user.Email);
      this.inputForm.controls['GioiTinh'].setValue(this.user.GioiTinh);
      this.inputForm.controls['Phong'].setValue(this.user.Phong);
      this.inputForm.controls['GroupID'].setValue(this.user.GroupID);
      this.inputForm.controls['Title'].setValue(this.user.Title);
      this.inputForm.controls['GhiChu'].setValue(this.user.GhiChu);
    }

    this.loadData();
  }
// public addUser(){
//   if(!this.user){
//     if(this.inputForm.valid){
//       this.us.username = "phucth";
//       this.us.fullname = "Trương Hoài Phúc";
//       this.us.email = "phucth@vsd.vn";
//       this.us.password = "Backinh@27";
//       console.log(this.us.username);
//       this.dataService.add(this.us)
//         .subscribe({
//           next:(res)=>{
//             this.messageService.add({severity:'success', summary: 'Successful', detail: MessageContstants.CREATED_OK_MSG, life: 3000});
//             this.inputForm.reset();
//             this.dialogRef.close('add');
//           },
//           error: (error)=>{
//             alert(error);
//           }
//         });
//     }
//   } else {
//     this.updateUser(this.inputForm.value,this.user.id);
//   }
// }

onBasicUploadAuto(event:Event){
  console.log(event);
}

public updateUser(data : any, id: number){
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

public loadData(){
  this.dataService.get('PhongBan').subscribe(
    (data)=>{
      this.depts=data;
      this.loading=false;
    },
    (err)=>{
      alert(err);
    });
  this.dataService.get('UserGroup').subscribe(
    (data)=>{
      this.usergroups=data;
      this.loading=false;
    },
    (err)=>{
      alert(err);
    });
  this.dataService.get('Title').subscribe(
    (data)=>{
      this.chucdanhs=data;
      this.loading=false;
    },
    (err)=>{
      alert(err);
    });
}

getErrorMessage() {
  if (this.inputForm.controls['Email'].hasError('required')) {
    return 'You must enter a value';
  }

  return this.inputForm.controls['Email'].hasError('email') ? 'Email không đúng' : '';
}
}
