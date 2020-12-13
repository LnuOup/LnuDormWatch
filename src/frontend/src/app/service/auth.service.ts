import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '../models/user';
import {Observable, of} from 'rxjs';
import {catchError, tap, shareReplay} from 'rxjs/operators';
import * as moment from 'moment';
import {AuthData} from '../models/auth-data';
import {environment} from '../../environments/environment';
import {LocalStorage} from '../helpers/local-storage.enum';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  httpOptions = {
    headers: new HttpHeaders(
      {
        'Content-Type': 'application/json'
      },
    )
  };

  constructor(private http: HttpClient) { }

  public static isSignedIn(): boolean {
    const token = localStorage.getItem(LocalStorage.USER_TOKEN);
    return token !== null;
  }

  getToken(): string {
    return localStorage.getItem(LocalStorage.USER_TOKEN);
  }

  signIn(email: string, password: string): Observable<AuthData> {
    return this.http.post<AuthData>(`${environment.apiUrl}/api/v${environment.apiVersion}/Account/login`,
      {email, password}, this.httpOptions)
      .pipe(
        tap(res => this.setupSession(res)),
        catchError(this.handleError<AuthData>('login')),
        shareReplay()
      );
  }

  logOut(): void {
    localStorage.removeItem(LocalStorage.USER_TOKEN);
    localStorage.removeItem(LocalStorage.REFRESH_TOKEN);
  }

  private setupSession(authResult: AuthData): void {
    localStorage.setItem(LocalStorage.USER_TOKEN, authResult.token);
    localStorage.setItem(LocalStorage.REFRESH_TOKEN, authResult.refreshToken);
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
