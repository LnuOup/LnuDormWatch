import {AfterViewInit, Component, ElementRef, Inject, Injectable, OnInit} from '@angular/core';

import { dorms } from '../../mockdata/dorms';
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
  dorms = dorms;

  constructor(@Inject(DOCUMENT) private doc, private elementRef: ElementRef) {
    // Add canonical URL to the page for search optimization and Disqus
    const link: HTMLLinkElement = doc.createElement('link');
    link.setAttribute('rel', 'canonical');
    doc.head.appendChild(link);
    link.setAttribute('href', doc.URL);
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    let s = this.doc.createElement('script');
    // s.type = 'text/javascript';
    /*Inserts <script> into HTML (direct tag doesn't work)*/
    s.innerHTML = 'var disqus_config = function () {\n'
      + '  this.page.url = document.head.querySelector("link[rel=\'canonical\']").href;\n' // Here page's canonical URL variable given
      + '  this.page.identifier = "dorm-list";\n' // Here page's unique identifier variable given
      + '  };\n'
      + '\n'
      + '  (function() {\n' // DON'T EDIT BELOW THIS LINE
      + '    var d = document, s = d.createElement(\'script\');\n'
      + '    s.src = \'https://lnudormwatch.disqus.com/embed.js\';\n'
      + '    s.setAttribute(\'data-timestamp\', +new Date());\n'
      + '    (d.head || d.body).appendChild(s);\n'
      + '  })();';
    // s.src = "http://somedomain.com/somescript";
    this.elementRef.nativeElement.appendChild(s);
  }

}
