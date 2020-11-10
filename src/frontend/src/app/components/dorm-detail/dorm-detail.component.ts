import {AfterViewInit, Component, ElementRef, Inject, OnInit} from '@angular/core';
import {DOCUMENT} from '@angular/common';
declare function disqus(pageIdentifier: string): any;

@Component({
  selector: 'app-dorm-detail',
  templateUrl: './dorm-detail.component.html',
  styleUrls: ['./dorm-detail.component.css']
})
export class DormDetailComponent implements OnInit, AfterViewInit {

  constructor(@Inject(DOCUMENT) private doc) {
    // Add canonical URL to the page for search optimization and Disqus
    const link: HTMLLinkElement = doc.createElement('link');
    link.setAttribute('rel', 'canonical');
    doc.head.appendChild(link);
    link.setAttribute('href', doc.URL);
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    disqus('dorm-detail'); // Need somehow to substitute current dorm number
  }

}
