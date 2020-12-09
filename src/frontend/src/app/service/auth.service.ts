import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '../models/user';
import {Observable, of} from 'rxjs';
import {catchError, tap, shareReplay} from 'rxjs/operators';
import * as moment from 'moment';
import {AuthData} from '../models/auth-data';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  httpOptions = {
    headers: new HttpHeaders(
      {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': 'https://lnudormwatchapi.azurewebsites.net'
      },
    )
  };

  constructor(private http: HttpClient) { }

  public static isSignedIn(): boolean {
    return localStorage.getItem('user_token') === undefined;
  }

  getToken(): string {
    return localStorage.getItem('user_token');
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
    localStorage.removeItem('user_token');
    localStorage.removeItem('refresh_token');
  }

  private setupSession(authResult: AuthData): void {
    localStorage.setItem('user_token', authResult.token);
    localStorage.setItem('refresh_token', authResult.refreshToken);
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
