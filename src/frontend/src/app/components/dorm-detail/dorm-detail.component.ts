import {AfterViewInit, Component, ElementRef, Inject, OnInit} from '@angular/core';
import {DOCUMENT} from '@angular/common';
import {Dormitory} from "../../models/dormitory";
import {Image} from '@ks89/angular-modal-gallery';
import {ActivatedRoute} from "@angular/router";
import {DormitoryService} from '../../service/dormitory.service';
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

  constructor(@Inject(DOCUMENT) private doc,
              private route: ActivatedRoute,
              private dormService: DormitoryService) {
    // Add canonical URL to the page for search optimization and Disqus
    const link: HTMLLinkElement = doc.createElement('link');
    link.setAttribute('rel', 'canonical');
    doc.head.appendChild(link);
    link.setAttribute('href', doc.URL);
  }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('dormId');

    this.dormService.getDormitoryById(id)
      .subscribe(res => {
        if (res !== undefined) {

          // fetch pictures
          this.dormService.getDormitoryPictures(id)
            .subscribe(pctsRes => {
              if (pctsRes !== undefined) {
                const mainPct = pctsRes.find(pct => pct.isMain);
                res.mainImageUrl = mainPct.imageUrl;
                res.dormitoryPictures = pctsRes.map(pct => new Image(pct.id, {img: pct.imageUrl}, {img: pct.imageUrl}));
              }
            });

          this.dorm = res;
        }
      });
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
