import {AfterViewInit, Component, ElementRef, Inject, Injectable, OnInit, ViewChild} from '@angular/core';

import {LatLngBounds, MouseEvent} from '@agm/core';

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
  openAsMap = false;

  clickedMarker(label: string, index: number): void{
    console.log(`clicked the marker: ${label || index}`);
  }

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

  showOnMap(): void {
    this.openAsMap = ! this.openAsMap;
  }

  openDormDetailsPage(): void {
    window.alert('ta da dam');
  }
}
