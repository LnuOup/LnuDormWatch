import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../service/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  get isSignedIn(): boolean {
    return AuthService.isSignedIn();
  }

  constructor(private userService: AuthService) { }

  ngOnInit(): void {
  }


  logOut(): void {
    this.userService.logOut();
  }
}
