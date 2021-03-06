import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {AuthService} from '../service/auth.service';
import {Router} from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService,
              private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request)
      .pipe(
        catchError(err => {
          if ([401, 403].includes(err.status) && AuthService.isSignedIn()) {
            this.authService.refreshToken();
            this.router.navigateByUrl('/login');
          }

          const error = (err && err.error && err.error.message) || err.statusText;
          console.error(err);

          return throwError(error);
        })
      );
  }
}
