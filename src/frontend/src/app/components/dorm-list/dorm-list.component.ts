import {AfterViewInit, Component, Inject, Injectable, OnInit} from '@angular/core';
declare function disqus(pageIdentifier: string): any;

import { mockDorms } from '../../mockdata/mock-dorms';
import {DOCUMENT} from '@angular/common';
import {Dormitory} from "../../models/dormitory";
import { Location } from "../../models/location";
import {DormitoryService} from "../../service/dormitory.service";

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
  initialLat: number;
  initialLng: number;
  zoomLevel: number;


  clickedMarker(label: string, index: number): void{
    console.log(`clicked the marker: ${label || index}`);
  }

  constructor(@Inject(DOCUMENT) private doc,
              private dormService: DormitoryService) {
    // Add canonical URL to the page for search optimization and Disqus
    const link: HTMLLinkElement = doc.createElement('link');
    link.setAttribute('rel', 'canonical');
    doc.head.appendChild(link);
    link.setAttribute('href', doc.URL);
  }

  ngOnInit(): void {
    this.initialLat = 49.8440995;
    this.initialLng = 24.0262646;
    this.zoomLevel = 13;
    this.dormService.getAllDormitories()
      .subscribe(res => {
          this.dorms = res;
        }
      );
  }

  ngAfterViewInit(): void {
    // disqus('dorm-list');
  }

  showOnMap(): void {
    this.openAsMap = ! this.openAsMap;
    this.initialLat = 49.8440995;
    this.initialLng = 24.0262646;
    this.zoomLevel = 13;
  }

  showDormOnMap(dorm: Dormitory): void {
    this.showOnMap();
    this.setMapLocation(dorm.location);
  }

  private setMapLocation(location: Location): void {
    this.initialLng = location.lng;
    this.initialLat = location.lat;
    this.zoomLevel = 15;
  }
}
