import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  static isSignedIn: boolean;

  constructor() { }

  signIn(): void {
    UserService.isSignedIn = true;
  }

  logOut(): void {
    UserService.isSignedIn = false;
  }
}
