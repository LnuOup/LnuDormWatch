import {AfterViewInit, Component, Inject, OnInit, AfterViewChecked} from '@angular/core';
import {DOCUMENT} from '@angular/common';
declare function disqus(pageIdentifier: string): any;
declare function getNumberOfDays(): any;
declare function updateAvailableRoomTypes(): any;
declare function getLivingPrice(): any;

@Component({
  selector: 'app-request-admission',
  templateUrl: './request-admission.component.html',
  styleUrls: ['./request-admission.component.css']
})
export class RequestAdmissionComponent implements OnInit, AfterViewInit, AfterViewChecked {

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

  ngAfterViewChecked(): void {
    document.getElementById('dropdown_dorms').setAttribute('onChange',
      'updateAvailableRoomTypes();');
    document.getElementById('radio_resident').setAttribute('onChange',
      'updateAvailableRoomTypes();');
    document.getElementById('radio_guest').setAttribute('onChange',
      'updateAvailableRoomTypes();');

    document.getElementById('button_calculate').setAttribute('onClick',
      'document.getElementById("total_price").innerText = getLivingPriceHandled();');
  }

}
