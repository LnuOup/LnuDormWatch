import {Component, Input, OnInit} from '@angular/core';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ForumThread} from '../../models/forum-thread';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormGroup} from '@angular/forms';
import {ForumReply} from '../../models/forum-reply';
import {UserService} from '../../service/user.service';

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
              private formBuilder: FormBuilder) {
    this.newReplyForm = this.formBuilder.group({
      replyContent: ''
    });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      const id = +params.threadId;
      const quoteId = params.quoteId;

      this.displayedThread = mockForumSections.find(sct =>
        sct.threads.find(thrd => thrd.id === id) !== undefined)
        .threads.find(thrd => thrd.id === id);

      if (params.quoteId !== undefined) {
        this.selectedQuote = this.displayedThread.replies.find(rpl => rpl.id === +quoteId);
      }
    });
  }

  addReply(): void {
    if (this.newReplyForm.value.replyContent.length === 0) {
      this.errorMessage = 'Please enter the reply content';
    } else {
      this.errorMessage = undefined;

      this.newReply = {
        id: this.displayedThread.replies.length,
        userId: 0,
        posted: Date.now().toString(),

        content: this.newReplyForm.value.replyContent
      };

      if (this.selectedQuote !== undefined) {
        this.newReply.quoteId = this.selectedQuote.id;
      }

      this.displayedThread.replies.push(this.newReply);

      this.router.navigateByUrl(`/forum/thread/${this.displayedThread.id}`);
    }
  }

}
