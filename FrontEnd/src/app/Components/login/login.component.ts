import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { MessageContstants } from 'src/app/commons/constants/message.constants';
import { SystemConstants } from 'src/app/commons/constants/system.constants';
import { tap } from 'rxjs';
import { AuthenService } from 'src/app/Services/authen.service';
import { LoggedInUser } from 'src/app/Models/LoggedInUser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup | any;
  loading : boolean = false;
  // title = 'material-login';
  constructor(
    private authenService: AuthenService,
    private messageService : MessageService,
    private router:Router
  ) {
    // this.loginForm = new FormGroup({
    //   email: new FormControl('', [Validators.required, Validators.email,Validators.pattern(
    //     '[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,63}$',
    //   ),]),
    //   password: new FormControl('', [Validators.required,Validators.pattern(
    //     '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,12}$'
    //   )])
    // });
    this.loginForm = new FormGroup({
      email : new FormControl('',Validators.required),
      password: new FormControl('', Validators.required)
    });
   }
  ngOnInit(): void {
  }
  onSubmit(){
    if(!this.loginForm.valid){
      return;
    }
    this.loading=true;
    this.authenService.login(this.loginForm.value).pipe(
      tap(()=>this.loading=true)
    )
    .subscribe({
      next: (response:any)=>{
      const user : LoggedInUser = response;
      if(user && user.access_token){
        localStorage.removeItem(SystemConstants.CURRENT_USER);
        localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(user));
        this.loading=false;
        this.router.navigate(['congty']);
      }
    }
    , error: (error)=>{
      this.messageService.add({severity:'error', summary: 'Đăng nhập', detail: "Tên đăng nhập hoặc mật khẩu không hợp lệ", life: 3000});
      this.loading=false;
    }
  })
  }
}
