import {Component, Input, OnInit} from '@angular/core';
import {ForumThread} from '../../models/forum-thread';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ForumSection} from '../../models/forum-section';
import {ActivatedRoute, Router, ParamMap } from '@angular/router';
import {Form, FormBuilder, FormGroup} from '@angular/forms';
import {UserService} from '../../service/user.service';

@Component({
  selector: 'app-create-thread',
  templateUrl: './create-thread.component.html',
  styleUrls: ['./create-thread.component.css']
})
export class CreateThreadComponent implements OnInit {
  displayedSection: ForumSection;
  @Input() newThread: ForumThread;

  errorMessage: string;
  newThreadForm: FormGroup;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private userService: UserService,
              private formBuilder: FormBuilder) {
    this.newThreadForm = this.formBuilder.group({
      threadName: '',
      threadContent: ''
    });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      const id = +params.sectionId;

      this.displayedSection = mockForumSections.find(sct =>
        sct.id === id);
    });
  }

  addThread(): void {
    if (this.newThreadForm.value.threadName.length === 0) {
      this.errorMessage = 'Please enter the thread name';
    } else if (this.newThreadForm.value.threadContent.length === 0) {
      this.errorMessage = 'Please enter the thread content';
    } else {
      this.errorMessage = undefined;

      this.newThread = {
        id: this.displayedSection.threads.length,
        userId: 0,
        created: Date.now().toString(),
        replies: [],

        isPinned: false,

        name: this.newThreadForm.value.threadName,
        content: this.newThreadForm.value.threadContent
      };

      this.displayedSection.threads.push(this.newThread);

      this.router.navigateByUrl(`/forum/section/${this.displayedSection.id}`);
    }
  }

}
