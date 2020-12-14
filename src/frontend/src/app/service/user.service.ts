import { Injectable } from '@angular/core';
import {mockUsers} from '../mockdata/mock-users';
import {User} from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  activeUser: User;

  constructor() {
    this.activeUser = mockUsers[0];
  }
}
