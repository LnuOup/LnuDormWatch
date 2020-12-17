import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from '../../environments/environment';
import {Observable, of} from "rxjs";
import {AuthData} from "../models/auth-data";
import {catchError, shareReplay, tap} from "rxjs/operators";
import {Dormitory} from "../models/dormitory";

@Injectable({
  providedIn: 'root'
})
export class DormitoryService {

  httpOptions = {
    headers: new HttpHeaders(
      {
        'Content-Type': 'application/json'
      },
    )
  };

  constructor(private http: HttpClient) { }

  getAllDormitories(): Observable<Dormitory[]> {
    return this.http.get<Dormitory[]>(`${environment.apiUrl}/api/v${environment.apiVersion}/Dormitory/`, this.httpOptions )
      .pipe(
        catchError(this.handleError<Dormitory[]>('dormitory'))
      );
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
