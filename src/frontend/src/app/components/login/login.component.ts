import { Component, OnInit } from '@angular/core';
import {Form, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../service/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: FormGroup;
  isInProgress: boolean;
  isLoginFailed: boolean;

  constructor(private userService: AuthService,
              private router: Router,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.login = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  signIn(): void {
    const val = this.login.value;

    if (val.email && val.password && !this.isInProgress)
    {
      this.isInProgress = true;

      this.userService.signIn(val.email, val.password)
        .subscribe(res => {
          this.isInProgress = false;

          if (res !== undefined) {
            this.router.navigateByUrl(``);
          }
          else {
            this.isLoginFailed = true; // show error msg
          }
        });

    }
  }
}
