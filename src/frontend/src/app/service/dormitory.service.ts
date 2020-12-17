import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable, of} from "rxjs";
import {AuthData} from "../models/auth-data";
import {catchError, shareReplay, tap} from "rxjs/operators";
import {Dormitory} from "../models/dormitory";
import {DormitoryImage} from '../models/dormitory-image';

@Injectable({
  providedIn: 'root'
})
export class DormitoryService {

  httpHeaders = new HttpHeaders(
      {
        'Content-Type': 'application/json'
      },
    );

  constructor(private http: HttpClient) { }

  // GET
  getAllDormitories(): Observable<Dormitory[]> {
    return this.http.get<Dormitory[]>(`${environment.apiUrl}/api/v${environment.apiVersion}/Dormitory/`,
      { headers: this.httpHeaders } )
      .pipe(
        catchError(this.handleError<Dormitory[]>('getAllDormitories'))
      );
  }

  // GET by id
  getDormitoryById(dormitoryId: number): Observable<Dormitory> {
    return this.http.get<Dormitory>(`${environment.apiUrl}/api/v${environment.apiVersion}/Dormitory/${dormitoryId}`,
      { headers: this.httpHeaders } )
      .pipe(
        catchError(this.handleError<Dormitory>('getDormitoryById'))
      );
  }

  // GET pictures
  getDormitoryPictures(dormitoryId: number): Observable<DormitoryImage[]> {
    return this.http.get<DormitoryImage[]>(`${environment.apiUrl}/api/v${environment.apiVersion}/Dormitory/pictures`,
      { headers: this.httpHeaders, params: new HttpParams().set('dormitoryId', dormitoryId.toString())  } )
      .pipe(
        catchError(this.handleError<DormitoryImage[]>('getDormitoryPictures'))
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
