import { Injectable } from '@angular/core';
import {User} from '../models/user';
import {mockUsers} from '../mockdata/mock-users';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  static isSignedIn: boolean;

  activeUser: User;

  constructor() {
    this.activeUser = mockUsers[0];
  }

  signIn(): void {
    UserService.isSignedIn = true;
  }

  logOut(): void {
    UserService.isSignedIn = false;
  }
}
