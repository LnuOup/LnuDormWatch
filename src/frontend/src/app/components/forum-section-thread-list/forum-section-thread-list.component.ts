import {Component, Input, OnInit} from '@angular/core';
import {ForumSection} from '../../models/forum-section';
import {ActivatedRoute} from '@angular/router';
import {AuthService} from '../../service/auth.service';
import {ForumService} from '../../service/forum.service';

@Component({
  selector: 'app-forum-section-thread-list',
  templateUrl: './forum-section-thread-list.component.html',
  styleUrls: ['./forum-section-thread-list.component.css']
})
export class ForumSectionThreadListComponent implements OnInit {
  displayedSection: ForumSection;
  isInProgress: boolean;
  get isSignedIn(): boolean {
    return AuthService.isSignedIn();
  }

  constructor(private route: ActivatedRoute,
              private forumService: ForumService) { }

  ngOnInit(): void {
    this.isInProgress = true;

    const id = this.route.snapshot.paramMap.get('sectionId');
    this.forumService.getSectionById(id)
      .subscribe(res => {
        if (res !== undefined) {
          this.forumService.getThreads(id)
            .subscribe(thrdRes => {
              if (thrdRes !== undefined) {
                this.isInProgress = false;
                // fetch thread list
                res.threads = thrdRes.sort(
                  (thrd1, thrd2) =>
                    (new Date(thrd1.creationDate)).getTime() - (new Date(thrd2.creationDate)).getTime()
                );

                this.displayedSection = res;
              }
            });
        }
      });
  }

}
