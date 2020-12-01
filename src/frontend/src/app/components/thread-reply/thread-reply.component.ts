import { Component, OnInit } from '@angular/core';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ForumThread} from '../../models/forum-thread';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-thread-reply',
  templateUrl: './thread-reply.component.html',
  styleUrls: ['./thread-reply.component.css']
})
export class ThreadReplyComponent implements OnInit {
  displayedThread: ForumThread;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('threadId');

    this.displayedThread = mockForumSections.find(sct =>
      sct.threads.find(thrd => thrd.id === id) !== undefined)
      .threads.find(thrd => thrd.id === id);
  }

}
