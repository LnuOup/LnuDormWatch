import {AfterViewChecked, Component} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewChecked {
  title = 'frontend';

  ngAfterViewChecked(): void {
    const footer = document.getElementsByTagName('footer')[0];
    if (document.body.clientHeight > window.outerHeight) {
      // If page content is higher than your window
      footer.removeAttribute('class');
    } else {
      footer.setAttribute('class', 'footer-switched-off');
    }
  }
}

