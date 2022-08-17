import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private _http: HttpClient) { }

  public login(usercred : any):Observable<string> {
    return this._http.post<string>(`${environment.BASE_API}/api/auth/login`, usercred);
  }
}
