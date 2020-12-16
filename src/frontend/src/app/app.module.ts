import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { DormListComponent } from './components/dorm-list/dorm-list.component';
import { ForumComponent } from './components/forum/forum.component';
import { RequestAdmissionComponent } from './components/request-admission/request-admission.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { DormDetailComponent } from './components/dorm-detail/dorm-detail.component';
import { ForumSectionThreadListComponent } from './components/forum-section-thread-list/forum-section-thread-list.component';
import {AgmCoreModule} from "@agm/core";
import 'hammerjs';
import 'mousetrap';
import {GalleryModule} from "@ks89/angular-modal-gallery";

import { ForumThreadComponent } from './components/forum-thread/forum-thread.component';
import { CreateThreadComponent } from './components/create-thread/create-thread.component';
import { ThreadReplyComponent } from './components/thread-reply/thread-reply.component';
import { LoginComponent } from './components/login/login.component';
import {JwtInterceptor} from './helpers/jwt.interceptor';
import {ErrorInterceptor} from './helpers/error.interceptor';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey : 'AIzaSyAaZgGxzh87e9jXC1LOvz8zZJSMH3E77o0'
    }),
    GalleryModule.forRoot(),
    ReactiveFormsModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    NavBarComponent,
    DormListComponent,
    ForumComponent,
    RequestAdmissionComponent,
    ProfileComponent,
    HomeComponent,
    DormDetailComponent,
    ForumSectionThreadListComponent,
    ForumThreadComponent,
    CreateThreadComponent,
    ThreadReplyComponent,
    LoginComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
