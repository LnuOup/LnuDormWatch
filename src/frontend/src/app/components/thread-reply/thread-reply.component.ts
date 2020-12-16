import {Component, Input, OnInit} from '@angular/core';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ForumThread} from '../../models/forum-thread';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormGroup} from '@angular/forms';
import {ForumReply} from '../../models/forum-reply';
import {UserService} from '../../service/user.service';
import {ForumService} from '../../service/forum.service';
import {mockUsers} from '../../mockdata/mock-users';

@Component({
  selector: 'app-thread-reply',
  templateUrl: './thread-reply.component.html',
  styleUrls: ['./thread-reply.component.css']
})
export class ThreadReplyComponent implements OnInit {
  displayedThread: ForumThread;
  selectedQuote: ForumReply;
  @Input() newReply: ForumReply;

  errorMessage: string;
  newReplyForm: FormGroup;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private userService: UserService,
              private formBuilder: FormBuilder,
              private forumService: ForumService) {
    this.newReplyForm = this.formBuilder.group({
      replyContent: ''
    });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      const id = params.threadId;
      const quoteId = params.quoteId;

      this.forumService.getThreadById(id)
        .subscribe(res => {
          if (res !== undefined) {
            this.displayedThread = res;
          }
        });

      // get quote if present
      if (params.quoteId !== undefined) {
        this.forumService.getReplyById(quoteId)
          .subscribe(res => {
            if (res !== undefined) {
              res.author = mockUsers[0]; // TODO
              this.selectedQuote = res;
            }
          });
      }
    });
  }

  addReply(): void {
    if (this.newReplyForm.value.replyContent.length === 0) {
      this.errorMessage = 'Please enter the reply content';
    } else {
      this.errorMessage = undefined;

      if (this.selectedQuote !== undefined) {
        this.forumService.postReplyToReply(this.selectedQuote.id, this.newReplyForm.value.replyContent)
          .subscribe(res => {
            if (res !== undefined) {
              this.router.navigateByUrl(`/forum/thread/${this.displayedThread.id}`);
            } else {
              this.errorMessage = 'Failed to post reply';
            }
          });
      } else {
        this.forumService.postReplyToThread(this.displayedThread.id, this.newReplyForm.value.replyContent)
          .subscribe(res => {
            if (res !== undefined) {
              this.router.navigateByUrl(`/forum/thread/${this.displayedThread.id}`);
            } else {
              this.errorMessage = 'Failed to post reply';
            }
          });
      }
    }
  }

}
