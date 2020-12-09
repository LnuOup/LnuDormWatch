import {Component, Input, OnInit} from '@angular/core';
import {ForumSection} from '../../models/forum-section';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ActivatedRoute} from '@angular/router';
import {mockUsers} from '../../mockdata/mock-users';
import {AuthService} from '../../service/auth.service';

@Component({
  selector: 'app-forum-section-thread-list',
  templateUrl: './forum-section-thread-list.component.html',
  styleUrls: ['./forum-section-thread-list.component.css']
})
export class ForumSectionThreadListComponent implements OnInit {
  displayedSection: ForumSection;
  get isSignedIn(): boolean {
    return AuthService.isSignedIn();
  }

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('sectionId');
    this.displayedSection = mockForumSections.find(sct =>
        sct.id === id);

    this.displayedSection.threads.forEach(thrd => {
      thrd.numOfReplies = thrd.replies.length;
      if (thrd.numOfReplies > 0)
      {
        thrd.lastReply = thrd.replies[0].posted;
        thrd.lastReplyBy = mockUsers.find(usr => usr.id === thrd.replies[0].userId);
      }
      thrd.user = mockUsers.find(usr => usr.id === thrd.userId);
    });
  }

}
