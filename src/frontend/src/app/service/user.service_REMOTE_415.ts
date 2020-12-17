import { Injectable } from '@angular/core';
import {User} from '../models/user';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthService} from './auth.service';
import {environment} from '../../environments/environment';
import {Observable, of} from 'rxjs';
import {catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  httpHeaders = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Accept', '*/*');

  constructor(private http: HttpClient) {
  }

  // GET
  getUserInfo(): Observable<User> {
    if (AuthService.isSignedIn()) {
      return this.http.get<User>(`${environment.apiUrl}/api/v${environment.apiVersion}/User`,
        { headers: this.httpHeaders })
        .pipe(
          catchError(this.handleError<User>('getUserInfo'))
        );
    }
  }

  // PATCH
  updateUserInfo(user: User): Observable<any> {
    if (AuthService.isSignedIn()) {
      const userUpd = {
        email: user.email,
        userName: user.userName,
        phoneNumber: user.phoneNumber
      };

      return this.http.patch(`${environment.apiUrl}/api/v${environment.apiVersion}/User/update-user-info`, userUpd,
        { headers: this.httpHeaders, responseType: 'text'}
      )
        .pipe(
          catchError(this.handleError<any>('updateUserInfo'))
        );
    }
  }

  // PUT image
  uploadUserPhoto(imageFile: FormData): Observable<any> {
    if (AuthService.isSignedIn()) {
      return this.http.put(`${environment.apiUrl}/api/v${environment.apiVersion}/User/upload-user-photo`, imageFile,
        { responseType: 'text' })
        .pipe(
          catchError(this.handleError<object>('uploadUserPhoto'))
        );
    }
  }

  // tslint:disable-next-line:typedef
  private handleError<T>(operation: string, result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}
