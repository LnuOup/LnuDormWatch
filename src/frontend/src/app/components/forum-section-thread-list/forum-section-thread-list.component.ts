import {Component, Input, OnInit} from '@angular/core';
import {ForumSection} from '../../models/forum-section';
import {mockForumSections} from '../../mockdata/mock-forum';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-forum-section-thread-list',
  templateUrl: './forum-section-thread-list.component.html',
  styleUrls: ['./forum-section-thread-list.component.css']
})
export class ForumSectionThreadListComponent implements OnInit {
  displayedSection: ForumSection;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('sectionId');

    this.displayedSection = mockForumSections.find(sct =>
        sct.id === id);
  }

}
