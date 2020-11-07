import { Component, OnInit } from '@angular/core';

import { dorms } from '../../mockdata/dorms';

@Component({
  selector: 'app-dorm-list',
  templateUrl: './dorm-list.component.html',
  styleUrls: ['./dorm-list.component.css']
})
export class DormListComponent implements OnInit {
  dorms = dorms;

  constructor() { }

  ngOnInit(): void {
  }

}
