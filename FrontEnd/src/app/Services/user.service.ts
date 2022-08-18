import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private _http: HttpClient) {}

  public login(usercred: any): Observable<string> {
    return this._http
      .post<LoginRequest>(`${environment.BASE_API}/api/auth/login`, usercred)
      .pipe(map((response) => response.token));
  }
}
