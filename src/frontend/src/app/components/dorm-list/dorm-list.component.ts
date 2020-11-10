import {AfterViewInit, Component, ElementRef, Inject, Injectable, OnInit} from '@angular/core';
declare function disqus(pageIdentifier: string): any;

import { mockDorms } from '../../mockdata/mock-dorms';
import {DOCUMENT} from '@angular/common';

@Component({
  selector: 'app-dorm-list',
  templateUrl: './dorm-list.component.html',
  styleUrls: ['./dorm-list.component.css']
})
@Injectable({
  providedIn: 'root'
})
export class DormListComponent implements OnInit, AfterViewInit {
  dorms = mockDorms;

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
    disqus('dorm-list');
  }

}
