import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SystemConstants } from '../commons/constants/system.constants';
import { LoggedInUser } from '../Models/LoggedInUser';
import { CurrentUser } from '../Models/User.model';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenService {

  constructor(private _http : HttpClient, private _storage: StorageService){}

  public login(usercred : any):Observable<string> {
    return this._http.post<string>(`${environment.BASE_API}/api/auth/login`, usercred);
  }

  persistToken(token: string) {
    this._storage.set(SystemConstants.CURRENT_USER,token);
  }

  logout(): void {
    this._storage.set(SystemConstants.CURRENT_USER, null);
  }

  isUserAuthenticated(): Observable<boolean> {
    return of(localStorage.getItem(SystemConstants.CURRENT_USER)!= null);
  }

  getCurrentUser():Observable<CurrentUser | null> {
    const token = this._storage.get(SystemConstants.CURRENT_USER);
    if(!token){
      return of(null);
    }   
    
    let claims: any;

    try{

    } catch{
      return of(null);
    }

    //check expiry
    if(!claims || Date.now().valueOf() > claims.expiry*1000){
      return of(null);
    }

    const user: CurrentUser={
      userName : claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] as string,
      fullName : claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] as string,
      role : claims["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] as string
  
    };

    return of(user);
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
