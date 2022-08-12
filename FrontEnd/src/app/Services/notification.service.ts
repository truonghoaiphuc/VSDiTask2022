import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toast : ToastrService) { }

  public Success(){
    this.toast.success("Thành công");
  }
  public Error(){
    this.toast.error("Thất bại");
  }
}
