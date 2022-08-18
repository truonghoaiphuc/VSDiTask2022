import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  BehaviorSubject,
  concat,
  filter,
  Observable,
  of,
  take,
  tap,
  map,
} from 'rxjs';
import { environment } from 'src/environments/environment';
import { SystemConstants } from '../commons/constants/system.constants';
import { LoggedInUser } from '../Models/LoggedInUser';
import { StorageService } from './storage.service';
import jwt_decode from 'jwt-decode';
import { CurrentUser } from '../Models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenService {
  constructor(private _http: HttpClient, private _storage: StorageService) {}

  private _userSubject = new BehaviorSubject<CurrentUser | null>(null);

  persistToken(token: string) {
    this._storage.set(SystemConstants.CURRENT_USER, token);
  }

  getToken(): Observable<string | null> {
    return of(this._storage.get(SystemConstants.CURRENT_USER) || '');
  }

  clearToken() {
    this._storage.set(SystemConstants.CURRENT_USER, null);
  }

  logout(): void {
    this.clearToken();
  }

  isUserAuthenticated(): Observable<boolean> {
    return this.getUser().pipe(map((u) => !!u));
  }

  getUser() {
    return concat(
      this._userSubject.pipe(
        take(1),
        filter((u) => !!u)
      ),
      this.getCurrentUser().pipe(
        filter((u) => !!u),
        tap((u) => this._userSubject.next(u))
      ),
      this._userSubject.asObservable()
    );
  }

  getCurrentUser(): Observable<CurrentUser | null> {
    const token = this._storage.get(SystemConstants.CURRENT_USER);
    if (!token) {
      return of(null);
    }

    let claims: any;

    try {
      claims = jwt_decode(token);
    } catch {
      return of(null);
    }

    //check expiry
    if (!claims || Date.now().valueOf() > claims.expiry * 1000) {
      return of(null);
    }

    const user: CurrentUser = {
      userName: claims[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ] as string,
      fullName: claims[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ] as string,
      role: claims[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ] as string,
    };

    return of(user);
  }

  getLoggedInUser(): LoggedInUser {
    let user!: LoggedInUser;
    if (this.isUserAuthenticated()) {
      var usdata = localStorage.getItem(SystemConstants.CURRENT_USER);
      if (usdata != null) {
        var userData = JSON.parse(usdata);
        user = new LoggedInUser(
          userData.access_token,
          userData.username,
          userData.fullName,
          userData.email,
          userData.Phong,
          userData.Title,
          userData.avatar,
          userData.roles,
          userData.permissions
        );
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
