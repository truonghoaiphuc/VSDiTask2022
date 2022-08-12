import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenService } from '../Services/authen.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor (private authService : AuthenService, private route:Router){

  }
  canActivate(next : ActivatedRouteSnapshot, state : RouterStateSnapshot){
    if(this.authService.isUserAuthenticated()){
      return true;
    }
    else{
      this.route.navigate(['login']);
      return false;
    }
  }
}
