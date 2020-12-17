import {Component, Input, OnInit} from '@angular/core';
import {ForumThread} from '../../models/forum-thread';
import {ActivatedRoute, Router, ParamMap } from '@angular/router';
import {Form, FormBuilder, FormGroup} from '@angular/forms';
import {UserService} from '../../service/user.service';
import {ForumService} from '../../service/forum.service';

@Component({
  selector: 'app-create-thread',
  templateUrl: './create-thread.component.html',
  styleUrls: ['./create-thread.component.css']
})
export class CreateThreadComponent implements OnInit {
  displayedSectionId: string;
  @Input() newThread: ForumThread;

  isInProgress: boolean;
  errorMessage: string;
  newThreadForm: FormGroup;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private userService: UserService,
              private formBuilder: FormBuilder,
              private forumService: ForumService) {
    this.newThreadForm = this.formBuilder.group({
      threadName: '',
      threadContent: ''
    });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      this.displayedSectionId = params.sectionId;
    });
  }

  addThread(): void {
    if (this.newThreadForm.value.threadName.length === 0) {
      this.errorMessage = 'Please enter the thread name';
    } else if (this.newThreadForm.value.threadContent.length === 0) {
      this.errorMessage = 'Please enter the thread content';
    } else {
      this.errorMessage = undefined;
      this.isInProgress = true;

      this.forumService.postThread(this.displayedSectionId, this.newThreadForm.value.threadName, this.newThreadForm.value.threadContent)
        .subscribe(res => {
          this.isInProgress = false;

          if (res !== undefined) {
            this.router.navigateByUrl(`/forum/section/${this.displayedSectionId}`);
          } else {
            this.errorMessage = 'Failed to create thread';
          }
        });

    }
  }

}
