import { Component, OnInit } from '@angular/core';
import {Form, FormBuilder, FormGroup} from '@angular/forms';
import {UserService} from '../../service/user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: FormGroup;

  constructor(private userService: UserService,
              private router: Router,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.login = this.formBuilder.group({
      email: '',
      password: ''
    });
  }

  signIn(): void {
    this.userService.signIn();
    this.router.navigateByUrl(``);
  }
}
