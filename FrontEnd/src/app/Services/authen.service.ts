import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SystemConstants } from '../commons/constants/system.constants';
import { IUser } from '../Models/IUser';
import { LoggedInUser } from '../Models/LoggedInUser';

@Injectable({
  providedIn: 'root'
})
export class AuthenService {

  constructor(private _http : HttpClient){}

  public login(usercred : any){
    return this._http.post(`${environment.BASE_API}/api/Authentication/Login`, usercred);
  }

  logout() {
    localStorage.removeItem(SystemConstants.CURRENT_USER);
  }

  isUserAuthenticated(): boolean {
    return localStorage.getItem(SystemConstants.CURRENT_USER)!= null;
  }

  getLoggedInUser(): LoggedInUser {
    let user !: LoggedInUser;
    if (this.isUserAuthenticated()) {
      var usdata = localStorage.getItem(SystemConstants.CURRENT_USER);
      if(usdata != null){
        var userData = JSON.parse(usdata);
        user = new LoggedInUser(userData.access_token,
          userData.username,
          userData.fullName,
          userData.email,
          userData.Phong,
          userData.Title,
          userData.avatar, userData.roles, userData.permissions);
      }
      // var userData =
      //  JSON.parse(localStorage.getItem(SystemConstants.CURRENT_USER));
    }
    return user;
  }


  // checkAccess(functionId: string) {
  //   var user = this.getLoggedInUser();
  //   var result: boolean = false;
  //   var permission: any[] = JSON.parse(user.permissions);
  //   var roles: any[] = JSON.parse(user.roles);
  //   var hasPermission: number = permission.findIndex(x => x.FunctionId == functionId && x.CanRead == true);
  //   if (hasPermission != -1 || roles.findIndex(x => x == 'Admin') != -1) {
  //     return true;
  //   }
  //   else {
  //     return false;
  //   }
  // }
  // hasPermission(functionId: string, action: string): boolean {
  //   var user = this.getLoggedInUser();
  //   var result: boolean = false;
  //   var permission: any[] = JSON.parse(user.permissions);
  //   var roles: any[] = JSON.parse(user.roles);
  //   switch (action) {
  //     case 'create':
  //       var hasPermission: number = permission.findIndex(x => x.FunctionId == functionId && x.CanCreate == true);
  //       if (hasPermission != -1 || roles.findIndex(x => x == 'Admin') != -1) {
  //         result = true;
  //       }
  //       break;
  //     case 'update':
  //       var hasPermission: number = permission.findIndex(x => x.FunctionId == functionId && x.CanUpdate == true);
  //       if (hasPermission != -1 || roles.findIndex(x => x == 'Admin') != -1) {
  //         result = true;
  //       }
  //       break;
  //     case 'delete':
  //       var hasPermission: number = permission.findIndex(x => x.FunctionId == functionId && x.CanDelete == true);
  //       if (hasPermission != -1 || roles.findIndex(x => x == 'Admin') != -1) {
  //         result = true;
  //       }
  //       break;
  //   }
  //   return result;
  // }
}
