import { Component, OnInit } from '@angular/core';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ActivatedRoute} from '@angular/router';
import {ForumThread} from '../../models/forum-thread';
import {mockUsers} from '../../mockdata/mock-users';
import {UserService} from '../../service/user.service';

@Component({
  selector: 'app-forum-thread',
  templateUrl: './forum-thread.component.html',
  styleUrls: ['./forum-thread.component.css']
})
export class ForumThreadComponent implements OnInit {
  displayedThread: ForumThread;
  get isSignedIn(): boolean {
    return UserService.isSignedIn;
  }

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('threadId');

    this.displayedThread = mockForumSections.find(sct =>
        sct.threads.find(thrd => thrd.id === id) !== undefined)
      .threads.find(thrd => thrd.id === id);

    this.displayedThread.user = mockUsers.find(usr => usr.id === this.displayedThread.userId);

    this.displayedThread.replies.forEach(rpl => {
      rpl.user = mockUsers.find(usr => usr.id === rpl.userId);
      if (rpl.quoteId !== undefined)
      {
        rpl.quote = this.displayedThread.replies.find(repl => repl.quoteId);
      }
    });
  }

}
