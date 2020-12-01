import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { DormListComponent } from './components/dorm-list/dorm-list.component';
import { ForumComponent } from './components/forum/forum.component';
import { RequestAdmissionComponent } from './components/request-admission/request-admission.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { DormDetailComponent } from './components/dorm-detail/dorm-detail.component';
import { ForumSectionThreadListComponent } from './components/forum-section-thread-list/forum-section-thread-list.component';
import { ForumThreadComponent } from './components/forum-thread/forum-thread.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
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
    LoginComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
