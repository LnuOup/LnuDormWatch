import { Component, OnInit } from '@angular/core';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ActivatedRoute} from '@angular/router';
import {ForumThread} from '../../models/forum-thread';

@Component({
  selector: 'app-forum-thread',
  templateUrl: './forum-thread.component.html',
  styleUrls: ['./forum-thread.component.css']
})
export class ForumThreadComponent implements OnInit {
  displayedThread: ForumThread;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('threadId');
    this.displayedThread = mockForumSections.find(sct =>
        sct.threads.find(thrd => thrd.id === id) !== undefined)
      .threads.find(thrd => thrd.id === id);
  }

}
