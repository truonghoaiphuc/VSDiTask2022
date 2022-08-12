import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SystemConstants } from '../commons/constants/system.constants';
import { IUser } from '../Models/IUser';
import { AuthenService } from './authen.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private headers = new HttpHeaders();

  constructor(private httpClient: HttpClient, private _authenService: AuthenService) {
    this.headers = this.headers.set('Content-Type', 'application/json');
      this.headers = this.headers.set("Authorization", "Bearer " + _authenService.getLoggedInUser().access_token);
   }

  public get(uri: string):Observable<any>{
    let dataURL = `${environment.BASE_API}/${uri}`;
    return this.httpClient.get<any>(dataURL, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  public add(uri: string, data: any){
    let dataURL = `${environment.BASE_API}/${uri}/`;
    return this.httpClient.post(dataURL,data, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  public update(uri: string, data: any, id:any){
    let dataURL = `${environment.BASE_API}/${uri}/${id}`;
    return this.httpClient.put(dataURL,data, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  public delete(uri:string, id:any){
    let dataURL = `${environment.BASE_API}/${uri}/${id}`;
    return this.httpClient.delete(dataURL, {headers: this.headers}).pipe(catchError(this.handleError));
  }

  public handleError(error:HttpErrorResponse){
    let errorMessage:string='';
    if(error.error instanceof ErrorEvent){
      errorMessage=`Error: ${error.error.message}`;
    }
    else {
      errorMessage=`Status: ${error.status} \n Message: ${error.message}`;
    }

    return throwError(errorMessage);
  }

}
