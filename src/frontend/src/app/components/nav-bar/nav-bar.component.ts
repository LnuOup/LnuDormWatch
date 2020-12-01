import { Component, OnInit } from '@angular/core';
import {UserService} from '../../service/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  get isSignedIn(): boolean {
    return UserService.isSignedIn;
  }

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }


  logOut(): void {
    this.userService.logOut();
  }
}
