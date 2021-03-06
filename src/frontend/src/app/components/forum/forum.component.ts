import { Component, OnInit } from '@angular/core';
import {ForumSection} from '../../models/forum-section';
import {ForumService} from '../../service/forum.service';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {
  forumSections: ForumSection[];
  isInProgress: boolean;

  constructor(private forumService: ForumService) { }

  ngOnInit(): void {
    this.isInProgress = true;

    this.forumService.getSections()
      .subscribe(res => {
        this.isInProgress = false;

        if (res !== undefined) {
          this.forumSections = res.sort((sct1, sct2) =>
            (new Date(sct1.creationDate)).getTime() - (new Date(sct2.creationDate)).getTime());
        }
      });
  }

}
