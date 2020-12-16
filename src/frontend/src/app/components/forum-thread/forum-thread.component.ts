import { Component, OnInit } from '@angular/core';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ActivatedRoute} from '@angular/router';
import {ForumThread} from '../../models/forum-thread';
import {mockUsers} from '../../mockdata/mock-users';
import {AuthService} from '../../service/auth.service';
import {ForumService} from '../../service/forum.service';

@Component({
  selector: 'app-forum-thread',
  templateUrl: './forum-thread.component.html',
  styleUrls: ['./forum-thread.component.css']
})
export class ForumThreadComponent implements OnInit {
  displayedThread: ForumThread;
  get isSignedIn(): boolean {
    return AuthService.isSignedIn();
  }

  constructor(private route: ActivatedRoute,
              private forumService: ForumService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('threadId');

    this.forumService.getThreadById(id)
      .subscribe(res => {
        if (res !== undefined) {
          this.forumService.getReplies(id)
            .subscribe(replRes => {
              if (replRes !== undefined) {
                // fetch replies
                res.replies = replRes.sort((repl1, repl2) =>
                  (new Date(repl1.creationDate)).getTime() - (new Date(repl2.creationDate)).getTime());

                // TODO
                res.author = mockUsers[1];
                res.replies.forEach(repl => repl.author = mockUsers[0]);

                this.displayedThread = res;
              }
            });
        }
      });
  }

}
