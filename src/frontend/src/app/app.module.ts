import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { DormListComponent } from './components/dorm-list/dorm-list.component';
import { ForumComponent } from './components/forum/forum.component';
import { RequestAdmissionComponent } from './components/request-admission/request-admission.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { DormDetailComponent } from './components/dorm-detail/dorm-detail.component';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'dorms', component: DormListComponent },
      { path: 'mockDorms/:dormId', component: DormDetailComponent },
      { path: 'forum', component: ForumComponent },
      { path: 'request_admission', component: RequestAdmissionComponent }
    ])
  ],
  declarations: [
    AppComponent,
    NavBarComponent,
    DormListComponent,
    ForumComponent,
    RequestAdmissionComponent,
    ProfileComponent,
    HomeComponent,
    DormDetailComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
