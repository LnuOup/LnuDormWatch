import {AfterViewInit, Component, ElementRef, Inject, OnInit} from '@angular/core';
import {DOCUMENT} from '@angular/common';
import {Dormitory} from "../../models/dormitory";
import {mockDorms} from "../../mockdata/mock-dorms";
import {ActivatedRoute} from "@angular/router";
declare function disqus(pageIdentifier: string): any;

@Component({
  selector: 'app-dorm-detail',
  templateUrl: './dorm-detail.component.html',
  styleUrls: ['./dorm-detail.component.css']
})
export class DormDetailComponent implements OnInit, AfterViewInit {
  dorm: Dormitory;
  autoPlay = true;
  showArrows = true;
  showDots = true;
  imageIndex = 1;

  constructor(@Inject(DOCUMENT) private doc, private route: ActivatedRoute) {
    // Add canonical URL to the page for search optimization and Disqus
    const link: HTMLLinkElement = doc.createElement('link');
    link.setAttribute('rel', 'canonical');
    doc.head.appendChild(link);
    link.setAttribute('href', doc.URL);
  }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('dormId');

    this.dorm = mockDorms.find(d =>
      d.id === id);
  }

  ngAfterViewInit(): void {
    disqus('dorm-detail'); // Need somehow to substitute current dorm number
  }

  onChangeAutoPlay(): void {
    this.autoPlay = !this.autoPlay;
  }

  onChangeShowArrows(): void {
    this.showArrows = !this.showArrows;
  }

  onChangeShowDots(): void {
    this.showDots = !this.showDots;
  }
}
