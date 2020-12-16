import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Observable, of} from 'rxjs';
import {ForumSection} from '../models/forum-section';
import {environment} from '../../environments/environment';
import {catchError} from 'rxjs/operators';
import {User} from '../models/user';
import {ForumThread} from '../models/forum-thread';
import {ForumReply} from '../models/forum-reply';

@Injectable({
  providedIn: 'root'
})
export class ForumService {
  httpHeaders = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Accept', '*/*');

  constructor(private http: HttpClient) { }

  // GET sections
  getSections(): Observable<ForumSection[]> {
    return this.http.get<ForumSection[]>(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/sections`,
      { headers: this.httpHeaders })
      .pipe(
        catchError(this.handleError<ForumSection[]>('getSections'))
      );
  }

  // GET section by id
  getSectionById(sectionId: string): Observable<ForumSection> {
    return this.http.get<ForumSection>(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/sections/${sectionId}`)
      .pipe(
        catchError(this.handleError<ForumSection>('getSectionById'))
      );
  }

  // GET threads
  getThreads(sectionId: string): Observable<ForumThread[]> {
    return this.http.get<ForumThread[]>(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/threads`,
      { headers: this.httpHeaders, params: new HttpParams().set('sectionId', sectionId) })
      .pipe(
        catchError(this.handleError<ForumThread[]>('getThreads'))
      );
  }

  // GET thread by id
  getThreadById(threadId: string): Observable<ForumThread> {
    return this.http.get<ForumThread>(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/threads/${threadId}`,
      { headers: this.httpHeaders})
      .pipe(
        catchError(this.handleError<ForumThread>('getThreadById'))
      );
  }

  // GET replies
  getReplies(threadId: string): Observable<ForumReply[]> {
    return this.http.get<ForumReply[]>(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/replies`,
      { headers: this.httpHeaders, params: new HttpParams().set('threadId', threadId) })
      .pipe(
        catchError(this.handleError<ForumReply[]>('getReplies'))
      );
  }

  // GET reply by id
  getReplyById(replyId: string): Observable<ForumReply> {
    return this.http.get<ForumReply>(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/replies/${replyId}`,
      { headers: this.httpHeaders})
      .pipe(
        catchError(this.handleError<ForumReply>('getReplyById'))
      );
  }

  // POST thread
  postThread(sectionId: string, threadTitle: string, threadBody: string): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/threads`,
      { sectionId, threadTitle, threadBody },
      { headers: this.httpHeaders, responseType: 'text' })
      .pipe(
      catchError(this.handleError<any>('postThread'))
    );
  }

  // POST reply to thread
  postReplyToThread(threadId: string, replyBody: string): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/replies/reply-to-thread`,
      { threadId, replyBody },
      { headers: this.httpHeaders, responseType: 'text' })
      .pipe(
        catchError(this.handleError<any>('postReplyToThread'))
      );
  }

  // POST reply to thread
  postReplyToReply(parentThreadReplyId: string, replyBody: string): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/v${environment.apiVersion}/Forum/replies/reply-to-reply`,
      { parentThreadReplyId, replyBody },
      { headers: this.httpHeaders, responseType: 'text' })
      .pipe(
        catchError(this.handleError<any>('postReplyToReply'))
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
