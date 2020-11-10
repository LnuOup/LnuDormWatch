import {AfterViewInit, Component, Inject, OnInit} from '@angular/core';
import {DOCUMENT} from '@angular/common';
declare function disqus(pageIdentifier: string): any;

@Component({
  selector: 'app-request-admission',
  templateUrl: './request-admission.component.html',
  styleUrls: ['./request-admission.component.css']
})
export class RequestAdmissionComponent implements OnInit, AfterViewInit {

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
    disqus('request-admission');
  }

}
