import { Component, OnInit, AfterViewChecked } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewChecked {

  constructor() { }

  ngOnInit(): void {
  }

  // Make all images clickable
  ngAfterViewChecked(): void {
    const images = document.getElementsByTagName('img');
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < images.length; i++) {
      const image = images[i];
      const source = image.getAttribute('src');
      const html =  image.outerHTML;
      image.outerHTML = '<a href=' + source + ' target="_blank">' + html + '</a>';
    }
  }

}
