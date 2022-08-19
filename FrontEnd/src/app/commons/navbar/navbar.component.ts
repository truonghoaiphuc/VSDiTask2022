import { Component, OnInit } from '@angular/core';
import { AuthenService } from 'src/app/Services/authen.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(private authenService: AuthenService) {}

  ngOnInit(): void {}
}
