import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { AuthenService } from 'src/app/Services/authen.service';
import { UserService } from 'src/app/Services/user.service';
import { tap } from 'rxjs';
import { Router } from '@angular/router';
import { DashboardModule } from 'src/app/pages/dashboard/dashboard.module';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup | any;
  loading: boolean = false;
  constructor(
    private _userService: UserService,
    private _authService: AuthenService,
    private _router: Router,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  onSubmit() {
    if (!this.loginForm.valid) {
      return;
    }
    this._userService
      .login(this.loginForm.value)
      .pipe(tap(() => (this.loading = true)))
      .subscribe({
        next: (token) => {
          if (token?.length) {
            this._authService.persistToken(token);
            this._router.navigateByUrl('dashboard');
          }
        },
      });
  }
}
