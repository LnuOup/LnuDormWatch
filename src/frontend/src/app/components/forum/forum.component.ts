import { Component, OnInit } from '@angular/core';
import {ForumSection} from '../../models/forum-section';
import {mockForumSections} from '../../mockdata/mock-forum';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {
  forumSections: ForumSection[];

  constructor() { }

  ngOnInit(): void {
    this.forumSections = mockForumSections.map(fs => {
      fs.numOfThreads = fs.threads.length;
      if (fs.numOfThreads > 0)
      {
        fs.lastReply = fs.threads[0].lastReply;
      }

      return fs;
    });
  }

}
