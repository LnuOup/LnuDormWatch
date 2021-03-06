import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DormListComponent } from './components/dorm-list/dorm-list.component';
import { ForumComponent } from './components/forum/forum.component';
import { RequestAdmissionComponent } from './components/request-admission/request-admission.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { DormDetailComponent } from './components/dorm-detail/dorm-detail.component';
import { ForumSectionThreadListComponent } from './components/forum-section-thread-list/forum-section-thread-list.component';
import { ForumThreadComponent } from './components/forum-thread/forum-thread.component';
import {CreateThreadComponent} from './components/create-thread/create-thread.component';
import {ThreadReplyComponent} from './components/thread-reply/thread-reply.component';
import {LoginComponent} from './components/login/login.component';
import {AuthGuard} from './helpers/auth.guard';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'dorms', component: DormListComponent},
  {path: 'mockDorms/:dormId', component: DormDetailComponent},
  {path: 'forum', component: ForumComponent},
  {path: 'forum/new_thread', component: CreateThreadComponent, canActivate: [AuthGuard]},
  {path: 'forum/thread_reply', component: ThreadReplyComponent, canActivate: [AuthGuard]},
  {path: 'forum/section/:sectionId', component: ForumSectionThreadListComponent},
  {path: 'forum/thread/:threadId', component: ForumThreadComponent},
  {path: 'request_admission', component: RequestAdmissionComponent},
  {path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
